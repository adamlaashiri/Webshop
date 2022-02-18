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
        }

        private void ButtonGoBack_Click(object sender, RoutedEventArgs e)
        {
            AdminHome ah = new();
            ah.Show();
            Close();
        }
    }
}
