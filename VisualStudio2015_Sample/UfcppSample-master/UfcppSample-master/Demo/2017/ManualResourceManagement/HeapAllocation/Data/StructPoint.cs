﻿namespace HeapAllocation.Data
{
    /// <summary>
    /// int 2個程度のデータ構造なら、普通は構造体で作るよね、というもの。
    /// 参考実装用。
    /// </summary>
    struct StructPoint
    {
        public int X;
        public int Y;
        public StructPoint(int x, int y) => (X, Y) = (x, y);
    }
}
