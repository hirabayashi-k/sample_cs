using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Olympus.Common
{

    // WebBrowser の解放に不安がある
    // 確保したらプログラム終了まで使いまわす前提
    public class JavaScriptControl : IDisposable
    {
        public WebBrowser web = new WebBrowser();

        void wait(Func<bool> done, int timeout)
        {
            var start = DateTime.Now;
            while (!done())
            {
                if ((DateTime.Now - start).TotalMilliseconds > timeout)
                    throw new TimeoutException();

                Thread.Sleep(10);
                Application.DoEvents();
            }
        }

        public JavaScriptControl()
        {
            web.DocumentText = "<html><body></body></html>";
            bool loaded = false;
            web.DocumentCompleted += (s, e) => loaded = true;
            wait(() => loaded, 1000);
        }

        public void AddCode(string script)
        {
            var sc = web.Document.CreateElement("script");
            sc.SetAttribute("text", script);
            web.Document.Body.AppendChild(sc);
        }

        public object Eval(string expr)
        {           
            return web.Document.InvokeScript("eval", new object[] { expr });
        }

        #region IDisposable Support
        private bool disposedValue = false; // 重複する呼び出しを検出するには

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: マネージ状態を破棄します (マネージ オブジェクト)。
                    web.Dispose();
                }

                // TODO: アンマネージ リソース (アンマネージ オブジェクト) を解放し、下のファイナライザーをオーバーライドします。
                // TODO: 大きなフィールドを null に設定します。

                disposedValue = true;
            }
        }

        // TODO: 上の Dispose(bool disposing) にアンマネージ リソースを解放するコードが含まれる場合にのみ、ファイナライザーをオーバーライドします。
        // ~JavaScriptControl() {
        //   // このコードを変更しないでください。クリーンアップ コードを上の Dispose(bool disposing) に記述します。
        //   Dispose(false);
        // }

        // このコードは、破棄可能なパターンを正しく実装できるように追加されました。
        public void Dispose()
        {
            // このコードを変更しないでください。クリーンアップ コードを上の Dispose(bool disposing) に記述します。
            Dispose(true);
            // TODO: 上のファイナライザーがオーバーライドされる場合は、次の行のコメントを解除してください。
            // GC.SuppressFinalize(this);
        }
        #endregion
    }

}
