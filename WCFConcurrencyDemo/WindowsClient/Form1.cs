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
using WindowsClient.ProductsServiceReference;

namespace WindowsClient
{
    public partial class Form1 : Form
    {
        private ProductsClient proxy = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 1; i <= 5; i++)
                {

                    proxy.AddCategory("Electronic Products " + i.ToString());

                    System.Threading.Thread.Sleep(new TimeSpan(0, 0, 2));
                }
            }
            catch (FaultException fex)
            {
                MessageBox.Show(fex.Message + "\n\n" +
               "Categories could not be added..");

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            proxy = new ProductsClient("ProductsService_Tcp");
        }
    }
}
