using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsClient.MathServiceReference;

namespace WinFormsClient
{
    public partial class Form1 : Form
    {
        MathServiceReference.MathServiceClient proxy=new MathServiceReference.MathServiceClient();
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                MathServiceReference.MyNumbers obj = new MathServiceReference.MyNumbers();
                obj.Number1 = Convert.ToInt32(textBox1.Text);
                obj.Number2 = Convert.ToInt32(textBox2.Text);

                textBox3.Text = proxy.Divide(obj).ToString();
            }
            //catch(System.DivideByZeroException dbze)
            //{
            //    MessageBox.Show(dbze.Message);
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //catch (FaultException faultException)
            //{
            //    MessageBox.Show(faultException.Message + "\n\n" + "Try again!.", "Division problem");
            //}

            //catch (FaultException fex)
            //{
            //    switch (fex.Code.Name)
            //    {
            //        case "BValueIsZero":
            //            MessageBox.Show(
            //              fex.Message + "\n\n" +
            //              "Try again!.", "Division problem");
            //            break;
            //        case "BValueIsAboveHundred":
            //            MessageBox.Show(
            //              fex.Message + "\n\n" +
            //              "Try again!.", "MaxValue problem");
            //            break;
            //        default:
            //            MessageBox.Show(
            //              fex.Message, "Error");
            //            break;
            //    }
            //}

            catch (FaultException<DivisionFault> fex)
            {
                MessageBox.Show(String.Format("{0}\n\n" +
                  "The following error occurred in {1}:\n{2}",
                  fex.Detail.Reason,
                  fex.Detail.Method,
                  fex.Detail.Message),
                  "Division problem");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                MathServiceReference.MyNumbers obj = new MathServiceReference.MyNumbers();
                obj.Number1 = Convert.ToInt32(textBox1.Text);
                obj.Number2 = Convert.ToInt32(textBox2.Text);

                proxy.DivideInOneWay(obj);
            }
            catch (System.DivideByZeroException dbze)
            {
                MessageBox.Show(dbze.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
