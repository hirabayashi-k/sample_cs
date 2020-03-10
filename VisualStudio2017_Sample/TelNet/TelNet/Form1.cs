using PrimS.Telnet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TelNet
{
    public partial class Form1 : Form
    {

        Client client;

        public Form1()
        {
            InitializeComponent();
        }


        private async void ConectBt_Click(object sender, EventArgs e)
        {
            client = new Client("192.168.1.1", 23, new System.Threading.CancellationToken());

            while (true)
            {
                string s = await client.ReadAsync(TimeSpan.FromMilliseconds(1));
                if (!s.Equals(""))
                {
                    Console_ListBox.Items.Add(s);
                    int itemsPerPage = Console_ListBox.Height / Console_ListBox.ItemHeight;
                    Console_ListBox.TopIndex = Console_ListBox.Items.Count - itemsPerPage;
                }

            }
        }

        private void SendBt_Click(object sender, EventArgs e)
        {

            using (var client = new Client("192.168.1.1", 23, new System.Threading.CancellationToken()))
            {
                if (client.IsConnected)
                {
                    //var s = new StringBuilder();
                    //s.Append("Datum: " + DateTime.Now.ToShortDateString() + "\n");
                    //s.Append("Uhrzeit: " + DateTime.Now.ToLongTimeString() + "\n");
                    //s.Append("Status: " + "EIN" + "\n");
                    //s.Append("Meldung: " + "Ich bin eine einfache Meldung" + "\n");
                    //s.Append("55A2A7A9");
                    client.Write(SendBt.Text + "\r\n");
                }
            }

        }
    }
}
