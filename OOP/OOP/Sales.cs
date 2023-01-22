using System;

namespace OOP
{
    public class Sales
    {
        public void MakeSales(ISellable sellable)
        {
            VPos pos = new VPos();
            bool result = pos.MakePayment(sellable.Price);

            if (result)
            {
                // create order and save to db
            }
        }
    }
}
