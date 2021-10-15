using System;
using System.Collections.Generic;
using System.Text;
using Week4.NaimaElKhattabi.CORE.Interfaces;
using Week4.NaimaElKhattabi.CORE.Models;

namespace Week4.NaimaElKhattabi.CORE.BusinessLayer
{
    public class MainBL : IMainBL
    {
        private readonly IOrderRepository orderRepo;
        private readonly ICustomerRepository customerRepo;

        public MainBL(IOrderRepository orderRepo, ICustomerRepository customerRepo)
        {
            this.orderRepo = orderRepo;
            this.customerRepo = customerRepo;
        }

        #region Customers
        //Metodi per i clienti 
        public List<Customer> FetchCustomers()
        {
            return customerRepo.FetchAll();
        }

        public bool CreateCustomer(Customer newCustomer)
        {
            if (newCustomer == null)
                return false;

            return customerRepo.Add(newCustomer);
        }
        public bool EditCustomer(Customer editedCustomer)
        {
            if (editedCustomer == null)
                return false;

            return customerRepo.Update(editedCustomer);
        }

        public bool DeleteCustomer(Customer customerToBeDeleted)
        {
            Customer customerToDelete = customerRepo.GetById(customerToBeDeleted.Id);

            if (customerToDelete != null)
            {
                bool isDeleted = customerRepo.Delete(customerToBeDeleted);
                return isDeleted;
            }
            return false;
        }

        public Customer GetCustomerById(int id)
        {
            if (id <= 0)
                return null;

            return customerRepo.GetById(id);
        }
        #endregion

        #region Orders
        //Metodi per gli ordini
        public bool CreateOrder(Order newOrder)
        {
            if (newOrder == null)
                return false;

            return orderRepo.Add(newOrder);
        }

        public bool DeleteOrder(Order orderToBeDeleted)
        {
            Order orderToDelete = orderRepo.GetById(orderToBeDeleted.Id);

            if(orderToDelete != null)
            {
                bool isDeleted = orderRepo.Delete(orderToBeDeleted);
                return isDeleted;
            }
            return false;
        }
        public bool EditOrder(Order editedOrder)
        {
            if (editedOrder == null)
                return false;

            return orderRepo.Update(editedOrder);
        }

        public List<Order> FetchOrders()
        {
            return orderRepo.FetchAll();
        }

        public Order GetOrderById(int id)
        {
            if (id <= 0)
                return null;

            return orderRepo.GetById(id);
        }



        #endregion
    }
}
