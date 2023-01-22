using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garcia;

namespace CreditApplication.BL
{
    public class CreditBase : ProductBase
    {
        [Required]
        [MvcIgnore]
        public double BSMVRate { get; set; }
        [Required]
        [MvcIgnore]
        public double KKDFRate { get; set; }
        [MvcIgnore]
        [MvcListIgnore]
        [Required]
        public UserType UserType { get; set; }
        [Required]
        public CreditType CreditType { get; set; }
        public double? InstallmentAmount { get; set; }
        [Required]
        public int Months { get; set; }
        [Required]
        public double InterestRate { get; set; }
        public List<InstallmentType> AvailableInstallments { get; set; }

        public CreditBase()
        {
            this.AvailableInstallments = new List<InstallmentType>();
        }
        
        public virtual void InnerCalculate()
        {
        }

        public void Calculate()
        {
            double bsmv = 0;
            double kkdf = 0;

            switch (this.CreditType)
            {
                case CreditType.Personal:
                    bsmv = 5;
                    kkdf = 15;
                    break;
                case CreditType.Vehicle:
                    if (this.UserType == UserType.Personal)
                    {
                        bsmv = 5;
                        kkdf = 15;
                    }
                    else
                    {
                        bsmv = 5;
                        kkdf = 0;
                    }
                    break;
                case CreditType.House:
                    bsmv = 0;
                    kkdf = 0;
                    break;
            }

            this.BSMVRate = bsmv;
            this.KKDFRate = kkdf;
            this.InnerCalculate();
        }
    }
}
