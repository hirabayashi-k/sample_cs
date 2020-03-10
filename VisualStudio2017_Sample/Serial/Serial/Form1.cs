using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //! 利用可能なシリアルポート名の配列を取得する.
            string[] PortList = SerialPort.GetPortNames();
            // ポートネームを取得する
            serialPort1.PortName = PortList[0];
            serialPort1.BaudRate = 9600;
            serialPort1.Parity = 0;
            serialPort1.DataBits = 8;
            serialPort1.StopBits = (StopBits)1;
            serialPort1.Handshake = Handshake.None;

            serialPort1.WriteTimeout = 100;

            serialPort1.Encoding = Encoding.UTF8;

            Send.Enabled = false;


        }


        private void Conect_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Open();
                Conect.Enabled = false;
                Send.Enabled = true;

                LogRich.AppendText("Open:" + serialPort1.PortName + "\n");
            }
            catch (Exception ex)
            {
                LogRich.AppendText("エラー:" + ex.Message + "\n");
            }
        }

        private void Send_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Write(Command.Text);

                LogRich.AppendText("Send:" + Command.Text + "\n");

            } catch(Exception ex)
            {
                LogRich.AppendText("エラー:" + ex.Message + "\n");
            }


        }

        private void DisConect_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();

                Conect.Enabled = true;
                Send.Enabled = false;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string text;
            text = serialPort1.ReadExisting();

            this.Invoke(new Action(() =>
            {
                LogRich.AppendText("受信:" + text + "\n");
            }));
        }
    }
}
