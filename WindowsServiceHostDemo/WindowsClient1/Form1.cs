﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathServiceLibrary;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace WindowsClient1
{
    public partial class Form1 : Form
    {
       
        private IMathService nettcpChannel = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          


            nettcpChannel = new ChannelFactory<
              MathServiceLibrary.IMathService>
              ("MathService_netTcp").CreateChannel();
        }

       

       

       

        private void button5_Click(object sender, EventArgs e)
        {
            MyNumbers obj = new MyNumbers();
            obj.Number1 = Convert.ToInt32(textBox1.Text);
            obj.Number2 = Convert.ToInt32(textBox2.Text);

            textBox3.Text = nettcpChannel.Add(obj).ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MyNumbers obj = new MyNumbers();
            obj.Number1 = Convert.ToInt32(textBox1.Text);
            obj.Number2 = Convert.ToInt32(textBox2.Text);

            textBox3.Text = nettcpChannel.Subtract(obj).ToString();
        }
    }
}
