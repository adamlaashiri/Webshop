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
    /// Interaction logic for Shop.xaml
    /// </summary>
    public partial class Shop : Window
    {
        public Shop()
        {
            InitializeComponent();

            UpdateItemsCount();

            // Load in top 3 featured products
            List<Product> featured = ShopDBHandler.GetTopFeaturedProducts(3);

            if (featured!= null)
            {
                ListFeaturedproducts.ItemsSource = featured;
            }

            // Load all products grouped by category in an encapsulated class with relevant data
            populateScreen(ShopDBHandler.GetAllProductsGroupedByCategory());
        }

        private void populateScreen(List<ProductGroupCategoryQuery> groups)
        {
            StackPanelSearchedProducts.Children.Clear();
            if (groups != null)
            {
                foreach (var item in groups)
                {
                    TextBlock searchInfo = new TextBlock();
                    searchInfo.Text = $"Denna kategorin har med söknignen {item.ChildCount} produkter, Varav Dyraste: {item.HighestPrice.ToString("C", CultureInfo.CreateSpecificCulture("se-SE"))}, Billigaste: {item.LowestPrice.ToString("C", CultureInfo.CreateSpecificCulture("se-SE"))}, Medelpris: {item.AveragePrice.ToString("C", CultureInfo.CreateSpecificCulture("se-SE"))}";
                    searchInfo.Margin = new Thickness { Left= 10, Top = 5, Bottom = 5 };
                    searchInfo.Foreground = Brushes.DarkGray;

                    _ = StackPanelSearchedProducts.Children.Add(new TextBlock
                    {
                        Text = item.CategoryName,
                        Margin = new Thickness { Bottom = 10 },
                        FontSize = 30
                    });

                    _ = StackPanelSearchedProducts.Children.Add(searchInfo);

                    foreach (var product in item.ChildProducts)
                    {
                        StackPanel stackPanel = new();
                        TextBlock textBoxTitle = new();
                        TextBlock textBoxDescription = new();
                        TextBlock textBoxStock = new();
                        TextBlock textBoxPrice = new();
                        Button addToCartButton = new();

                        stackPanel.Orientation = Orientation.Horizontal;
                        stackPanel.Margin = new Thickness { Left = 10, Right = 10, Bottom = 10 };
                        stackPanel.Background = Brushes.AntiqueWhite;
 


                        textBoxTitle.Text = product.Name;
                        textBoxTitle.Margin = new Thickness { Right = 25};

                        textBoxDescription.Text = product.Description;
                        textBoxDescription.Margin = new Thickness { Right = 20 };

                        textBoxDescription.Text = $"{ShopDBHandler.GetProductStockQuantity(product.ProductId)} i lager";
                        textBoxDescription.Margin = new Thickness { Right = 20 };

                        textBoxPrice.Text = product.Price.ToString("C", CultureInfo.CreateSpecificCulture("se-SE"));
                        textBoxPrice.Margin = new Thickness { Right = 20 };

                        addToCartButton.Tag = product.ProductId;
                        addToCartButton.Click += new RoutedEventHandler(Button_Click);


                        addToCartButton.Content = "Lägg till";
                        addToCartButton.HorizontalContentAlignment = HorizontalAlignment.Right;

                        textBoxTitle.HorizontalAlignment = HorizontalAlignment.Left;

                        stackPanel.Children.Add(textBoxTitle);
                        stackPanel.Children.Add(textBoxDescription);
                        stackPanel.Children.Add(textBoxStock);
                        stackPanel.Children.Add(textBoxPrice);
                        stackPanel.Children.Add(addToCartButton);


                        _ = StackPanelSearchedProducts.Children.Add(stackPanel);

                    }
                }
            }
        }

        private void TextBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void TextBoxSearch_KeyUp(object sender, KeyEventArgs e)
        {

            if (TextBoxSearch.Text == string.Empty)
            {
                populateScreen(ShopDBHandler.GetAllProductsGroupedByCategory());
                return;
            }

            var searched = ShopDBHandler.Search(TextBoxSearch.Text);
            populateScreen(searched);

        }

        private void ButtonGoBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new();
            mw.Show();
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var source = (Button)sender;
            var productId = int.Parse(source.Tag.ToString());
            Cart.AddItem(productId);
            UpdateItemsCount();

        }

        private void UpdateItemsCount()
        {
            TextBlockCartItems.Text = Cart.ItemsCount.ToString();
        }

        private void ButtonGoToCart_Click(object sender, RoutedEventArgs e)
        {
            ShopCart sc = new();
            sc.Show();
            Close();
        }
    }
}
