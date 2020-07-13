using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace ProductsServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.

    [ServiceBehavior(
ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class ProductsService : IProducts
    {
        public void AddCategory(string CategoryName)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            int CategoryID = 0;
            int Counter = 0;
            SqlParameter p1 = null;
            try
            {
                Console.WriteLine("Start Time {0:T} Thread ID : {1}", DateTime.Now, Thread.CurrentThread.ManagedThreadId.ToString());
                System.Threading.Thread.Sleep(
                  new TimeSpan(0, 0, 5));



                cn = new SqlConnection();
                cn.ConnectionString = @"data source=.\sqlexpress;initial catalog=transactiondemo;integrated security=true;";
                cmd = new SqlCommand();
                cmd.Connection = cn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_Categories_Insert";

                cmd.Parameters.Add(new SqlParameter("@CategoryName", @CategoryName));

                p1 = new SqlParameter("@CategoryID", SqlDbType.Int);
                p1.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(p1);


                cn.Open();
                Counter = cmd.ExecuteNonQuery();

                CategoryID = Convert.ToInt32(p1.Value.ToString());

                Console.WriteLine(String.Format(
             "Category {0} has been added successfully by the thread {1} at {2:T}", CategoryName, Thread.CurrentThread.ManagedThreadId.ToString(), DateTime.Now));


            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
            finally
            {
                if (cn != null)
                {
                    cn.Close();
                    cn.Dispose();
                    cn = null;
                }
            }
        }
    }
}
