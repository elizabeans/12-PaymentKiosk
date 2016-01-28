﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentKiosk.Core.Domain
{
    public class CreditCard
    {
        public string CreditCardNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string CVC { get; set; }
        public Address BillingAddress { get; set; }
    }
}
