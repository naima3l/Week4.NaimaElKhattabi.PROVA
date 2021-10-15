﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Week4.NaimaElKhattabi.CORE.Interfaces;
using Week4.NaimaElKhattabi.CORE.Models;

namespace Week4.NaimaElKhattabi.EF.Repositories
{
    public class EFCustomerRepository : ICustomerRepository
    {
        private readonly OrderContext ctx;

        public EFCustomerRepository() : this(new OrderContext())
        {

        }

        public EFCustomerRepository(OrderContext ctx)
        {
            this.ctx = ctx;
        }
        public bool Add(Customer item)
        {
            if (item == null)
                return false;

            try
            {
                ctx.Customers.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(Customer item)
        {
            try
            {
                if (item != null)
                    ctx.Customers.Remove(item);

                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Customer> FetchAll()
        {
            try
            {
                return ctx.Customers.ToList();
            }
            catch (Exception)
            {
                return new List<Customer>();
            }
        }

        public Customer GetById(int id)
        {
            if (id <= 0)
                return null;

            return ctx.Customers.Find(id);
        }

        public bool Update(Customer item)
        {
            if (item == null)
                return false;

            try
            {
                ctx.Customers.Update(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
