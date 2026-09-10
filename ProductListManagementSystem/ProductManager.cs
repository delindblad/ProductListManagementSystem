using System;
using System.Collections.Generic;
using System.Text;

namespace ProductListManagementSystem
{
    internal class ProductManager
    {
        private List<Product> products;

        public ProductManager()
        {
            this.products = new List<Product>();
        }

        public void Add(Product product)
        {
            try
            {
                products.Add(product);

            }
            catch (Exception)
            {
                throw new Exception("Failed to add product!");
            }
        }

        public bool Remove(Product product)
        {
            try
            {
                products.Remove(product);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(Product product)
        {
            try
            {
                var index = products.IndexOf(product);
                if (index != -1)
                {
                    products[index] = product;
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Show()
        {
            try
            {
                //Get the products
                IOrderedEnumerable<Product> query =
                    from p in products
                    orderby -p.Price
                    select p;

                Console.Clear();
                //Check if the list is empty
                if (query.Count() == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("List is empty!");
                    Console.ResetColor();
                }
                else { 
                    //Display the products
                    Console.WriteLine("==================");
                    Console.WriteLine("  PRODUCT LIST");
                    Console.WriteLine("==================\n");



                
                    Console.WriteLine($"Name | Category | Price");
                    foreach (var product in query)
                    {
                        
                        Console.WriteLine($"{product.Name}| {product.Category} | {product.Price} kr");
                    }
                    Console.WriteLine("\n\n--------------");
                    Console.WriteLine("TOTAL PRICE: " + query.Sum((e) => e.Price) + " kr");
                    Console.WriteLine("--------------\n");

                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: "+ e.Message);
                Console.ResetColor();

            }

        }

        public void ShowStatistics()
        {
            var totalProducts = products.Count;
            var averagePrice = products.Count > 0 ? products.Average(p => p.Price) : 0;
            Console.WriteLine($"Total Products: {totalProducts}");
            Console.WriteLine($"Average Price: {averagePrice:C}");
        }

        public void Load()
        {
            // Load products from a data source (e.g., database, file)
            // This is a placeholder for actual loading logic
        }

        public void Save()
        {
            // Save products to a data source (e.g., database, file)
            // This is a placeholder for actual saving logic
        }

        public List<Product>.Enumerator GetProducts() => products.GetEnumerator();


    }
}
