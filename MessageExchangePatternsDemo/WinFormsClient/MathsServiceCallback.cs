using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WinFormsClient
{
    class MathsServiceCallback : MathServiceReference.IMathServiceCallback
    {
        public void NotifyClientWhenPrintingIsDone(string message)
        {
            System.Windows.Forms.MessageBox.Show(message);
        }
    }
}
