using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathServiceLibrary;
using CalcServiceLibrary;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace WindowsClient1
{
    public partial class Form1 : Form
    {
        private IMathService channel = null;

        private ICalcService channel2 = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var endPoint = new EndpointAddress(
       "http://localhost:4444/MathService");

            channel = ChannelFactory<IMathService>.
              CreateChannel(new BasicHttpBinding(), endPoint);

            var endPoint2 = new EndpointAddress(
      "http://localhost:5555/CalcService");

            channel2 = ChannelFactory<ICalcService>.
              CreateChannel(new BasicHttpBinding(), endPoint2);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MathServiceLibrary.MyNumbers obj = new MathServiceLibrary.MyNumbers();
            obj.Number1 = Convert.ToInt32(textBox1.Text);
            obj.Number2 = Convert.ToInt32(textBox2.Text);

            textBox3.Text = channel.Add(obj).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MathServiceLibrary.MyNumbers obj = new MathServiceLibrary.MyNumbers();
            obj.Number1 = Convert.ToInt32(textBox1.Text);
            obj.Number2 = Convert.ToInt32(textBox2.Text);

            textBox3.Text = channel.Subtract(obj).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CalcServiceLibrary.MyNumbers obj = new CalcServiceLibrary.MyNumbers();
            obj.Number1 = Convert.ToInt32(textBox1.Text);
            obj.Number2 = Convert.ToInt32(textBox2.Text);

            textBox3.Text = channel2.Multiply(obj).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CalcServiceLibrary.MyNumbers obj = new CalcServiceLibrary.MyNumbers();
            obj.Number1 = Convert.ToInt32(textBox1.Text);
            obj.Number2 = Convert.ToInt32(textBox2.Text);

            textBox3.Text = channel2.Divide(obj).ToString();
        }
    }
}
