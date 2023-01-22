using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentModule
{
    public class YKBVPos : VPos
    {
        public int Count { get; set; }
        public YKBVPos()
        {
            this.Url = "http://ykbvpos.local";
        }

        protected override string CreateRequest(string cardNumber, string securityNumber, string expiryDate, int amount)
        {
            return $"<YKBPayment><CardNumber>{cardNumber}</CardNumber><Amount>{amount}</Amount></YKBPayment>";
        }

        protected override bool CreateResponse(string responseData)
        {
            return responseData.Contains("SUCCESS");
        }
    }
}
