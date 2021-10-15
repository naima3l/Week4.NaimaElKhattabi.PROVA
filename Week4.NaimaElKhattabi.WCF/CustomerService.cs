using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Week4.NaimaElKhattabi.CORE.BusinessLayer;
using Week4.NaimaElKhattabi.CORE.Models;
using Week4.NaimaElKhattabi.EF.Repositories;

namespace Week4.NaimaElKhattabi.WCF
{
    public class CustomerService : ICustomerService
    {
        private readonly MainBL mainBusinessLayer;

        public CustomerService()
        {
            mainBusinessLayer = new MainBL(
                new EFOrderRepository(),
                new EFCustomerRepository()
            );
        }
        public bool AddCustomer(Customer newCustomer)
        {
            var result = mainBusinessLayer.CreateCustomer(newCustomer);
            return result;
        }

        public bool DeleteCustomerById(int id)
        {
            var customer = GetCustomerById(id);
            if (customer == null)
                return false;

            var result = mainBusinessLayer.DeleteCustomer(customer);
            return result;
        }

        public List<Customer> GetAllCustomers()
        {
            var result = mainBusinessLayer.FetchCustomers().ToList();
            return result;
        }

        public Customer GetCustomerById(int id)
        {
            return mainBusinessLayer.GetCustomerById(id);
        }

        public bool UpdateCustomer(Customer updatedCustomer)
        {
            return mainBusinessLayer.EditCustomer(updatedCustomer);
        }
    }
}
