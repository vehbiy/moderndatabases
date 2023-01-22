using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentModule
{
    public class PaymentLog : MongoDBEntity
    {
        public PaymentLog(double amount, string cardNumber, bool status)
        {
            Amount = amount;
            CardNumber = cardNumber;
            Status = status;
        }

        public double Amount { get; set; }
        public string CardNumber { get; set; }
        public bool Status { get; set; }
    }
}
