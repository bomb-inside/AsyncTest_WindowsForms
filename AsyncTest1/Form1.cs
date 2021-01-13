﻿using System;
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

            label3.Text = "진행중!";

            int sum = await task1;

            label1.Text = "Sum = " + sum;
            button1.Enabled = true;
        }

        private int LongCalAsync(int times)
        {
            int result = 0;
            for (int i=0; i<times; i++)
            {
                result += i;
                Thread.Sleep(1000);
                //Task.Delay(1000);
            }
            return result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (label2.Text == "a") label2.Text = "b";
            else label2.Text = "a";
        }
    }
}