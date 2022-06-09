using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TermProject
{
    public class Lists
    { 
        public static List<Orders> GetOrders()
        {
            var list = new List<Orders>();

            using var DiceBag = new DiceShopContext();
            foreach (var order in DiceBag.Orders)
            {
                foreach (var client in DiceBag.Clients)
                {
                    if (client.ID == order.ClientID)
                    {
                        order.Clients.Full_Name = client.Full_Name;
                    }
                }
                foreach (var employe in DiceBag.Employees)
                {
                    if (employe.ID == order.EmployeeID)
                    {
                        order.Employees.Employee_Name = employe.Employee_Name;
                    }
                }
                list.Add(order);
            }
            return list;
        }
        public static List<Clients> GetClients()
        {
            var list = new List<Clients>();
            using var db = new DiceShopContext();
            foreach (var clin in db.Clients)
            {
                list.Add(clin);
            }
            return list;
        }

    }

}
