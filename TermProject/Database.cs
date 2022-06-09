using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermProject
{
    public class DiceShopContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }

        public string DbPath { get; }

        public DiceShopContext()
        {
            var DiceDB = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(DiceDB);
            DbPath = System.IO.Path.Join(path,"Database\\DiceDB.db");

        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            Console.WriteLine(DbPath);
            dbContextOptionsBuilder.UseSqlite($"DataSource ={DbPath}");
        }
        
    }

    public class Client
    {
        public int ID { get; set; }
        public string Full_Name { get; set; }
        public DateTime ACC_Creation { get; set; }
        public ICollection<Order> Orders { get; set; }
    }

    public class Employee
    {
        public int ID { get; set; }
        public string Employee_Name { get; set; }
        public DateTime Employed { get; set; }
        public string Position { get; set; }
        public ICollection<Order> Orders { get; set; }

    }

    public class Order
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public int EmployeeID { get; set; }
        public string Status { get; set; }
        public DateTime Created_at { get; set; }
        public Client Client { get; set; }
        public Employee Employee { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

    }

    public  class Product
    {
        public int ID { get; set; }
        public string Product_Name { get; set; }
        public decimal Product_Price { get; set; }
        public string Status { get; set; }
        public DateTime SellingSince { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }

    public class OrderItem
    {
        public int ID { get; set; }
        public Order Orders { get; set; }
        public Product Products { get; set; }
        public int Quantity { get; set; }
    }
}
