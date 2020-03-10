using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoundSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sound ss = new Sound();
            ss.StopSound();
            ss.PlaySound(@"E:\sample_cs\VisualStudio2017_Sample\音声再生\SoundSample\SoundSample\bin\Debug\big-city1.mp3");

       }

        private void button2_Click(object sender, EventArgs e)
        {
            Sound ss = new Sound();

            ss.StopSound();
        }
    }
}
