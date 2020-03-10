using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;

namespace VisaCom
{
    /// <summary>
    /// TekVISANet.dllは、TekVISAのインストール時にインストールされ、
    /// パスC：\ Windows \ assemblyにあります
    /// さらにGAC_32またはGAC_64のいずれかにサブフォルダーに移動すると、.dllが表示されます）。
    /// エクスプローラーからはなぜかフォルダが見えない　VisualStudioの参照からだとGAC_32またはGAC_64が見える
    /// プラットフォームターゲットはTekVISAとあわせておくこと　今回は64bit使用
    /// 
    /// 追記
    /// windows10　使用時は32bitで使用すること　下記　サイトにて32bitしか使えないことが判明(Win7は使える)
    /// 結局、汎用にするには32bitにするってこと
    /// https://forum.tek.com/viewtopic.php?t=139436
    /// </summary>


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void OpenBt_Click(object sender, EventArgs e)
        {
            string stcommand = string.Format(":ch{0}:volts {1:0.00};", 1, 2.0);

            System.Collections.ArrayList instrlist;

            string response;
            bool status;

            TekVISANet.VISA TVA = new TekVISANet.VISA();

            string[] usbr = TVA.USBResources;
            string[] gpibr = TVA.GPIBResources;

            // Print list of VISA resources
            TVA.FindResources("?*", out instrlist);
            //TVA.FindResources("USB?*INSTR", out instrlist);
            //TVA.FindResources("USB::0x0699::?*INSTR", out instrlist);

            LogTb.AppendText("Visa Resources\r\n");

            // リソースを取ってくる　
            // Visaに対応している、今まで使用したことのあるリストを全て取ってくる
            // ここで取ってくるリソースはリソースマネージャーとやや違う名前になっているが
            // ちゃんと開ける　　リソースマネージャーの名前でも開ける　なぜ・・・
            for (var j = 0; j < instrlist.Count; j++)
            {
                LogTb.AppendText(j.ToString() + " : " + instrlist[j] + "\r\n");
            }


            // リソースマネージャーのVISA番号
            //TVA.Open("USB::0x0699::0x0368::C044088::INSTR");
            // プログラムから取得したVISA番号
            if(!TVA.Open("USB::0x0699::0x0368::C043781::INSTR"))
            {
                LogTb.AppendText("Open失敗　\r\n");
                return;
            }

            // Write Read テスト
            TVA.Write("*IDN?");
            status = TVA.Read(out response);
            if (!status)
            {
                LogTb.AppendText("IDN失敗　\r\n");
                return;
            }
            LogTb.AppendText(response + "\r\n");

            // クエリーテスト
            status = TVA.Query("*IDN?", out response);
            if (status)
            {
                LogTb.AppendText(response + "\r\n");
            }

            // 工場出荷状態
            if(!TVA.Write(":factory;"))
            {
                LogTb.AppendText("工場出荷設定　失敗　\r\n");
                return;
            }
            System.Threading.Thread.Sleep(2000);

            // チャンネル有効化
            if (!TVA.Write(":select:ch1 on;:select:ch2 on;"))
            {
                LogTb.AppendText("チャンネル設定　失敗　\r\n");
                return;
            }

            // Voltスケール
            if (!TVA.Write(":ch1:volts 2.0;:ch2:volts 5.0;"))
            {
                LogTb.AppendText("チャンネルスケール設定　失敗　\r\n");
                return;
            }

            // 時間スケール 250μsec
            if (!TVA.Write(":horizontal:main:scale 250e-6;"))
            {
                LogTb.AppendText("チャンネルスケール設定　失敗　\r\n");
                return;
            }

            // ヘッダOFF
            if (!TVA.Write(":header off;"))
            {
                LogTb.AppendText("チャンネルスケール設定　失敗　\r\n");
                return;
            }
            System.Threading.Thread.Sleep(2000);
            // 測定表示
            //TVA.Write(":measurement:meas1:source math;:measurement:meas1:type frequency;:measurement:meas2:source math;:measurement:meas2:type pk2pk;:measurement:meas3:source ch1;:measurement:meas3:type pk2pk;:measurement:meas4:source ch2;:measurement:meas4:type pk2pk;:measurement:meas5:source ch1;:measurement:meas5:type frequency;:measurement:meas6:source ch2;:measurement:meas6:type frequency;");
            if(!TVA.Write(":measurement:meas1:source ch1;:measurement:meas1:type pk2pk;:measurement:meas2:source ch1;:measurement:meas2:type frequency;:measurement:meas3:source ch2;:measurement:meas3:type pk2pk;:measurement:meas4:source ch2;:measurement:meas4:type frequency;"))
            {
                LogTb.AppendText("測定表示　失敗　\r\n");
                return;
            }
            // 表示内容が多い場合　待ち時間を多くしないと　次のコマンドを受け付けた場合、途中でやめてしまう。
            System.Threading.Thread.Sleep(1000);

            if (!TVA.Query("*esr?", out response))
            {
                LogTb.AppendText("測定表示後　失敗　\r\n");
                return;
            }


            string MesResponse;
            TVA.Query(":measurement:meas1:value?", out MesResponse);

            if(!TVA.Query("*esr?", out response))
            {
                LogTb.AppendText("取得1　失敗　\r\n");
                return;
            }

            LogTb.AppendText("CH1 peak-peak:" + MesResponse +　"\r\n");

            TVA.Query(":measurement:meas2:value?", out MesResponse);

            if (!TVA.Query("*esr?", out response))
            {
                LogTb.AppendText("取得2　失敗　\r\n");
                return;
            }

            LogTb.AppendText("CH1 freq:" + MesResponse + "\r\n");

            TVA.Query(":measurement:meas3:value?", out MesResponse);

            if (!TVA.Query("*esr?", out response))
            {
                LogTb.AppendText("取得3　失敗　\r\n");
                return;
            }

            LogTb.AppendText("CH2 peak-peak:" + MesResponse + "\r\n");

            TVA.Query(":measurement:meas4:value?", out MesResponse);

            if (!TVA.Query("*esr?", out response))
            {
                LogTb.AppendText("取得4　失敗　\r\n");
                return;
            }

            LogTb.AppendText("CH2 freq:" + MesResponse + "\r\n");


            TVA.Close();
        }
    }
}
