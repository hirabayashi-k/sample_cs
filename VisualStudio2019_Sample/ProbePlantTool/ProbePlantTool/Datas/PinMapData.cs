using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Takt.ProbePlantTool.Datas
{
    /// <summary>
    /// ピンマップデータ
    /// </summary>
    public class PinMapData
    {
        #region Fields
        #endregion

        #region Constructors Finalizers (Destructors)

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PinMapData()
        {
            Name = string.Empty;
            PinPloatAdress = string.Empty;
            XAdress = -1;
            YAdress = -1;
        }
        #endregion

        #region Delegates

        #endregion

        #region Events

        #endregion

        #region Enums

        #endregion

        #region Interfaces
        #endregion

        #region Properties

        /// <summary>
        /// ピン名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ピンアドレス名
        /// </summary>
        public string PinPloatAdress { get; set; }

        /// <summary>
        /// Xアドレス
        /// </summary>
        public int XAdress { get; set; }

        /// <summary>
        /// Yアドレス
        /// </summary>
        public int YAdress { get; set; }

        /// <summary>
        /// サイド　AorB
        /// </summary>
        public string Side { get; set; }

        #endregion

        #region Indexers

        #endregion

        #region Methods

        #endregion

        #region Structs

        #endregion

        #region Classes

        #endregion
    }
}
