using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsClient
{
    public partial class Form1 : Form
    {
        //MathServiceReference.MathServiceClient proxy = new MathServiceReference.MathServiceClient();

        MathServiceReference.MathServiceClient proxy;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MathServiceReference.MyNumbers obj = new MathServiceReference.MyNumbers();
            obj.Number1 = Convert.ToInt32(textBox1.Text);
            obj.Number2 = Convert.ToInt32(textBox2.Text);

            textBox3.Text = proxy.Add(obj).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MathServiceReference.MyNumbers obj = new MathServiceReference.MyNumbers();
            obj.Number1 = Convert.ToInt32(textBox1.Text);
            obj.Number2 = Convert.ToInt32(textBox2.Text);

            textBox3.Text = proxy.Subtract(obj).ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            var callback = new MathsServiceCallback();
            var context = new InstanceContext(callback);
            proxy = new MathServiceReference.MathServiceClient(context);

            proxy.SignIn(WindowsIdentity.GetCurrent().Name);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            proxy.SignOut(WindowsIdentity.GetCurrent().Name);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            proxy.StartPrintingLogFiles("Log information has been printed successfully..");
        }
    }
}
