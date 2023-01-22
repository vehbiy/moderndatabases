using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Garcia;
using System.ComponentModel.DataAnnotations;
using Amazon.Runtime.Internal;
using Excel.FinancialFunctions;

namespace CreditApplication.BL
{
    public class BalloonPayment : CreditBase
    {
        public double? Price { get; set; }
        public double? AdvancePayment { get; set; }
        public List<BalloonPaymentOutput> CalculationResults { get; set; }
        [Required] public double InterestRateWithTax { get; set; }
        public double? CreditAmount { get; protected set; }
        public List<BalloonPaymentInstallment> BalloonPaymentInstallments { get; protected set; }

        public BalloonPayment()
        {
            this.CalculationResults = new List<BalloonPaymentOutput>();
            this.AvailableInstallments.Add(new InstallmentType(12));
            this.AvailableInstallments.Add(new InstallmentType(18));
            this.AvailableInstallments.Add(new InstallmentType(24));
            this.AvailableInstallments.Add(new InstallmentType(36));
            this.AvailableInstallments.Add(new InstallmentType(48));
            this.BalloonPaymentInstallments = new List<BalloonPaymentInstallment>();
        }

        public override void InnerCalculate()
        {
            this.CreditAmount = this.Price - this.AdvancePayment;
            double interestRate = this.InterestRate / 100;
            this.InterestRateWithTax = (interestRate + interestRate * (this.BSMVRate + this.KKDFRate) / 100) * 100;
            double interestRateWithTax = this.InterestRateWithTax / 100;
            this.InstallmentAmount = Financial.Pmt(this.InterestRateWithTax / 100, (double) this.Months,
                -1 * this.CreditAmount.Value, 0.0, 0);
            double power = Math.Pow(interestRateWithTax + 1, this.Months);
            double elasticPaymentTotal = 0.0;
            double regularPaymentTotal = 0.0;
            List<BalloonPaymentCalculation> calculations = new List<BalloonPaymentCalculation>();

            for (int i = 0; i < this.Months; i++)
            {
                int order = i + 1;
                BalloonPaymentInstallment balloon = this.BalloonPaymentInstallments.Where(x => x.Amount != 0.0 && x.Month == order).FirstOrDefault();
                double coefficient = balloon == null ? 1.0 : balloon.Amount; 

                BalloonPaymentCalculation calculation = new BalloonPaymentCalculation()
                {
                    Order = order,
                    InstallmentAmount = Math.Pow(interestRateWithTax + 1, this.Months - order),
                    Coefficient = coefficient
                };

                calculation.CoefficientFactor = calculation.InstallmentAmount * calculation.Coefficient;
                calculation.RegularPayment = calculation.Coefficient == 1.0 ? calculation.CoefficientFactor : 0;
                calculation.ElasticPayment = calculation.Coefficient == 1.0 ? 0 : calculation.CoefficientFactor;
                regularPaymentTotal += calculation.RegularPayment;
                elasticPaymentTotal += calculation.ElasticPayment;
                calculations.Add(calculation);
            }

            this.InstallmentAmount = (this.CreditAmount * power - elasticPaymentTotal) / regularPaymentTotal;
            double interestBaseAmount = this.CreditAmount.Value; 

            foreach (BalloonPaymentCalculation calculation in calculations)
            {
                BalloonPaymentOutput output = new BalloonPaymentOutput()
                {
                    Order = calculation.Order,
                    Installments = 1,
                    InterestAmount = interestBaseAmount * this.InterestRate / 100,
                    InstallmentAmount = calculation.Coefficient == 1 ? this.InstallmentAmount.Value : calculation.Coefficient
                };

                output.KKDFAmount = output.InterestAmount * this.KKDFRate / 100;
                output.BSMVAmount = output.InterestAmount * this.BSMVRate / 100;
                output.PrincipalPaymentAmount = output.InstallmentAmount - (output.KKDFAmount + output.BSMVAmount) - output.InterestAmount;
                output.RemainingPrincipalAmount = interestBaseAmount - output.PrincipalPaymentAmount;
                interestBaseAmount = output.RemainingPrincipalAmount;
                this.CalculationResults.Add(output);
            }
        }

        public static BalloonPayment Create()
        {
            return new BalloonPayment()
            {
                CreditType = CreditType.Vehicle,
                UserType = UserType.Personal,
                InterestRate = 0.83
            };
        }
    }

    public class BalloonPaymentCalculation
    {
        public int Order { get; set; }
        public double InstallmentAmount { get; set; }
        public double Coefficient { get; set; }
        public double CoefficientFactor { get; set; }
        public double RegularPayment { get; set; }
        public double ElasticPayment { get; set; }
    }

    public class BalloonPaymentInstallment
    {
        public int Month { get; set; }
        public double Amount { get; set; }
    }
}