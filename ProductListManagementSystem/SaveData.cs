using System;
using System.Collections.Generic;
using System.Text;

namespace ProductListManagementSystem
{
    public class SaveData
    {
        public List<Product> products { get; set; }
        

        public int idCounter { get; set; }

        public SaveData(List<Product> products, int idCounter)
        {
            this.products = products;
            this.idCounter = idCounter;
        }
    }
}