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
            DbPath = System.IO.Path.Join(path,"DiceDB.db");

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
    }

    public class Employees
    {
        public int Employee_ID { get; set; }
        public string Employee_Name { get; set; }
        public DateTime Employed { get; set; }
        public string Position { get; set; }

    }
}
