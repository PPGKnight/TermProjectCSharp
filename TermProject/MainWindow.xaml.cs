using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using static TermProject.Lists;

namespace TermProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
       
        public DateTime ZaWarudo { get; set; }
        public int EmpID { get; set; }
        public int OrID { get; set; }
        public string FullName { get; set; }
        public List<Orders> Orderss { get; set; } = Lists.GetOrders();
        public List<Clients> Clientss { get; set; } = Lists.GetClients();
        public Clients SelectedClient { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Delete_Button(object sender, RoutedEventArgs e)
        {
            using var db = new DiceShopContext();
            var selectedClient = db.Clients.Find(SelectedClient.ID);
            if (selectedClient != null && selectedClient.ID > 0)
            {

                var clin = db.Clients.Find(selectedClient.ID);
                db.Clients.Remove(clin);
                db.SaveChanges();
                Refresh();
            }
        }
        public void Add_Button(object sender, RoutedEventArgs e)
        {
            var db = new DiceShopContext();
            db.Add(new Clients()
            {

                Full_Name = this.FullName,
                ACC_Creation = this.ZaWarudo

            });
            db.SaveChanges();
            Refresh();
        }
        private void Update_Button(object sender, RoutedEventArgs e)
        {
            using (var db = new DiceShopContext()) 
            { 
                var selectedClient = db.Clients.Find(SelectedClient.ID);
                if (selectedClient != null) 
                {
                    selectedClient.Full_Name = FullName;
                    selectedClient.ACC_Creation = ZaWarudo;
                    NameBox.Text = null;
                    DataName.SelectedDate = null;
                    //NameBox.Text = selectedClient.Full_Name;
                    //DataName.SelectedDate = selectedClient.ACC_Creation;
                    db.SaveChanges();
                    Refresh();
               
                }
            }
        }
        private void Client_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(SelectedClient  != null)
            Fill(SelectedClient.ID);
        }
        private void Fill(int ID)
        {
           using (var db = new DiceShopContext())
            {
                NameBox.Text = null;
                DataName.SelectedDate = null;
                var selectedClient = db.Clients.Find(ID);
                FullName = selectedClient.Full_Name;
                ZaWarudo = selectedClient.ACC_Creation;
                NameBox.Text = FullName;
                DataName.SelectedDate = ZaWarudo;
            } 
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        public void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> list = new();
            using (var db = new DiceShopContext())
            {
                foreach (var emp in db.Employees)
                {
                    list.Add(emp.Employee_Name);
                }
            }
            var combo = sender as ComboBox;
            combo.ItemsSource = list;
        }

        public void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var selectedcomboitem = sender as ComboBox;
            string name = selectedcomboitem.SelectedItem as string;
            using var db = new DiceShopContext();
            foreach (var emp in db.Employees)
            {
                if (name == emp.Employee_Name)
                {
                    EmpID = emp.ID;
                }

            }

        }
        public void Refresh()
        {
            ClientList.ItemsSource = null;
            Clientss = Lists.GetClients();
            ClientList.ItemsSource = Clientss;
        }
    }

}
