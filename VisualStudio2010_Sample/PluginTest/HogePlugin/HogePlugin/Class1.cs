using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HogePlugin
{
    public interface IHogePlugin
    {
        string Name { get; }        // 名前
        string GetComment();        // コメントを取得
    }
}
