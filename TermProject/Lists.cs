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
        public static List<Order> GetOrders()
        {
            var list = new List<Order>();

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

    }

}
