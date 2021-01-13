using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace AsyncTest1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Run();
        }
        
        private async void Run()
        {
            var task1 = Task.Run(() => LongCalAsync(10));

            await task1;

            button1.Enabled = true; // don't know why exists
        }

        private void LongCalAsync(int times)
        {
            int result = 0;
            for (int i=0; i<times; i++)
            {
                result += i;
                Thread.Sleep(1000); // wait for 10seconds and resume
                //Task.Delay(1000); // 
            }
            label3.Text = result.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (label2.Text == "a") label2.Text = "b";
            else label2.Text = "a";
        }
    }
}
