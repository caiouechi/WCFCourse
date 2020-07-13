using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MathServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class MathService : IMathService
    {
        public int Add(MyNumbers obj)
        {
            return (obj.Number1 + obj.Number2);
        }

        public int Divide(MyNumbers obj)
        {
            int result = 0;
            try
            {

                if (obj.Number2 > 100)
                    throw new FaultException("Value of B cannot be above 100", new FaultCode("BValueIsAboveHundred"));




                result = obj.Number1 / obj.Number2;
            }
            //catch(System.DivideByZeroException dbze)
            //{
            //    throw new DivideByZeroException(dbze.Message);
            //}

            //catch (Exception ex)
            //{
            //    //throw new Exception(ex.Message);
            //    //throw new FaultException("Vaue of B cannot be zero.");
            //    if (!ex.Message.Equals("Value of B cannot be above 100"))
            //        throw new FaultException("Value of B cannot be zero", new FaultCode("BValueIsZero"));
            //    else
            //        throw new FaultException("Value of B cannot be above 100", new FaultCode("BValueIsAboveHundred"));
            //}

            catch (Exception ex)
            {
                var divisionFault = new DivisionFault();
                divisionFault.Method = "Divide";
                divisionFault.Reason =
                  "Value of B cannot be zero";
                divisionFault.Message = ex.Message;
                throw new FaultException<DivisionFault>(divisionFault);
            }

            return (result);
        }

        public void DivideInOneWay(MyNumbers obj)
        {
            int result = 0;
            try
            {
                result = obj.Number1 / obj.Number2;
            }
            catch (System.DivideByZeroException dbze)
            {
                throw new DivideByZeroException(dbze.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            //return (result);
        }

        public int Subtract(MyNumbers obj)
        {
            return (obj.Number1 - obj.Number2);
        }
    }
}
