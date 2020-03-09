using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Reflection;

namespace ScriptRunnerLibrary
{
    public class NoExecutableAssemblyError: Exception { };
    public class NoSuchClassNameError: Exception { };
    public class NoSuchClassFunctionError: Exception { };

    /// <summary>
    /// コンパイル済みスクリプトを表すクラス<br/>
    /// 別 AppDomain で動作させることを前提に MarshalByRefObject を継承している。
    /// </summary>
    public class Script: MarshalByRefObject
    {
        CompilerResults compilerResults = null;

        /// <summary>
        /// デフォルトのアセンブリ参照を使ってスクリプトをコンパイルする
        /// <code>
        /// Compile(script,
        /// new string[]{
        ///     "System.dll",
        ///     "System.Data.dll",
        ///     "System.Deployment.dll",
        ///     "System.Drawing.dll",
        ///     "System.Windows.Forms.dll",
        ///     "System.Xml.dll",
        ///     "mscorlib.dll"
        ///     });
        /// </code>
        /// と同等の動作。
        /// </summary>
        /// <param name="script">スクリプトソース</param>
        /// <returns>成功したら true</returns>
        public bool Compile(string script)
        {
            return Compile(script,
                new string[]{
                    "System.dll",
                    "System.Data.dll",
                    "System.Deployment.dll",
                    "System.Drawing.dll",
                    "System.Windows.Forms.dll",
                    "System.Xml.dll",
                    "mscorlib.dll"
                });
        }

        /// <summary>
        /// アセンブリ参照名を指定してスクリプトをコンパイルする
        /// </summary>
        /// <param name="script">スクリプトソース</param>
        /// <param name="assemblyNames">
        ///   アセンブリ参照名
        ///   <code>
        ///     new string[]{"System.dll", "System.Windows.Forms.dll"}
        ///   </code>のようにして与える。
        /// </param>
        /// <returns>成功したら true</returns>
        public bool Compile(string script, string[] assemblyNames)
        {
            // コンパイル時のオプション設定
            CompilerParameters param = new CompilerParameters(assemblyNames);   
            param.GenerateInMemory = true;          // exe を作らない
            param.IncludeDebugInformation = false;  // デバッグ情報を付加しない

            // コンパイルする
            CSharpCodeProvider codeProvider = new CSharpCodeProvider();
            compilerResults = codeProvider.CompileAssemblyFromSource(param, script);

            // エラーメッセージが無ければ成功
            return compilerResults.Errors.Count == 0;
        }

        /// <summary>
        /// 直前のコンパイルで生じたエラーメッセージを返す。
        /// </summary>
        /// <returns>エラーメッセージ</returns>
        public String[] ErrorMessage()
        {
            if (compilerResults == null)
                return new string[] { };
            string[] result = new string[compilerResults.Errors.Count];
            for (int i = 0; i < compilerResults.Errors.Count; i++)
                result[i]= compilerResults.Errors[i].ErrorText;
            return result;
        }

        private Type getClassReference(string ClassName)
        {
            if (compilerResults == null ||
                compilerResults.CompiledAssembly == null)
                throw new NoExecutableAssemblyError();
            return compilerResults.CompiledAssembly.GetType(ClassName);
        }

        /// <summary>
        /// クラス関数を呼び出す。
        /// </summary>
        /// <param name="ClassName">クラス名</param>
        /// <param name="FunctionName">クラス関数名</param>
        /// <param name="Parameters">パラメータ</param>
        /// <returns></returns>
        public object InvokeClassFunction(string ClassName, string FunctionName, object[] Parameters)
        {
            // 渡された引数の型をチェック
            Type[] argumentTypes = new Type[Parameters.Length];
            for (int i = 0; i < Parameters.Length; i++)
                argumentTypes[i] = Parameters[i].GetType();

            // クラスリファレンスを取得
            Type type = getClassReference(ClassName);
            if (type == null)
                throw new NoSuchClassNameError();

