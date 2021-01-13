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
            label1.Text = "label1";
            label2.Text = "label2";
            label3.Text = "label3";
            Run();
        }
        
        private async void Run()
        {
            var task1 = Task.Run(() => IntCalAsync(10));
            var task2 = Task.Run(() => VoidCalAsync(2)); 

            int sum = await task1;

            label1.Text = "Sum = " + sum;
            button1.Enabled = true; // don't know why exists
        }

        private int IntCalAsync(int times)
        {
            int result = 0;
            for (int i=0; i<times; i++)
            {
                result += i;
                Thread.Sleep(1000); // wait for 10seconds and resume
                //Task.Delay(1000); // don't know why
            }
            return result;
        }

        private void VoidCalAsync(int times)
        {
            int result = 0;
            for (int i=0;i<times;i++)
            {
                result += i;
                Thread.Sleep(1000);
            }
            label2.Text = result.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (label3.Text == "a") label3.Text = "b";
            else label3.Text = "a";
        }
    }
}
