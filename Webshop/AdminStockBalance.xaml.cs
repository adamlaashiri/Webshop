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
using System.Windows.Shapes;
using Webshop.Models;

namespace Webshop
{
    /// <summary>
    /// Interaction logic for AdminStockBalance.xaml
    /// </summary>
    public partial class AdminStockBalance : Window
    {
        public AdminStockBalance()
        {
            InitializeComponent();

            // Populate listbox od products
            using (var db = new webshopContext())
            {
                var result = from product in db.Products
                             select product;

                if (result != null)
                {
                    var products = result.ToList();
                    foreach (var item in products)
                    {
                        ListBoxProducts.Items.Add(new ListBoxItem { Content = item.Name, Tag = item.ProductId });
                    }
                }
            }
        }

        private void UpdateStock()
        {
            if (ListBoxProducts.SelectedItem != null)
            {
                var productId = int.Parse(((ListBoxItem)ListBoxProducts.SelectedItem).Tag.ToString());
                var quantity = int.Parse(TextBoxQuantity.Text);

                if (ShopDBHandler.UpdateProductStock(productId, quantity))
                {
                    TextMessage.Foreground = Brushes.Green;
                    TextMessage.Text = "Lager saldo updaterad!";
                    return;
                }
                TextMessage.Foreground = Brushes.Red;
                TextMessage.Text = "Lager saldo gick inte att updatera!";
            }
        }

        private void ButtonGoBack_Click(object sender, RoutedEventArgs e)
        {
            AdminHome ah = new();
            ah.Show();
            Close();
        }

        // Decrese quantity
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int qty = int.Parse(TextBoxQuantity.Text);

            if (qty > 0)
            {
                qty--;
            }

            TextBoxQuantity.Text = qty.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int qty = int.Parse(TextBoxQuantity.Text);
            qty++;

            TextBoxQuantity.Text = qty.ToString();
        }

        private void ListBoxProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var productId = int.Parse(((ListBoxItem)ListBoxProducts.SelectedItem).Tag.ToString());
            int qty = ShopDBHandler.GetProductStockQuantity(productId);
            TextBoxQuantity.Text = qty.ToString();
            TextMessage.Text = "";
        }

        private void ButtonStockSave_Click(object sender, RoutedEventArgs e)
        {
            UpdateStock();
        }
    }
}
