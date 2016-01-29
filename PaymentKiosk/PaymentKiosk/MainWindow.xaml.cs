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
using System.Windows.Navigation;
using System.Windows.Shapes;
using PaymentKiosk.Core.Domain;
using PaymentKiosk.Core.Services;
using PaymentKiosk.Shopping;


namespace PaymentKiosk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            textBoxChargeAmount.Text = ShoppingWindow.pokemonTotalPrice.ToString();
        }

        private void buttonCharge_Click(object sender, RoutedEventArgs e)
        {
            Address shipping = new Address
            {
                Line1 = textBoxAddressLine1.Text,
                Line2 = textBoxAddressLine2.Text,
                Line3 = textBoxAddressLine3.Text,
                City = textBoxAddressCity.Text,
                State = textBoxAddressState.Text,
                Zipcode = textBoxAddressZipcode.Text
            };

            var customer = new Customer
            {
                CustomerName = textBoxCustomerName.Text,
                CustomerTelephone = textBoxCustomerTelephone.Text,
                ShippingAddress = shipping
            };

            var creditCard = new CreditCard
            {
                CreditCardNumber = textBoxCreditCardNumber.Text,
                CVC = textBoxCVC.Text,
                ExpiryDate = DateTime.Parse(textBoxExpiryDate.Text)
            };

            try
            {
                bool success = MoneyServices.Charge(customer, creditCard, decimal.Parse(textBoxChargeAmount.Text));

                if (success)
                {
                    MessageBox.Show("Payment successful");
                }
                else
                {
                    MessageBox.Show("Payment failed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            string message = "Hi " + customer.CustomerName + "! Your transaction for $" + textBoxChargeAmount.Text + 
                             " has been approved. Your pokemon will be delivered to " + 
                             shipping.Line1 + shipping.Line2 + shipping.Line3 + shipping.City + shipping.State + shipping.Zipcode;

            SmsService.SendSMS("+17038640171", message);
            MessageBox.Show("Your purchase has been approved! Your confirmation will be sent to your phone.");
        }

        private void buttonContinueShopping_Click(object sender, RoutedEventArgs e)
        {
            ShoppingWindow shopping = new ShoppingWindow();
            shopping.ShowDialog();
        }
    }
}
