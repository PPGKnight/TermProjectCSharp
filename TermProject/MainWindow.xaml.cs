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
using static TermProject.Lists;

namespace TermProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int EmpID { get; set; }
        public List<Orders> Orderss { get; set; } = Lists.GetOrders();
        public Orders SelectedOrder { get; set; }
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Delete_Button(object sender, RoutedEventArgs e)
        {

        }
        private void Add_Button(object sender, RoutedEventArgs e)
        {

        }
        private void Update_Button(object sender, RoutedEventArgs e)
        {

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
    }

}
