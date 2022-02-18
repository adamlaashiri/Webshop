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
    /// Interaction logic for AdminManageProduct.xaml
    /// </summary>
    public partial class AdminManageProduct : Window
    {
        public AdminManageProduct()
        {
            InitializeComponent();

            // Prepare all categories
            using (var db = new webshopContext())
            {
                var categories = db.Categories ?? null;

                if (categories != null)
                {
                    // loop through all categories
                    foreach (var item in categories)
                    {
                        ComboBoxCategories.Items.Add(new ComboBoxItem { Content = item.Name, Tag = item.CategoryId});
                    }
                }
            }

            // Prepare all Suppliers
            using (var db = new webshopContext())
            {
                var suppliers = db.Suppliers ?? null;

                if (suppliers != null)
                {
                    // loop through all categories
                    foreach (var item in suppliers)
                    {
                        ComboBoxSuppliers.Items.Add(new ComboBoxItem { Content = item.Name, Tag = item.SupplierId });
                    }
                }
            }
        }

        private void ButtonGoBack_Click(object sender, RoutedEventArgs e)
        {
            AdminHome ah = new AdminHome();
            ah.Show();
            this.Close();
        }

        private void ButtonCreateProduct_Click(object sender, RoutedEventArgs e)
        {
            var categoryItem = (ComboBoxItem)ComboBoxCategories.SelectedItem ?? null;

            if (categoryItem == null)
            {
                TextMessage.Text = "Välj kategori";
                return;
            }

            int categoryId = int.Parse(categoryItem.Tag.ToString());

            var supplierItem = (ComboBoxItem)ComboBoxSuppliers.SelectedItem ?? null;

            if (supplierItem == null)
            {
                TextMessage.Text = "Välj leverantör";
                return;
            }

            int supplierId = int.Parse(supplierItem.Tag.ToString());

            // Data validation, based on the table of products
            if (!DataValidation.ValidateString(50, InputName.Text))
            {
                TextMessage.Text = "Namn har en gräns på 50 karaktärer";
                return;
            }

            if (!DataValidation.ValidateString(256, InputDescription.Text))
            {
                TextMessage.Text = "Beskrivning har en gräns på 256 karaktärer";
                return;
            }

            if (!DataValidation.ValidateDecimal(InputPrice.Text))
            {
                TextMessage.Text = "Pris måste ha ett numeriskt värde med ',' som separator";
                return;
            }

            string productName = InputName.Text;
            string productDescription = InputDescription.Text;
            decimal productPrice = decimal.Parse(InputPrice.Text);
            bool productIsFeatured = InputFeatured.IsEnabled;

            using (var db = new webshopContext())
            {
                try {
                    var newProduct = new Product
                    {
                        CategoryId = categoryId,
                        SupplierId = supplierId,
                        Name = productName,
                        Description = productDescription,
                        Price = productPrice,
                        Featured = productIsFeatured
                    };

                    // insert into database
                    var productList = db.Products;
                    productList.Add(newProduct);
                    db.SaveChanges();

                    StockBalance newStockBal = new StockBalance
                    {
                        ProductId = newProduct.ProductId,
                        // All new product get an initial quantity of 25!
                        Quantity = 25
                    };

                    // Success
                    TextMessage.Foreground = Brushes.Green;
                    TextMessage.Text = "Produkt skapad";
                }
                catch(Exception)
                {
                    // Fail
                    TextMessage.Foreground = Brushes.Green;
                    TextMessage.Text = "Problem med skapandet av produkten";
                }
            }

        }
    }
}