            // クラス関数を取得
            MethodInfo mi= type.GetMethod(FunctionName, argumentTypes);
            if (mi == null)
                throw new NoSuchClassFunctionError();

            // 呼び出し
            return mi.Invoke(null, Parameters);
        }

        /// <summary>
        /// クラスのインスタンスを作成する。
        /// </summary>
        /// <param name="ClassName">クラス名</param>
        /// <param name="Parameters">コンストラクタに渡すパラメータ</param>
        /// <returns>クラスのインスタンス</returns>
        public object CreateInstance(string ClassName, object[] Parameters)
        {
            // 渡された引数の型をチェック
            Type[] argumentTypes = new Type[Parameters.Length];
            for (int i = 0; i < Parameters.Length; i++)
                argumentTypes[i] = Parameters[i].GetType();

            // クラスリファレンスを取得
            Type type = getClassReference(ClassName);
            if (type == null)
                throw new NoSuchClassNameError();

            // コンストラクタの取得
            ConstructorInfo constructorInfo = type.GetConstructor(argumentTypes);
            if (constructorInfo == null)
                throw new NoSuchClassFunctionError();

            // 呼び出し
            return constructorInfo.Invoke(Parameters);
        }

        /// <summary>
        /// オブジェクトのメンバ関数を呼びだす。
        /// </summary>
        /// <param name="Object">対象となるオブジェクト</param>
        /// <param name="FunctionName">関数名</param>
        /// <param name="Parameters">パラメータ</param>
        /// <returns></returns>
        public object InvokeFunction(object Object, string FunctionName, object[] Parameters)
        {
            // 渡された引数の型をチェック
            Type[] argumentTypes = new Type[Parameters.Length];
            for (int i = 0; i < Parameters.Length; i++)
                argumentTypes[i] = Parameters[i].GetType();

            // 型情報を取得
            Type type = Object.GetType();

            // メンバ関数の取得
            MethodInfo methodInfo = type.GetMethod(FunctionName, argumentTypes);
            if (methodInfo == null)
                throw new NoSuchClassFunctionError();

            // 呼び出し
            return methodInfo.Invoke(Object, Parameters);
        }

        /// <summary>
        /// オブジェクトのフィールドに値を代入する
        /// </summary>
        /// <param name="Object">対象となるオブジェクト</param>
        /// <param name="FieldName">フィールド名</param>
        /// <param name="Value">値</param>
        public void SetField(object Object, string FieldName, object Value)
        {
            Type type = Object.GetType();
            FieldInfo fieldInfo = type.GetField(FieldName);
            fieldInfo.SetValue(Object, Value);
        }

        /// <summary>
        /// オブジェクトのフィールドから値を読み出す
        /// </summary>
        /// <param name="Object">対象となるオブジェクト</param>
        /// <param name="FieldName">フィールド名</param>
        /// <returns>値</returns>
        public object GetField(object Object, string FieldName)
        {
            Type type = Object.GetType();
            FieldInfo fieldInfo = type.GetField(FieldName);
            return fieldInfo.GetValue(Object);
        }

        /// <summary>
        /// オブジェクトのプロパティに値を代入する
        /// </summary>
        /// <param name="Object">対象となるオブジェクト</param>
        /// <param name="FieldName">プロパティ名</param>
        /// <param name="Value">値</param>
        public void SetProperty(object Object, string PropertyName, object Value)
        {
            Type type = Object.GetType();
            PropertyInfo propertyInfo = type.GetProperty(PropertyName);
            propertyInfo.SetValue(Object, Value, null);
        }

        /// <summary>
        /// オブジェクトのプロパティから値を読み出す
        /// </summary>
        /// <param name="Object">対象となるオブジェクト</param>
        /// <param name="FieldName">プロパティ名</param>
        /// <returns>値</returns>
        public object GetProperty(object Object, string PropertyName)
        {
            Type type = Object.GetType();
            PropertyInfo propertyInfo = type.GetProperty(PropertyName);
            return propertyInfo.GetValue(Object, null);
        }
    }
}
