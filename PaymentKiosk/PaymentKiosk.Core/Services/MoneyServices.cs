using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentKiosk.Core.Domain;
using Stripe;


namespace PaymentKiosk.Core.Services
{
    public class MoneyServices
    {
        private const string StripeApiKey = "sk_test_JIUx5xsFLzRoTYC9AHfITeAo";

        public static bool Charge(Customer customer, CreditCard creditCard, decimal amount)
        {
            var chargeDetails = new StripeChargeCreateOptions();

            chargeDetails.Amount = (int)amount * 100;
            chargeDetails.Currency = "usd";

            chargeDetails.Source = new StripeSourceOptions
            {
                Object = "card",
                Number = creditCard.CreditCardNumber,
                ExpirationMonth = creditCard.ExpiryDate.Month.ToString(),
                ExpirationYear = creditCard.ExpiryDate.Year.ToString(),
                Cvc = creditCard.CVC
            };

            var chargeService = new StripeChargeService(StripeApiKey);
            var response = chargeService.Create(chargeDetails);

            return response.Paid;
        }

    }
}
