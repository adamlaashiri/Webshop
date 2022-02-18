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
    /// Interaction logic for AdminEditProduct.xaml
    /// </summary>
    public partial class AdminEditProduct : Window
    {
        public AdminEditProduct()
        {
            InitializeComponent();
            UpdateListBoxProduct();


        }

        private void UpdateListBoxProduct()
        {
            List<Product> products;

            // Select all products from database
            using (var db = new webshopContext())
            {
                products = db.Products.ToList();
            }

            ListBoxProducts.Items.Clear();

            foreach (var item in products)
            {
                ListBoxProducts.Items.Add(new ListBoxItem { Content = item.Name, Tag = item.ProductId});
            }
        }

        private void UpdateFields(int? productId)
        { 
            ComboBoxCategories.Items.Clear();
            ComboBoxSuppliers.Items.Clear();

            if (productId != null)
            {
                // SQL JOIN
                using (var db = new webshopContext())
                {
                    try
                    {

                        // Using linq to get product info from database joined with category and supplier into ProductQuery where product id match
                        var product = from
                                      prod in db.Products
                                      where prod.ProductId == productId
                                      join
                                      cat in db.Categories on prod.CategoryId equals cat.CategoryId
                                      join
                                      supp in db.Suppliers on prod.SupplierId equals supp.SupplierId
                                      select new ProductQuery
                                      {
                                          CategoryName = cat.Name,
                                          SupplierName = supp.Name,
                                          CategoryId = prod.CategoryId,
                                          SupplierId = prod.SupplierId,
                                          Name = prod.Name,
                                          Description = prod.Description,
                                          Price = prod.Price,
                                          Featured = prod.Featured
                                      };


                        // Continue only if product exist, using try catch as we are only interested in one, and one only result
                        ProductQuery result;
                        try
                        {
                            result = product.Single();

                        }
                        catch (Exception)
                        {
                            TextMessage.Text = "Produkt ej funnen!";
                            throw;
                        }


                        InputName.Text = result.Name;
                        InputDescription.Text = result.Description;
                        InputPrice.Text = result.Price.ToString();
                        InputFeatured.IsChecked = result.Featured;

                        // Add relevant Category and Supplier to respective combobox and select them
                        ComboBoxItem categoryItem = new ComboBoxItem { Content = result.CategoryName, Tag = result.CategoryId };
                        ComboBoxCategories.Items.Add(categoryItem);
                        ComboBoxCategories.SelectedItem = categoryItem;

                        ComboBoxItem supplierItem = new ComboBoxItem { Content = result.SupplierName, Tag = result.SupplierId };
                        ComboBoxSuppliers.Items.Add(supplierItem);
                        ComboBoxSuppliers.SelectedItem = supplierItem;


                        // SQL SELECT, Add the (rest) of categories and suppliers
                        var categories = from cat in db.Categories where cat.CategoryId != result.CategoryId select cat;
                        var suppliers = from sup in db.Suppliers where sup.SupplierId != result.SupplierId select sup;

                        // Add combox list for every existing element
                        foreach (var item in categories)
                        {
                            ComboBoxCategories.Items.Add(new ComboBoxItem { Content = item.Name, Tag = item.CategoryId });
                        }

                        foreach (var item in suppliers)
                        {
                            ComboBoxSuppliers.Items.Add(new ComboBoxItem { Content = item.Name, Tag = item.SupplierId });
                        }

                        return;

                    }
                    catch (Exception)
                    {
                        TextMessage.Text = "Kunde inte ladda in produkten";
                    }
                }
            }
            InputName.Text = "";
            InputDescription.Text = "";
            InputPrice.Text = "";
            InputFeatured.IsChecked = false;
        }

        private void ButtonGoBack_Click(object sender, RoutedEventArgs e)
        {
            AdminHome ah = new();
            ah.Show();
            this.Close();
        }

        private void ButtonProductDelete_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxProducts.SelectedItem != null)
            {
                var productId = int.Parse(((ListBoxItem)ListBoxProducts.SelectedItem).Tag.ToString());
                // SQL DELETE
                using (var db = new webshopContext())
                {
                    var product = db.Products.SingleOrDefault(p => p.ProductId == productId);

                    if (product == null)
                    {
                        // Fail
                        TextMessage.Foreground = Brushes.Red;
                        TextMessage.Text = "Produkt ej funnen";
                    }

                    db.Products.Remove(product);
                    db.SaveChanges();

                    // Success
                    TextMessage.Foreground = Brushes.Green;
                    TextMessage.Text = "Produkt borttagen";
                    UpdateFields(null);
                    ListBoxProducts.Items.Remove(ListBoxProducts.SelectedItem);
                    ListBoxProducts.Items.Refresh();
                   
                }
            }
        }

        private void ButtonProductSave_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxProducts.SelectedItem != null)
            {
                var productId = int.Parse(((ListBoxItem)ListBoxProducts.SelectedItem).Tag.ToString());

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

                // SQL Update 
                using (var db = new webshopContext())
                {
                    var product = db.Products.SingleOrDefault(p => p.ProductId == productId);

                    if (product == null)
                    {
                        // Fail
                        TextMessage.Foreground = Brushes.Red;
                        TextMessage.Text = "Produkt ej funnen";
                    }


                    product.CategoryId = categoryId;
                    product.SupplierId = supplierId;
                    product.Name = productName;
                    product.Description = productDescription;
                    product.Price = productPrice;
                    product.Featured = productIsFeatured;
                    db.SaveChanges();
                }

                // Success
                TextMessage.Foreground = Brushes.Green;
                TextMessage.Text = "Produkt uppdaterad";

                return;
            }
        }

        private void ListBoxProducts_FocusableChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void ListBoxProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var productItem = (ListBoxItem)ListBoxProducts.SelectedItem;

            if (productItem != null)
                UpdateFields(int.Parse(productItem.Tag.ToString()));
            
        }

    }
}
