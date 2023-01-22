namespace CreditApplication.BL
{
    public class InstallmentType
    {
        public int Months { get; set; }

        public InstallmentType(int months)
        {
            this.Months = months;
        }
    }
}