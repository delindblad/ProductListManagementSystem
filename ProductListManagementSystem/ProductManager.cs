using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace ProductListManagementSystem
{
    public class ProductManager
    {
        private int idCounter;
        private List<Product>? products;
    


    public ProductManager()
        {
            if (!Load())
            {
                this.products = new List<Product>();
                this.idCounter = 0;
            }
            

        }

        public void Add(Product product)
        {
            try
            {
                product.Id = this.idCounter++;
                products?.Add(product);

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
                products?.Remove(product);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(Product product)
        {
            return true;
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
                    Console.ForegroundColor=ConsoleColor.Green;
                    Console.WriteLine("==================");
                    Console.WriteLine("  PRODUCT LIST");
                    Console.WriteLine("==================");
                    Console.ForegroundColor = ConsoleColor.Yellow; 
                    Console.WriteLine($"Name | Category | Price");
                    Console.ResetColor();
                    foreach (var product in query)
                    {
                        
                        Console.WriteLine($"{product.Name} | {product.Category} | {product.Price} kr");
                    }

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("TOTAL PRICE: " + query.Sum((e) => e.Price) + " kr");
                    Console.ResetColor();

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
            Console.Clear();
            //Ordered by price
            IOrderedEnumerable<Product> orderedByPrice = null;
            //Average
            decimal averagePrice = 0;
            try
            {
                orderedByPrice =
                    from p in products
                    orderby p.Price
                    select p;
                //Average
                averagePrice =
                    (from p in products
                        select p.Price).Average();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + e.Message);
                Console.ResetColor();
            } 
            Console.ForegroundColor=ConsoleColor.Green;
            Console.WriteLine("-----------");
            Console.WriteLine("Statistics:");
            Console.WriteLine("-----------");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Most expensive Product:\n" + orderedByPrice.Last().Name  + " - " + orderedByPrice.Last().Price + " kr");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Cheapest Product:\n" + orderedByPrice.First().Name  + " - " + orderedByPrice.First().Price + " kr");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Average price:\n" + averagePrice + " kr");
            Console.ResetColor();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            


        }

        public bool Load()
        {
            if (File.Exists("data.json"))
            {
                try
                {
                    var options = new JsonSerializerOptions { IncludeFields = true };
                    // Loading from file
                    string jsonString = File.ReadAllText("data.json");
                    SaveData? data = JsonSerializer.Deserialize<SaveData>(jsonString);
                    //Reading products
                    products = data?.products;
                    //Restoring current id
                    idCounter = data!.idCounter;
                    return true;
                }
                catch (Exception ex)
                {
                    {
                        //Unexpected problem, return false
                        Console.WriteLine(ex.Message + ex.ToString() + ex.HelpLink);
                        Thread.Sleep(4000);
                        return false;
                    }
                }
            }

            return false;
        }

        public void Save()
        {
            try
            {   //Saving products to .json file
                //A "SaveData" object will be used to bundle the list with the idCounter
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(new SaveData(products!,idCounter),options);
                File.WriteAllText("data.json", jsonString);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<Product> GetProducts() => products!;


    }
}
