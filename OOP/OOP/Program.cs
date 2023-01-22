using System;
using System.Collections;
using System.Collections.Generic;

namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Computer c = new Computer();
            Monitor m = new Monitor();
            c.SendVGA("test data", m);

            Sales s = new Sales();
            Product p = new Product();
            p.ProductPrice = 100;
            s.MakeSales(p);
            News n = new News();
            n.Price = 10;
            s.MakeSales(n);

            List<ISearchResult> results = SearchManager.Search("dssd");

            foreach(var result in results)
            {
            }
		}

        static void Swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }
    }
}