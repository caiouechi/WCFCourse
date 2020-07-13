using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformsClient
{
    public partial class Form1 : Form
    {
        MathServiceReference.MathServiceClient obj = new MathServiceReference.MathServiceClient();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MathServiceReference.MyNumbers o1 = new MathServiceReference.MyNumbers();

            o1.Number1 = Convert.ToInt32(textBox1.Text);
            o1.Number2  = Convert.ToInt32(textBox2.Text);

            int c = obj.Add(o1);

            textBox3.Text = c.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MathServiceReference.MyNumbers o1 = new MathServiceReference.MyNumbers();

            o1.Number1 = Convert.ToInt32(textBox1.Text);
            o1.Number2 = Convert.ToInt32(textBox2.Text);

            int c = obj.Subtract(o1);

            textBox3.Text = c.ToString();
        }
    }
}
