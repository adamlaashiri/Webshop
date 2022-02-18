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
    /// Interaction logic for ShopCart.xaml
    /// </summary>
    public partial class ShopCart : Window
    {
        public ShopCart()
        {
            InitializeComponent();
            UpdateItemsCount();

            // Get all payment and shipping methods
            List<PaymentMethod> paymentMethods = ShopDBHandler.GetPaymentMethods();
            List<ShippingMethod> shippingMethods = ShopDBHandler.GetShippingMethods();

            // Update comboboxes
            foreach (var item in paymentMethods)
            {
                ComboBoxPaymentMethod.Items.Add(new ComboBoxItem { Content = item.Name, Tag = item.PaymentMethodId });
            }

            foreach (var item in shippingMethods)
            {
                ComboBoxShippingMethod.Items.Add(new ComboBoxItem { Content = item.Name, Tag = item.ShippingMethodId });
            }
        }

        // Update Item count
        private void UpdateItemsCount()
        {
            TextBlockCartItems.Text = Cart.ItemsCount.ToString();
            UpdateCartItems();
        }

        // Update the cartItems list, holds relevant info for productId, quantity and price
        private void UpdateCartItems()
        {
            List<CartItem> productsInCart = new();

            foreach (var item in Cart.Items)
            {
                if (item.Quantity < 1) continue;
                var product = ShopDBHandler.GetProduct(item.ProductId);
                productsInCart.Add(new CartItem { ProductId = product.ProductId, ProductName = product.Name, Quantity = item.Quantity });
            }
            ListCartProducts.ItemsSource = productsInCart;
            UpdateSumText();
        }

        // Add product
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var source = (Button)sender;
            var productId = int.Parse(source.Tag.ToString());
            Cart.AddItem(productId);
            UpdateItemsCount();
        }

        // Remove product
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var source = (Button)sender;
            var productId = int.Parse(source.Tag.ToString());
            Cart.RemoveItem(productId);
            UpdateItemsCount();
        }

        private void ButtonBuy_Click(object sender, RoutedEventArgs e)
        {

            TextError.Foreground = Brushes.Red;

            // Check that all selected products (quantity) are in stock
            foreach (var item in Cart.Items)
            {
                var result = ShopDBHandler.CheckProductQtyInStock(item.ProductId, item.Quantity);

                if (!result.Item1)
                {
                    string productName = ShopDBHandler.GetProduct(item.ProductId).Name ?? "";
                    TextError.Text = $"Det finns endast {result.Item2} st {productName} i lager";
                    return;
                }
            }
            
            if (Cart.ItemsCount < 1)
            {
                TextError.Text = "Du har inte valt några produkter";
                return;
            }

            // Data validation

            if (!DataValidation.ValidateString(50,InputName.Text))
            {
                TextError.Text = "Ange Namn (max 50)";
                return;
            }

            if (!DataValidation.ValidateString(255, InputAdress.Text))
            {
                TextError.Text = "Ange Address (max 255)";
                return;
            }

            if (!DataValidation.ValidateString(10, InputTelephone.Text))
            {
                TextError.Text = "Ange Telefon (max 10)";
                return;
            }

            if (!DataValidation.ValidateString(255, InputMail.Text))
            {
                TextError.Text = "Ange Email (max 255)";
                return;
            }

            if (!DataValidation.ValidateString(50, InputPaymentDetails.Text))
            {
                TextError.Text = "Ange Betaluppgifter (max 50)";
                return;
            }

            if (ComboBoxSex.SelectedItem == null)
            {
                TextError.Text = "Välj Kön";
                return;
            }

            if (ComboBoxPaymentMethod.SelectedItem == null)
            {
                TextError.Text = "Välj Betalmetod";
                return;
            }

            if (ComboBoxShippingMethod.SelectedItem == null)
            {
                TextError.Text = "Välj Fraktbolag";
                return;
            }

            int sex = int.Parse(((ComboBoxItem)ComboBoxSex.SelectedItem).Tag.ToString());
            int paymentMethodId = int.Parse(((ComboBoxItem)ComboBoxPaymentMethod.SelectedItem).Tag.ToString());
            int shippingMethodId = int.Parse(((ComboBoxItem)ComboBoxShippingMethod.SelectedItem).Tag.ToString());

            // Checkout
            if (ShopDBHandler.CreateOrder(
                    InputName.Text,
                    InputAdress.Text,
                    InputTelephone.Text,
                    InputMail.Text,
                    sex,
                    InputPaymentDetails.Text,
                    paymentMethodId,
                    shippingMethodId
            ))
            {
                TextError.Foreground = Brushes.Green;
                TextError.Text = "Tack för ditt köp!";
                Cart.Clear();
                UpdateItemsCount();
            }
            else
            {
                TextError.Text = "Problem med att skapa ordern, Kontakta kundsupport!";
            }

        }

        private void ButtonGoBack_Click(object sender, RoutedEventArgs e)
        {
            Shop s = new();
            s.Show();
            Close();
        }

        private void UpdateSumText()
        {
            if (Cart.ItemsCount == 0)
            {
                TextSum.Text = "Summan:";
                TextShippingCost.Text = "Frakt:";
                TextTotSum.Text = "Totalt:";
            }

            if (ComboBoxShippingMethod.SelectedItem == null)
            {
                decimal sum = Cart.GetTotalCost() + (Cart.GetTotalCost() * 0.25M);
                TextSum.Text = $"Summan (inkl Moms {(Cart.GetTotalCost() * 0.25M).ToString("C", CultureInfo.CreateSpecificCulture("se-SE"))}) : {sum.ToString("C", CultureInfo.CreateSpecificCulture("se-SE"))}";
                TextShippingCost.Text = "Frakt:";
                TextTotSum.Text = $"Totalt:  {sum.ToString("C", CultureInfo.CreateSpecificCulture("se-SE"))}";
            }
            else
            {
                var shippingMethodId = int.Parse(((ComboBoxItem)ComboBoxShippingMethod.SelectedItem).Tag.ToString());
                decimal shippingCost = ShopDBHandler.GetShippingCost(shippingMethodId);
                decimal sum = shippingCost + Cart.GetTotalCost() + (Cart.GetTotalCost()*0.25M);
                TextSum.Text = $"Summan (inkl Moms {(Cart.GetTotalCost() * 0.25M).ToString("C", CultureInfo.CreateSpecificCulture("se-SE"))}) : {(Cart.GetTotalCost() * 1.25M).ToString("C", CultureInfo.CreateSpecificCulture("se-SE"))}";
                TextShippingCost.Text = $"Frakt: {shippingCost.ToString("C", CultureInfo.CreateSpecificCulture("se-SE"))}";
                TextTotSum.Text = $"Totalt:  {sum.ToString("C", CultureInfo.CreateSpecificCulture("se-SE"))}";
            }
        }

        private void ComboBoxShippingMethod_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateSumText();
        }
    }
}
