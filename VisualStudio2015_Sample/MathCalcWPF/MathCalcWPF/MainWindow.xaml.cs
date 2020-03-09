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

namespace MathCalcWPF
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonDb_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double data = double.Parse(textValue.Text);

                textLog.Text = (20* Math.Log10(data / System.Math.Pow(10, -5))).ToString();

            }
            catch( Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void buttonG_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double data = double.Parse(textValue.Text);

                textLog.Text = (data/9.81).ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
