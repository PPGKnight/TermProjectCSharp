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
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<Orders> Orders { get; set; }

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

    public class Clients
    {
        public int ID { get; set; }
        public string Full_Name { get; set; }
        public DateTime ACC_Creation { get; set; }
        public ICollection<Orders> Orders { get; set; }
    }

    public class Employees
    {
        public int ID { get; set; }
        public string Employee_Name { get; set; }
        public DateTime Employed { get; set; }
        public string Position { get; set; }
        public ICollection<Orders> Orders { get; set; }

    }

    public class Orders
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public Clients Clients { get; set; }
        public Employees Employees { get; set; }
        public int EmployeeID { get; set; }
        public string Status { get; set; }
        public DateTime Created_at { get; set; }
        public ICollection<OrderItems> OrderItems { get; set; }

    }

    public  class Products
    {
        public int ID { get; set; }
        public string Product_Name { get; set; }
        public decimal Product_Price { get; set; }
        public string Status { get; set; }
        public DateTime SellingSince { get; set; }
        public ICollection<OrderItems> OrderItems { get; set; }
    }

    public class OrderItems
    {
        public int ID { get; set; }
        public Orders Orders { get; set; }
        public Products Products { get; set; }
        public int Quantity { get; set; }
    }
}
