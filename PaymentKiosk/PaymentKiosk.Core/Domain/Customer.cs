using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentKiosk.Core.Domain
{
    public class Customer
    {
        public string CustomerName { get; set; }
        public string CustomerTelephone { get; set; }
        public Address ShippingAddress { get; set; }
    }
}
