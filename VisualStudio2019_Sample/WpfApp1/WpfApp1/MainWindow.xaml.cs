using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        enum VoltCommand
        {
            TP1 = 16,   //12V_HDR
            TP14 = 17,  //12V
            TP15 = 18,  //LD12V
            TP3 = 19,   //1.0V
            TP4 = 20,   //P1.0V
            TP5 = 21,   //1.5V
            TP6 = 22,   //1.8V
            TP7 = 23,   //2.5V
            TP8 = 24,   //3.3V
            TP9 = 25,   //5V
            TP10 = 26,  //DDR3_VTT
            TP11 = 27,  //MIO_VREF
            TP601 = 28, //PD12V
            TP605 = 29, //PD5V
            TP607 = 30, //PDnOUT
            TP101_A1 = 32,  //LD1P1
            TP102_B1 = 33,  //LD1P2
            TP103_C1 = 34,  //LD1P3
            TP101_A2 = 35,  //LD2P1
            TP102_B2 = 36,  //LD2P2
            TP103_C2 = 37,  //LD2P3
            TP101_A3 = 38,  //LD3P1
            TP102_B3 = 39,  //LD3P2
            TP103_C3 = 40,  //LD3P3
            TP101_A4 = 41,  //LD4P1
            TP102_B4 = 42,  //LD4P2
            TP103_C4 = 43,  //LD4P3
            TP101_A5 = 44,  //LD5P1
            TP102_B5 = 45,  //LD5P2
            TP103_C5 = 46,  //LD5P3
            TP111_J1 = 48,  //IF1_OUT
            TP112_J1 = 49,  //VF1_OUT
            TP111_J2 = 50,  //IF2_OUT
            TP112_J2 = 51,  //VF2_OUT
            TP111_J3 = 52,  //IF3_OUT
            TP112_J3 = 53,  //VF3_OUT
            TP111_J4 = 54,  //IF4_OUT
            TP112_J4 = 55,  //VF4_OUT
            TP111_J5 = 56,  //IF5_OUT
            TP112_J5 = 57 	//VF5_OUT
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Test_Click(object sender, RoutedEventArgs e)
        {
            byte TestCommand = 16;

            byte intCommand = (byte)TestCommand;

            int A0 = intCommand & 0x01;
            int A1 = intCommand & 0x02 >> 1;
            int A2 = intCommand & 0x04 >> 2;
            int A3 = intCommand & 0x08 >> 3;
            int MultiplexerNo = (intCommand & 0x30) >> 4;

            // マルチプレクサの選択 O-91～O-93
            byte root = 0x00;

            if (MultiplexerNo == 1)
            {
                root = (byte)(root | 0x02);
            }
            else if (MultiplexerNo == 2)
            {
                root = (byte)(root | 0x04);

            }
            else if (MultiplexerNo == 3)
            {
                root = (byte)(root | 0x08);
            }
            else
            {

            }

            // ルートの選択 O-94～O-97
            root = root = (byte)(root | A0 >> 5);
            root = root = (byte)(root | A1 >> 6);
            root = root = (byte)(root | A2 >> 7);
            root = root = (byte)(root | A3 >> 8);

            MessageBox.Show("");

        }
    }
}
