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
        }

        private void buttonCharge_Click(object sender, RoutedEventArgs e)
        {
            var customer = new Customer
            {
                CustomerName = textBoxCustomerName.Text,
                CustomerTelephone = textBoxCustomerTelephone.Text,
            };

            var creditCard = new CreditCard
            {
                CreditCardNumber = textBoxCreditCardNumber.Text,
                CVC = textBoxCVC.Text,
                ExpiryDate = DateTime.Parse(textBoxExpiryDate.Text)
            };

            bool success = MoneyServices.Charge(customer, creditCard, decimal.Parse(textBoxChargeAmount.Text));

            string message = "Your transaction for $" + textBoxChargeAmount.Text + " has been approved.";

            SmsService.SendSMS("+17038640171", message);
        }
    }
}
