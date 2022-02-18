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
    /// Interaction logic for AdminHome.xaml
    /// </summary>
    public partial class AdminHome : Window
    {

        /* Generally as this is a database course, We haven't put much effort into implementing 
        * cleaner code structure, such as model view controller, separation of concern and low cohesion
        * Therefore this class and similarly others, have unorganized and incoherent code
        */

        private readonly Models.User _admin;
        public AdminHome()
        {
            InitializeComponent();
            this._admin = Admin.getInstance().getUser();
            TextTitle.Text = $"Inloggad som {this._admin.Name}";

        }

        private void ButtonAddCategory_Click(object sender, RoutedEventArgs e)
        {
            AdminManageCategory amc = new AdminManageCategory();
            amc.Show();
            this.Close();
        }

        private void ButtonAddProduct_Click(object sender, RoutedEventArgs e)
        {
            AdminManageProduct amp = new AdminManageProduct();
            amp.Show();
            this.Close();
        }

        private void ButtonEditProduct_Click(object sender, RoutedEventArgs e)
        {
            AdminEditProduct aep = new AdminEditProduct();
            aep.Show();
            this.Close();
        }

        private void ButtonLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new();
            mw.Show();
            Close();
        }

        private void ButtonStockBalance_Click(object sender, RoutedEventArgs e)
        {
            AdminStockBalance asb = new();
            asb.Show();
            Close();
        }

        private void ButtonOrders_Click(object sender, RoutedEventArgs e)
        {
            AdminOrderList aol = new();
            aol.Show();
            Close();
        }

        private void ButtonAggregated_Click(object sender, RoutedEventArgs e)
        {
            AdminAggregatedData aad = new();
            aad.Show();
            Close();
        }
    }

}
