using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Shapes;
using Webshop.Models;

namespace Webshop
{
    /// <summary>
    /// Interaction logic for AdminOrderList.xaml
    /// </summary>
    public partial class AdminOrderList : Window
    {
        public AdminOrderList()
        {
            InitializeComponent();
            List<Order> orders;

            // Select all products from database
            using (var db = new webshopContext())
            {
                orders = db.Orders.ToList();
            }

            ListBoxOrders.Items.Clear();

            foreach (var item in orders)
            {
                ListBoxOrders.Items.Add(new ListBoxItem { Content = "Order (id) " + item.OrderId.ToString(), Tag = item.OrderId });
            }
        }

        private void ListBoxProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxOrders.SelectedItem == null) return;

            var orderId = int.Parse(((ListBoxItem)ListBoxOrders.SelectedItem).Tag.ToString());
            OrderQuery orderQuery = ShopDBHandler.getOrder(orderId);

            TextBlocDate.Text = $"{orderQuery.Order.OrderDate.ToString("yyyy/MM/dd HH:mm", CultureInfo.CreateSpecificCulture("se-SE"))}";
            TextBlockName.Text = $"Namn: {orderQuery.Customer.Name}";
            TextBlockAdress.Text = $"Address: {orderQuery.Customer.Address}";
            TextTelephone.Text = $"Telefon: {orderQuery.Customer.Telephone}";
            TextMail.Text = $"Mail: {orderQuery.Customer.Mail}";
            string sex = orderQuery.Customer.Sex ? "Kvinna" : "Man";
            TextSex.Text = $"Kön: {sex}";
            TextShippmentMethod.Text = $"Frakt metod: {orderQuery.ShippingMethod.Name}";

            StackPanelOrdered.Children.Clear();

            using (var db = new webshopContext())
            {
                foreach (var item in orderQuery.OrderDetails)
                {
                    string prodName = db.Products.Where(p => p.ProductId == item.ProductId).FirstOrDefault().Name;

                    StackPanelOrdered.Children.Add(new TextBlock
                    {

                        Text = $"{item.Quantity} X {prodName}"
                    });
                }
            }
        }

        private void ButtonGoBack_Click(object sender, RoutedEventArgs e)
        {
            AdminHome ah = new();
            ah.Show();
            Close();
        }
    }
}
