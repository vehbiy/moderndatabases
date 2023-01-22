using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentModule
{
    public class GarantiVPos : VPos
    {
        protected override string CreateRequest(string cardNumber, string securityNumber, string expiryDate, int amount)
        {
            throw new NotImplementedException();
        }

        protected override bool CreateResponse(string responseData)
        {
            throw new NotImplementedException();
        }
    }
}
