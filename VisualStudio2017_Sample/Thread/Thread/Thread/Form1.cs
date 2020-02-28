using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Thread
{
    public partial class Form1 : Form
    {
        bool RedLoop = false;
        bool YellowLoop = false;
        bool BlueLoop = false;


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                StartRedPanel();
            });

            Task.Run(() =>
            {
                StartYellowPanel();
            });

            Task.Run(() =>
            {
                StartBluePanel();
            });

            button1.Enabled = false;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            RedLoop = false;
            YellowLoop = false;
            BlueLoop = false;

            button1.Enabled = true;
        }

        public void StartRedPanel()
        {
            RedLoop = true;

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            while (RedLoop)
            {

                if(panel1.BackColor == Color.Red)
                {
                    panel1.BackColor = Color.DarkGray;
                } else
                {
                    panel1.BackColor = Color.Red;
                }

                this.Invoke(new Action(() =>
                {
                    textBox1.Text = sw.ElapsedMilliseconds.ToString();
                }));


                sw.Reset();
                sw.Start();
                System.Threading.Thread.Sleep(800);
            }

        }

        public void StartYellowPanel()
        {
            YellowLoop = true;

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            while (YellowLoop)
            {
                if (panel3.BackColor == Color.Yellow)
                {
                    panel3.BackColor = Color.DarkGray;
                }
                else
                {
                    panel3.BackColor = Color.Yellow;
                }
                this.Invoke(new Action(() =>
                {
                    textBox2.Text = sw.ElapsedMilliseconds.ToString();
                }));


                sw.Reset();
                sw.Start();
                System.Threading.Thread.Sleep(400);
            }

        }

        public void StartBluePanel()
        {
            BlueLoop = true;
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            while (BlueLoop)
            {
                if (panel2.BackColor == Color.Blue)
                {
                    panel2.BackColor = Color.DarkGray;
                }
                else
                {
                    panel2.BackColor = Color.Blue;
                }

                this.Invoke(new Action(() =>
                {
                    textBox3.Text = sw.ElapsedMilliseconds.ToString();
                }));


                sw.Reset();
                sw.Start();
                System.Threading.Thread.Sleep(200);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                StartRedPanel2();
            });
        }


        public void StartRedPanel2()
        {
            RedLoop = true;
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            if (!YellowLoop)
            {
                Task.Run(() =>
                {
                    StartYellowPanel2();
                });
            }
            sw.Start();
            while (RedLoop)
            {

                if (panel1.BackColor == Color.Red)
                {
                    panel1.BackColor = Color.DarkGray;
                }
                else
                {
                    panel1.BackColor = Color.Red;
                }

                this.Invoke(new Action(() =>
                {
                    textBox1.Text = sw.ElapsedMilliseconds.ToString();
                }));


                sw.Reset();
                sw.Start();
                System.Threading.Thread.Sleep(800);
            }

        }

        public void StartYellowPanel2()
        {
            YellowLoop = true;
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            if (!BlueLoop)
            {
                Task.Run(() =>
                {
                    StartBluePanel2();
                });
            }


            sw.Start();
            while (YellowLoop)
            {
                if (panel3.BackColor == Color.Yellow)
                {
                    panel3.BackColor = Color.DarkGray;
                }
                else
                {
                    panel3.BackColor = Color.Yellow;
                }

                this.Invoke(new Action(() =>
                {
                    textBox2.Text = sw.ElapsedMilliseconds.ToString();
                }));

                sw.Reset();
                sw.Start();
                System.Threading.Thread.Sleep(400);
            }

        }

        public void StartBluePanel2()
        {
            BlueLoop = true;
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            sw.Start();
            while (BlueLoop)
            {

                if (panel2.BackColor == Color.Blue)
                {
                    panel2.BackColor = Color.DarkGray;
                }
                else
                {
                    panel2.BackColor = Color.Blue;
                }

                this.Invoke(new Action(() =>
                {
                    textBox3.Text = sw.ElapsedMilliseconds.ToString();
                }));
                sw.Reset();
                sw.Start();

                System.Threading.Thread.Sleep(200);
            }

        }


    }
}
