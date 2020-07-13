using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProductsServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IProducts
    {
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Mandatory)]
        void AddCategory(string CategoryName);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Mandatory)]
        int AddProducts();
    }

    
}
