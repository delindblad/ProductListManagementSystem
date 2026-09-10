using System;
using System.Collections.Generic;
using System.Text;

namespace ProductListManagementSystem
{
    internal class Product

    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }

        public Product(string name, string category, Decimal price)
        {
            Name = name;
            Category = category;
            Price = price;

        }


    }
}
