namespace OOP
{
    public class Product : ISellable
    {
        public string Name
        {
            get;
            set;
        }

        public string ProductId
        {
            get;
            set;
        }

        public double ProductPrice
        {
            get;
            set;
        }

        public double Price
        {
            get
            {
                return this.ProductPrice;
            }
            set
            {
                this.ProductPrice = value;
            }
        }
    }
}