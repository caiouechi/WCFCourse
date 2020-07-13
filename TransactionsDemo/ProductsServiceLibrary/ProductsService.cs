using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ProductsServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(
     InstanceContextMode = InstanceContextMode.PerSession,
     TransactionAutoCompleteOnSessionClose = true,
     TransactionIsolationLevel =
       System.Transactions.IsolationLevel.Serializable)]
    public class ProductsService : IProducts
    {
        int CategoryID = 0;

        [OperationBehavior(TransactionScopeRequired = true,
           TransactionAutoComplete = false)]
        public void AddCategory(string CategoryName)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            //int CategoryID = 0;
            int Counter = 0;
            SqlParameter p1 = null;
            try
            {
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


            }
            catch(Exception ex)
            {
                throw new FaultException(ex.Message);
            }
            finally
            {
                if(cn != null)
                {
                    cn.Close();
                    cn.Dispose();
                    cn = null;
                }
            }
           // return (CategoryID);
        }


        [OperationBehavior(TransactionScopeRequired = true,
            TransactionAutoComplete = false)]
        public int AddProducts()
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            int Counter = 0;
            try
            {
                cn = new SqlConnection();
                cn.ConnectionString = @"data source=.\sqlexpress;initial catalog=transactiondemo;integrated security=true;";
                cmd = new SqlCommand();
                cmd.Connection = cn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_Products_Insert";

                cmd.Parameters.Add(new SqlParameter("@CategoryID", CategoryID));
                cn.Open();
                Counter = cmd.ExecuteNonQuery();


            }
            catch(Exception ex)
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
            return (Counter);
        }
    }
}
