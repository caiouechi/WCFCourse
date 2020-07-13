using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathServiceLibrary;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var servicehost = new ServiceHost(
           typeof(MathService)))
            {

              


                servicehost.Open();

                Console.WriteLine("Your WCF service is running.");
                Console.WriteLine(
                  "Your WCF Math service is running and is listening on below endpoints:");
               


                foreach (ServiceEndpoint endpoint in servicehost.Description.Endpoints)
                {
                    Console.WriteLine("Address : {0} Binding Name : {1}",
                      endpoint.Address.ToString(), endpoint.Binding.Name);
                }
                Console.WriteLine();
                Console.WriteLine("Press any key to stop your WCF Math service.");
                Console.ReadKey();


                servicehost.Close();
            }
        }
    }
}