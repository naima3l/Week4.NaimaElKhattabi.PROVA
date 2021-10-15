using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Week4.NaimaElKhattabi.CORE.Models;
using Week4.NaimaElKhattabi.EF.Configurations;


namespace Week4.NaimaElKhattabi.EF
{
    public class OrderContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public OrderContext() : base()
        {

        }
        public OrderContext(DbContextOptions<OrderContext> options)
            : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                string connectionString = @"Server = (localdb)\mssqllocaldb;
                Database = GestoreOrdiniClienti; Trusted_Connection = True;";
                options.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Order>(new OrderConfiguration());
            modelBuilder.ApplyConfiguration<Customer>(new CustomerConfiguration());
        }
    }
}
