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
    /// Interaction logic for AdminAggregatedData.xaml
    /// </summary>
    public partial class AdminAggregatedData : Window
    {
        public AdminAggregatedData()
        {
            InitializeComponent();

            TopProductQuery topProduct = AggregatedData.GetTopProduct();
            LeastSoldProductQuery leastSoldProduct = AggregatedData.GetLeastSoldProduct();
            int averageProductsPerOrder = AggregatedData.GetAverageOrderPerCustomer();
            MostPopularCategoryQuery mostPopularCategoryQuery = AggregatedData.MostPopularCategory();
            decimal stockValuation = AggregatedData.GetStockValuation();
            (string, int) leastStockedProduct = AggregatedData.GetProductWithLeastStock();
            (string, int) mostStockedProduct = AggregatedData.GetProductWithMostStock();
            (string, int) mostPopularShipper = AggregatedData.GetMostPopularShipper();
            (string, int) mostPopularProductWomen = AggregatedData.GetMostPopularWomensProduct();
            (string, int) mostPopularProductMen = AggregatedData.GetMostPopularMensProducts();



            TextTopProduct.Text = $"Populäraste produkten är {topProduct.Name}, såld över {topProduct.Sold} gånger";
            TextLeastSoldProduct.Text = $"Minst populära produkten är {leastSoldProduct.Name}, såld endast {leastSoldProduct.Sold} gånger";
            TextAverageProductsPerOrder.Text = $"En beställning har i genomsnitt {averageProductsPerOrder} produkter";
            TextTopCategory.Text = $"Bästa kategorin är {mostPopularCategoryQuery.CategoryName} med {mostPopularCategoryQuery.Sold} produkter sålda";
            TextStockValuation.Text = $"Lagervärdering (totala lagersaldo): {stockValuation.ToString("C", CultureInfo.CreateSpecificCulture("se-SE"))}";
            TextLeastStockedProduct.Text = $"Produkten med minst kvantitet i lagret: {leastStockedProduct.Item1}, {leastStockedProduct.Item2} i lager";
            TextMostStockedProduct.Text = $"Produkten med störst kvantitet i lagret: {mostStockedProduct.Item1}, {mostStockedProduct.Item2} i lager";
            TextPopularShipper.Text = $"Fraktmetoden med högst popularitet: {mostPopularShipper.Item1} med hela {mostPopularShipper.Item2} leveranser";

            TextPopularMen.Text = $"Populäraste produkten hos Män är {mostPopularProductMen.Item1}, med {mostPopularProductMen.Item2} sålda varor";
            TextPopularWomen.Text = $"Populäraste produkten hos kvinnor är {mostPopularProductWomen.Item1}, med {mostPopularProductWomen.Item2} sålda varor";
        }

        private void ButtonGoBack_Click(object sender, RoutedEventArgs e)
        {
            AdminHome ah = new();
            ah.Show();
            Close();
        }
    }
}
