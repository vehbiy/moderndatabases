using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Garcia;
using System.ComponentModel.DataAnnotations;

namespace CreditApplication.BL
{
    public class BalloonPaymentOutput
    {
        public int Order { get; set; }
        public int Installments { get; set; }
        public double RemainingPrincipalAmount { get; set; }
        public double InterestAmount { get; set; }
        public double KKDFAmount { get; set; }
        public double BSMVAmount { get; set; }
        public double PrincipalPaymentAmount { get; set; }
        public double InstallmentAmount { get; set; }

        public void Calculate()
        {
            
        }
    }
}