﻿using System;
using System.Collections.Generic;
using System.Text;
using Week4.NaimaElKhattabi.CORE.Models;

namespace Week4.NaimaElKhattabi.CORE.Interfaces
{
    public interface IMainBL
    {
        #region Orders
        //Metodi per gli ordini
        List<Order> FetchOrders();
        bool CreateOrder(Order newOrder);
        bool EditOrder(Order editedOrder);
        bool DeleteOrder(Order orderToBeDeleted);

        Order GetOrderById(int id);

        #endregion

        #region Customers
        //Metodi per i clienti
        List<Customer> FetchCustomers();
        bool CreateCustomer(Customer newCustomer);
        bool EditCustomer(Customer editedCustomer);
        bool DeleteCustomer(Customer customerToBeDeleted);

        Customer GetCustomerById(int id);
        #endregion
    }
}
