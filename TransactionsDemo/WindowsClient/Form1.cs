using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using WindowsClient.ProductsServiceReference;
namespace WindowsClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int CategoryID = 0;
            int Counter = 0;

            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    ProductsClient proxy = new ProductsClient();
                    //CategoryID = proxy.AddCategory("Electronic Products");

                    proxy.AddCategory("Electronic Products");

                    //Counter = proxy.AddProducts(CategoryID);
                    Counter = proxy.AddProducts();

                    MessageBox.Show("Number of Products inserted are : " + Counter.ToString());

                    proxy.Close();
                    ts.Complete();
                    
                }
            }
            catch(FaultException fex)
            {
                MessageBox.Show(fex.Message + "\n\n" +
               "Products could not be added..");
                
            }
        }
    }
}
