using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCvSample.Utils
{
    /// <summary>
    /// Enum要素名設定クラス　多言語対応
    /// http://ikorin2.hatenablog.jp/entry/2019/02/05/182257
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class EnumDisplayNameAttribute : Attribute
    {
        private Type _resourceType;

        private string _resource;

        /// <summary>enum表示名属性</summary>
        /// <param name="name">表示名</param>
        public EnumDisplayNameAttribute(string name)
        {
            Name = name;
        }

        /// <summary>enum表示名属性</summary>
        public EnumDisplayNameAttribute()
        {
            // コンストラクタ
        }

        /// <summary>表示名</summary>
        public string Name { get; set; }

        /// <summary>リソース名</summary>
        public string Resource
        {
            get
            {
                return _resource;
            }

            set
            {
                _resource = value;
                SetNameFromResource();
            }
        }

        /// <summary>リソースの型</summary>
        public Type ResourceType
        {
            get
            {
                return _resourceType;
            }

            set
            {
                _resourceType = value;
                SetNameFromResource();
            }
        }

        /// <summary>リソース型とリソース名から表示名をセットします</summary>
        private void SetNameFromResource()
        {
            if (_resourceType == null || _resource == null) { return; }
            var propertyInfo = _resourceType.GetProperty(_resource);
            Name = propertyInfo?.GetValue(_resourceType) as string;
        }
    }
}
