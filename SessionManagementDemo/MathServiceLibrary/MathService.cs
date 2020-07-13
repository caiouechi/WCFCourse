using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MathServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class MathService : IMathService
    {
        int Counter;

        public int Add(MyNumbers obj)
        {
            Counter++;
            return (obj.Number1 + obj.Number2);
        }

        public int GetCounter()
        {
            return (Counter);
        }

        public int Subtract(MyNumbers obj)
        {
            Counter++;
            return (obj.Number1 - obj.Number2);
        }
    }
}
