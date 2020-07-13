using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;
namespace MathServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class MathService : IMathService
    {
        public int Add(MyNumbers obj)
        {
            return (obj.Number1 + obj.Number2);
        }

        public int Subtract(MyNumbers obj)
        {
            return (obj.Number1 - obj.Number2);
        }

        public void SignIn(string UserName)
        {
            System.Threading.Thread.Sleep(5000);
            var str = new StringWriter();
            str.WriteLine(
              "{0} has loaded the form at {1:t}",
              UserName, DateTime.Now.ToString("hh:mm:ss"));

            File.AppendAllText(@"D:\cv\UserLog.txt",
              str.ToString());
        }

        public void SignOut(string UserName)
        {
            System.Threading.Thread.Sleep(5000);
            var str = new StringWriter();
            str.WriteLine(
              "{0} has closed the form at {1:t}",
              UserName, DateTime.Now.ToString("hh:mm:ss"));

            File.AppendAllText(@"D:\cv\UserLog.txt",
              str.ToString());
        }

        public void StartPrintingLogFiles(string message)
        {
            IMathServiceCallback MScallback =
               OperationContext.Current.GetCallbackChannel<
               IMathServiceCallback>();

            //Printing code comes here.

            System.Threading.Thread.Sleep(new TimeSpan(0, 0, 5));
            MScallback.NotifyClientWhenPrintingIsDone(message);

        }


    }
}
