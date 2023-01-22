using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentModule
{
    public class AkbankVPos : VPos
    {
        public AkbankVPos()
        {
            this.Url = "http://akbankvpos.local";
        }

        protected override string CreateRequest(string cardNumber, string securityNumber, string expiryDate, int amount)
        {
            return $"<AkbankPayment><CardNumber>{cardNumber}</CardNumber><SecurityCode>{securityNumber}</SecurityCode><ExpiryDate>{expiryDate}</ExpiryDate><Amount>{amount}</Amount></AkbankPayment>";
        }

        protected override bool CreateResponse(string responseData)
        {
            return responseData.Contains("OK");
        }
    }
}
