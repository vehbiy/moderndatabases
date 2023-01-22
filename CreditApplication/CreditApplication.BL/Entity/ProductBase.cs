using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditApplication.BL
{
    public class ProductBase : CustomEntity
    {
        public List<Product> Products { get; set; }
        public Product SelectedProduct { get; set; }

        public ProductBase()
        {
            this.Products = new List<Product>();
            this.Products.Add(new Product() { Price = 100000, Name = "Araç-1", Order = 1, ImageUrl = "/Images/1.png" });
            this.Products.Add(new Product() { Price = 150000, Name = "Araç-2", Order = 2, ImageUrl = "/Images/2.png" });
            this.Products.Add(new Product() { Price = 200000, Name = "Araç-3", Order = 3, ImageUrl = "/Images/3.png" });
            this.Products.Add(new Product() { Price = 250000, Name = "Araç-4", Order = 4, ImageUrl = "/Images/4.png" });
            this.Products.Add(new Product() { Price = 300000, Name = "Araç-5", Order = 5, ImageUrl = "/Images/5.png" });
            this.Products.Add(new Product() { Price = 400000, Name = "Araç-6", Order = 6, ImageUrl = "/Images/6.png" });
        }

        public Product Upgrade()
        {
            Product upgrade = null;

            if (this.Products != null && this.SelectedProduct != null)
            {
                upgrade = this.Products.Where(x => x.Order > this.SelectedProduct.Order).OrderBy(x => x.Order).FirstOrDefault();

                if (upgrade != null)
                {
                    this.AfterUpgrade(upgrade);
                }
            }

            return upgrade;
        }

        public virtual void AfterUpgrade(Product upgrade)
        {
        }
    }
}
