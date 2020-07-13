using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsClient1.MathServiceReference;
using System.ServiceModel;
using System.ServiceModel.Description;


namespace WindowsClient1
{
    public partial class Form1 : Form
    {
        private MathServiceClient wsHttpproxy = null;
        private MathServiceClient netTcpProxy = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            wsHttpproxy = new MathServiceClient("WSHttpBinding_IMathService");

            netTcpProxy = new MathServiceClient("NetTcpBinding_IMathService");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyNumbers obj = new MyNumbers();
            obj.Number1 = Convert.ToInt32(textBox1.Text);
            obj.Number2 = Convert.ToInt32(textBox2.Text);

            textBox3.Text = wsHttpproxy.Add(obj).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MyNumbers obj = new MyNumbers();
            obj.Number1 = Convert.ToInt32(textBox1.Text);
            obj.Number2 = Convert.ToInt32(textBox2.Text);

            textBox3.Text = wsHttpproxy.Subtract(obj).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MyNumbers obj = new MyNumbers();
            obj.Number1 = Convert.ToInt32(textBox1.Text);
            obj.Number2 = Convert.ToInt32(textBox2.Text);

            textBox3.Text = netTcpProxy.Add(obj).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MyNumbers obj = new MyNumbers();
            obj.Number1 = Convert.ToInt32(textBox1.Text);
            obj.Number2 = Convert.ToInt32(textBox2.Text);

            textBox3.Text = netTcpProxy.Subtract(obj).ToString();
        }
    }
}
