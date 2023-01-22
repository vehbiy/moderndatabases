using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PaymentModule
{
    public class PaymentManager
    {
        internal static bool MakePayment(string cardNumber, string securityNumber, string expiryDate, int amount)
        {
            VPos vpos = GetVPos(cardNumber);
            bool paymentResult = vpos.ProcessPayment(cardNumber, securityNumber, expiryDate, amount);

            #region Log
            var mongodbHelper = new MongoDBHelper<PaymentLog>();
            var maskedCardNumber = $"{cardNumber.Substring(0, 6)}******{cardNumber.Substring(12, 4)}";
            var log = new PaymentLog(amount, maskedCardNumber, paymentResult);
            mongodbHelper.Insert(log);
            #endregion

            return paymentResult;
        }

        private static VPos GetVPos(string cardNumber)
        {
            Bank bank = Bank.GetBank(cardNumber);
            VPos vpos = null;

            if (bank != null)
            {
                switch (bank.Name)
                {
                    case "YKB":
                        vpos = new YKBVPos();
                        break;
                    case "Akbank":
                        vpos = new AkbankVPos();
                        break;
                    default:
                        break;
                }
            }

            if (vpos != null)
            {
                var dbHelper = new DBHelper();
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("Name", vpos.GetType().Name);
                DataTable allVPos = dbHelper.ExecuteDataTable("select * from VPos where Name=@Name", parameters);

                if (allVPos != null && allVPos.Rows.Count != 0)
                {
                    vpos.Initialize(allVPos.Rows[0]);
                }
            }

            return vpos;
        }
    }
}
