using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Garcia;
using System.ComponentModel.DataAnnotations;
using Excel.FinancialFunctions;

namespace CreditApplication.BL
{
    public partial class PurchasePowerInput
    {
        public static PurchasePowerInput Create()
        {
            return new PurchasePowerInput()
            {
                CreditType = CreditType.House,
                UserType = UserType.Personal
            };
        }

        public override void InnerCalculate()
        {
            this.CalculationResults = new List<PurchasePowerOutput>();
            double interestRate = this.InterestRate / 100;
            double installmentAmount = Financial.Pmt(interestRate * (1 + (this.KKDFRate + this.BSMVRate) / 100), (double)this.Months, -1 * (this.Price.Value - this.AdvancePayment.Value), 0.0, 0);
            double installments = Financial.NPer(interestRate, -1 * this.InstallmentAmount.Value, this.Price.Value - this.AdvancePayment.Value, 0.0, 0);
            int installmentCount = (int)Math.Ceiling(installments);
            double total = this.Price.Value - Financial.Pv(interestRate * 1.15, (double)this.Months, -1 * this.InstallmentAmount.Value, 0.0, 0);
            string creditName = this.CreditType == CreditType.House ? "konut" : (this.CreditType == CreditType.Vehicle ? "araç" : "ihtiyaç");

            PurchasePowerOutput output = new PurchasePowerOutput()
            {
                Price = this.Price.Value,
                AdvancePayment = this.AdvancePayment.Value,
                Months = this.Months,
                MonthlyInterestRate = this.InterestRate,
                InstallmentAmount = installmentAmount,
                CreditType = this.CreditType,
            };
            output.CreditAmount = output.Price - output.AdvancePayment;
            output.Description = output.Price.ToString("N02") + " TL deðerindeki bir " + creditName + " için " + output.AdvancePayment.ToString("N02") + " TL peþinat ödeyerek % " + output.MonthlyInterestRate.ToString() + " faiz oraný üzerinden " + output.Months.ToString() + " Ay vadeli bir kredi almak isterseniz ayda " + output.InstallmentAmount.ToString("N02") + " TL tutarýnda taksit ödemeniz gereklidir.";
            this.CalculationResults.Add(output);

            output = new PurchasePowerOutput()
            {
                Price = this.Price.Value,
                AdvancePayment = this.AdvancePayment.Value,
                Months = installmentCount,
                MonthlyInterestRate = this.InterestRate,
                CreditType = this.CreditType
            };
            output.CreditAmount = output.Price - output.AdvancePayment;
            output.InstallmentAmount = Financial.Pmt(interestRate * (1 + (this.KKDFRate + this.BSMVRate) / 100), (double)installmentCount, -1 * (this.Price.Value - this.AdvancePayment.Value), 0.0, 0);
            output.Description = output.Price.ToString("N02") + " TL deðerindeki bir " + creditName + " için " + output.AdvancePayment.ToString("N02") + " TL peþinat ödeyerek % " + output.MonthlyInterestRate.ToString() + " faiz oraný üzerinden ayda " + output.InstallmentAmount.ToString("N02") + " TL taksit ödemeli bir kredi kullanmak istiyorsanýz bu kredinin vadesi " + output.Months.ToString() + " ay olabilmektedir. ";
            this.CalculationResults.Add(output);

            output = new PurchasePowerOutput()
            {
                Price = this.Price.Value,
                AdvancePayment = total,
                Months = installmentCount,
                MonthlyInterestRate = this.InterestRate,
                InstallmentAmount = this.InstallmentAmount.Value,
                CreditType = this.CreditType
            };
            output.CreditAmount = output.Price - output.AdvancePayment;
            output.Description = output.Price.ToString("N02") + " TL deðerindeki bir " + creditName + " için % " + output.MonthlyInterestRate.ToString() + " faiz oraný üzerinden " + output.Months.ToString() + " Ay vadeli, ayda " + output.InstallmentAmount.ToString("N02") + " TL taksit ödemeli bir kredi kullanmak isterseniz " + output.AdvancePayment.ToString("N02") + " TL peþinat ödemeniz gereklidir.";
            this.CalculationResults.Add(output);
        }
    }
}

