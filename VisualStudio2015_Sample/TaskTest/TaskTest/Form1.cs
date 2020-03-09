using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskTest
{
    public partial class Form1 : Form
    {
        Task task;

        bool testflg = false;

        public Form1()
        {
            InitializeComponent();

            task = TempHumTask();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            task = TempHumTask();
            task.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            testflg = false;

            if(task.Status == TaskStatus.Running)
            {
                task.Wait();

            }
            textBox1.AppendText("End\r\n");
        }

        private Task TempHumTask()
        {
            Task task = new Task(() =>
            {
                TempHumMonitorWakeUp();
            });

            return task;
        }

        public void TempHumMonitorWakeUp()
        {
            testflg = true;
            while (testflg)
            {
                this.Invoke(new Action(() =>
                {
                    // サイクル表示
                    textBox1.AppendText("TEST\r\n");
                }));
                System.Threading.Thread.Sleep(1000);  // 停止待ち
            }
        }

    }
}
