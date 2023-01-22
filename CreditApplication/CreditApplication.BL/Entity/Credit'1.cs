using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel.FinancialFunctions;

namespace CreditApplication.BL
{
    public partial class Credit : CreditBase
    {
        public override void InnerCalculate()
        {
            double interestRate = this.InterestRate / 100;
            this.InterestRateWithTax = (interestRate + interestRate * (this.BSMVRate + this.KKDFRate) / 100) * 100;
            this.InstallmentAmount = Financial.Pmt(this.InterestRateWithTax / 100, (double)this.Months, -1 * this.CreditAmount.Value, 0.0, 0);
        }

        public static Credit Create(CreditType type)
        {
            return new Credit()
            {
                CreditType = type,
                UserType = UserType.Personal,
                CreditAmount = 100000,
                Months = 48,
                InterestRate = 1.04 
            };
        }
    }
}
