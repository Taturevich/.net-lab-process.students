using System;
using System.Data.Entity;
using EF_Task.Entities;

namespace EF_Task
{
    public class NorthwindContext : DbContext
    {
        public NorthwindContext() : base("Northwind")
        {
            Identity = Guid.NewGuid();
        }

        public Guid Identity { get; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<CreditCard> CreditCards { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<EmployeeTerritory> EmployeeTerritories { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetails> OrderDetails { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Shipper> Shippers { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Territory> Territories { get; set; }
    }
}
