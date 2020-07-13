using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using ProductsServiceLibrary;

namespace SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(
             typeof(ProductsService)))
            {

                host.Open();

                Console.WriteLine(
                  "Your WCF service is running and is listening on:");
                foreach (ServiceEndpoint endpoint in
                 host.Description.Endpoints)
                {
                    Console.WriteLine("{0} ({1})",
                      endpoint.Address.ToString(), endpoint.Binding.Name);
                }
                Console.WriteLine();
                Console.WriteLine("Press any key to stop the service.");
                Console.ReadKey();


                host.Close();
            }
        }
    }
}