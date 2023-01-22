using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel.FinancialFunctions;

namespace CreditApplication.BL
{
    public partial class VehicleInput
    {
        public static VehicleInput Create()
        {
            return new VehicleInput()
            {
                InterestRate = 1.4,
                Price = 100000,
                UsageDuration = 2,
                UsageType = UsageType.Credit | UsageType.Advance | UsageType.Rent,
                UserType = UserType.Corporate | UserType.Personal,
                AdvancePayment = 20000,
                MaximumRent = 3000
            };
        }

        public List<VehicleOutput> Calculate(VehicleInput input)
        {
            this.CalculationResults = new List<VehicleOutput>();
            this.Calculate(input, UsageType.Advance, UserType.Personal);
            this.Calculate(input, UsageType.Credit, UserType.Personal);
            this.Calculate(input, UsageType.Rent, UserType.Personal);
            this.Calculate(input, UsageType.Advance, UserType.Corporate);
            this.Calculate(input, UsageType.Credit, UserType.Corporate);
            this.Calculate(input, UsageType.Rent, UserType.Corporate);
            return this.CalculationResults;
        }

        private void Calculate(VehicleInput input, UsageType usage, UserType user)
        {
            if (!input.UsageType.HasFlag(usage) || !input.UserType.HasFlag(user))
            {
                return;
            }

            VehicleOutput output = new VehicleOutput()
            {
                UsageType = usage,
                UserType = user
            };

            double corporateTaxRatio = 0.22;
            double advance = 0;
            double credit = 0;
            double rent = 0;
            double basicInsurance = (500 / 12) * input.UsageDuration.Value * 12;
            double insurance = ((input.Price.Value * 0.025) / 12) * input.UsageDuration.Value * 12;
            double mtv = input.Price.Value * 0.02 * input.UsageDuration.Value;
            double service = input.Price.Value * 0.03 * input.UsageDuration.Value;
            double wheels = 600 * input.UsageDuration.Value;
            double other = input.Price.Value * 0.013 * input.UsageDuration.Value;
            double tax = 0;
            double corporateTax = 0;
            double salePrice = input.Price.Value * 0.56;
            double interest = 0;

            switch (usage)
            {
                case UsageType.Advance:
                    advance = input.Price.Value;
                    break;
                case UsageType.Credit:
                    advance = input.AdvancePayment.Value;
                    break;
                case UsageType.Rent:
                    advance = 0;
                    rent = input.MaximumRent.Value * input.UsageDuration.Value * 12 * 1.18;
                    basicInsurance = 0;
                    insurance = 0;
                    mtv = 0;
                    service = 0;
                    wheels = 0;
                    other = 0;
                    salePrice = 0;
                    break;
            }

            if (usage != UsageType.Rent)
            {
                credit = input.Price.Value - advance;

                if (credit > 0)
                {
                    interest = -1 * Financial.CumIPmt(input.InterestRate / 100, input.UsageDuration.Value * 12, credit, 1, input.UsageDuration.Value * 12, 0) * 1.2;
                }
            }

            if (user == UserType.Corporate)
            {
                if (usage == UsageType.Rent)
                {
                    tax = rent / 1.18 * 0.18;
                    corporateTax = rent / 1.18 * corporateTaxRatio;
                }
                else
                {
                    tax = ((service + wheels + other) / 1.18 * 0.18) - (salePrice / 1.01 * 0.01);
                    corporateTax = ((input.Price.Value - salePrice) / 1.01 * corporateTaxRatio) + ((insurance + basicInsurance + service + wheels) * corporateTaxRatio);
                }
            }

            output.FinancialExpenses = new ExpenseGroup();
            output.FinancialExpenses.Expenses.Add(new Expense("Peşinat", advance));
            output.FinancialExpenses.Expenses.Add(new Expense("Kullanılacak Kredi Tutarı", credit));
            output.FinancialExpenses.Expenses.Add(new Expense("Toplam Kira Bedeli", rent));
            output.FinancialExpenses.Expenses.Add(new Expense("Krediye Ödenen Toplam Faiz", interest));
            //output.FinancialExpenses.Expenses.Add(new Expense("Finansal Giderler Toplamı", output.FinancialExpenses.Total));
            output.OperationalExpenses = new ExpenseGroup();
            output.OperationalExpenses.Expenses.Add(new Expense("Kasko", insurance));
            output.OperationalExpenses.Expenses.Add(new Expense("Zorunlu Trafik Sigortası", basicInsurance));
            output.OperationalExpenses.Expenses.Add(new Expense("Motorlu Taşıtlar Vergisi", mtv));
            output.OperationalExpenses.Expenses.Add(new Expense("Periyodik Bakım ve Olası Garanti Dışı Arızalar", service));
            output.OperationalExpenses.Expenses.Add(new Expense("Lastik", wheels));
            output.OperationalExpenses.Expenses.Add(new Expense("Diğer Giderler", other));
            //output.OperationalExpenses.Expenses.Add(new Expense("Operasyonel Giderler Toplamı", output.OperationalExpenses.Total));
            output.EstimatedSalePrice = salePrice;
            output.Tax = tax;
            output.CorporateTax = corporateTax;
            this.CalculationResults.Add(output);
        }
    }
}
