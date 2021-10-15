using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Week4.NaimaElKhattabi.CORE.Models;

namespace Week4.NaimaElKhattabi.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ICustomerService
    {
        [OperationContract]
        List<Customer> GetAllCustomers();

        [OperationContract]
        Customer GetCustomerById(int id);

        [OperationContract]
        bool AddCustomer(Customer newCustomer);

        [OperationContract]
        bool UpdateCustomer(Customer updatedCustomer);

        [OperationContract]
        bool DeleteCustomerById(int id);
    }

    
}
