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
    /// Interaction logic for AdminManageCategory.xaml
    /// </summary>
    public partial class AdminManageCategory : Window
    {
        public AdminManageCategory()
        {
            InitializeComponent();
        }

        private void ButtonCreateCategory_Click(object sender, RoutedEventArgs e)
        {

            // Data validation
            if (!DataValidation.ValidateString(50, InputName.Text))
            {
                TextMessage.Text = "Name can't be longer than 50 characters";
                return;
            }

            string categoryName = InputName.Text;
            string categoryDescription = (InputDescription.Text == string.Empty) ? null : InputDescription.Text;

            // Object initialization where we assign fields the respective value
            var newCategory = new Category
            {
                Name = categoryName,
                // Description is nullable, so an empty string is converted to a null
                Description = categoryDescription
            };

            // Create new row in database
            using (var db = new webshopContext())
            {
                var CategoryList = db.Categories;
                CategoryList.Add(newCategory);
                db.SaveChanges();
            }

            TextMessage.Foreground = Brushes.Green;
            TextMessage.Text = "Kategori skapad";

        }

        private void ButtonGoBack_Click(object sender, RoutedEventArgs e)
        {
            AdminHome ah = new AdminHome();
            ah.Show();
            this.Close();
        }
    }
}
