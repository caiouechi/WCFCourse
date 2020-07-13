using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathServiceLibrary;
using CalcServiceLibrary;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var servicehost2 = new ServiceHost(
           typeof(CalcService));

            ServiceEndpoint BasicHttpEndPoint2 = servicehost2.AddServiceEndpoint(
               typeof(ICalcService),
               new BasicHttpBinding(),
               "http://localhost:5555/CalcService");

            servicehost2.Open();

            using (var servicehost = new ServiceHost(
           typeof(MathService)))
            {

                ServiceEndpoint BasicHttpEndPoint1 = servicehost.AddServiceEndpoint(
                  typeof(IMathService),
                  new BasicHttpBinding(),
                  "http://localhost:4444/MathService");              


                servicehost.Open();

               

                foreach (ServiceEndpoint endpoint in servicehost.Description.Endpoints)
                {
                    Console.WriteLine("Host 1 Details : Address : {0} Binding Name : {1}",
                      endpoint.Address.ToString(), endpoint.Binding.Name);
                }

                foreach (ServiceEndpoint endpoint in servicehost2.Description.Endpoints)
                {
                    Console.WriteLine("Host 2 Details : Address : {0} Binding Name : {1}",
                      endpoint.Address.ToString(), endpoint.Binding.Name);
                }

                Console.WriteLine();
                Console.WriteLine("Press any key to stop your WCF Math service.");
                Console.ReadKey();


                servicehost.Close();
                servicehost2.Close();
            }
           
           


           
            
        }
    }
}