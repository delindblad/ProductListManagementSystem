

using System.Text.RegularExpressions;

namespace ProductListManagementSystem
{
    public class Program
    {
        static ProductManager? productManager = new ProductManager();
        //The main menu
        private static readonly string menuText =
    @"=============================
Product Management System
=============================

1. Add Product
2. Show Products
3. Search Product
4. Statistics
5. Exit
";



        static void Main(string[] args)
        {
            Console.Title = "Product Management System";


            while (true)
            {
                Console.Clear();
                PrintMainMenu();
                Console.WriteLine("Select option: ");
                var key = Console.ReadKey().KeyChar;
                switch (key)
                {
                    case '1':
                        AddProductPage();
                        break;
                    case '2':
                        ShowProductsPage();
                        break;
                    case '3':
                        SearchProductPage();
                        break;
                    case '4':
                        StatisticsPage();
                        break;
                    case '5':
                        productManager?.Save();
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Saving data...");
                        Console.ResetColor();
                        Thread.Sleep(1000);
                        return;
                    default:
                        Console.Beep();
                        break;

                }
            }

            static void PrintMainMenu() => Console.WriteLine(menuText);



        }
        

        private static void StatisticsPage()
        {
            productManager?.ShowStatistics();
        }
        

        //Search for products
        private static void SearchProductPage()
        {
            while (true)
            {
                //Options
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Select search type: ");
                Console.WriteLine("1. Search by category");
                Console.WriteLine("2. Search by product\n");
                Console.WriteLine("Type \"Q\" to return to main menu");
                Console.ResetColor();
                
                var input = Console.ReadKey().KeyChar.ToString().ToLower();
                while (input != "q")
                {
                    if(input == "1") //Category search
                    {   
                        while (true)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Product Category(Q to quit): ");
                            Console.ResetColor();
                            var query = Console.ReadLine()?.Trim().ToLower();
                            if (query.IsWhiteSpace())
                            {
                                Console.ForegroundColor =  ConsoleColor.Red;
                                Console.WriteLine("Error: Product category name may not be empty");
                                Console.ResetColor();
                                Console.Beep();
                            }
                            else if (query.Equals("q"))
                            {
                                break;
                            }
                            else
                            {
                                //Get the products
                                var products = productManager.GetProducts();
                                Console.ForegroundColor = ConsoleColor.Green;
                                //Print results
                                Console.WriteLine("Search results: \n");
                                Console.WriteLine("Category | Name | Price");
                                Console.ResetColor();
                                int matches = 0;
                                foreach (var p in products)
                                {
                                    //Using regexp for match
                                    if (Regex.IsMatch(p.Category.ToLower().Trim(), query.ToLower().Trim()))
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                        Console.WriteLine(p.Category+ " | " + p.Name + " | "  + p.Price);
                                        Console.ResetColor();
                                        matches++;
                                    }
                                    else
                                    {
                                        Console.WriteLine(p.Category + " | " + p.Name + " | "  + p.Price);
                                    }
                                }

                                if (matches == 0)
                                {
                                    Console.WriteLine("NO MATCHES!");
                                }
                                else
                                {
                                    Console.WriteLine(matches + " MATCHES");
                                }
                                
                                Console.WriteLine();
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();

                            }
                            
                        }
                        break;
                        

                    }
                    else if(input == "2") //Product search
                    {
                        while (true)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Product Name(Q to quit): ");
                            Console.ResetColor();
                            var query = Console.ReadLine()?.Trim().ToLower();
                            if (query.IsWhiteSpace())
                            {
                                Console.ForegroundColor =  ConsoleColor.Red;
                                Console.WriteLine("Error: Product name may not be empty");
                                Console.ResetColor();
                                Console.Beep();
                            }
                            else if (query.Equals("q"))
                            {
                                break;
                            }
                            else
                            {
                                var products = productManager.GetProducts();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Search results: \n");
                                Console.WriteLine("Category | Name | Price");
                                Console.ResetColor();
                                int matches = 0;
                                foreach (var p in products)
                                {
                                    //Using regexp for match
                                    if (Regex.IsMatch(p.Name.ToLower().Trim(), query.ToLower().Trim()))
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                        Console.WriteLine(p.Category + " | " + p.Name + " | "  + p.Price);
                                        Console.ResetColor();
                                        matches++;
                                    }
                                    else
                                    {
                                        Console.WriteLine(p.Category + " | " + p.Name + " | "  + p.Price);
                                    }
                                }

                                if (matches == 0)
                                {
                                    Console.WriteLine("NO MATCHES!");
                                }
                                else
                                {
                                    Console.WriteLine(matches + " MATCHES");
                                }
                                
                                Console.WriteLine();
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();

                            }
                            
                        }
                        
                        
                    }
                    break;
                }

                break;
            }
        }


        //Shows the products
        private static void ShowProductsPage()
        {
            productManager?.Show();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nPress any key to return to the main menu...");
            Console.ResetColor();
            Console.ReadKey();
        }
        
        private static void AddProductPage()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("To enter a new product follow the steps | Any other key to return to the main menu...");
                Console.ResetColor();

                //Get product category from user input and validate
                Console.Write("Enter a Category: ");
                string? pcategory = Console.ReadLine();

                while (string.IsNullOrEmpty(pcategory))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Category name may not be empty");
                    Console.ResetColor();
                    Console.Beep();
                    Thread.Sleep(1500);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("To enter a new product follow the steps | Any other key to return to the main menu...");
                    Console.ResetColor();
                    Console.Write("Enter a Category: ");
                    pcategory = Console.ReadLine();

                }
                // If user enter q, show the product list, and get input
                if (pcategory?.ToLower() == "q")
                {
                    productManager?.Show();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\nTo enter a new product - enter \"P\" | To search for a product - enter: \"S\" | Any other key to return to the main menu...");
                    Console.ResetColor();
                    var key = Console.ReadKey().KeyChar.ToString().ToLower().Trim();
                    if (key == "p")
                    {
                        continue;
                    }
                    else if (key == "s")
                    {
                        SearchProductPage();
                        return;
                    }
                    else if (key == "q")
                    {
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
                //Get product name from user input and validate
                Console.Write("Enter a Product Name: ");
                string? pname = Console.ReadLine();
               
                while (string.IsNullOrEmpty(pname))
                {
                    
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Product name may not be empty");
                    Console.ResetColor();
                    Console.Beep();
                    Thread.Sleep(1500);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("To enter a new product follow the steps | Any other key to return to the main menu...");
                    Console.ResetColor();
                    Console.Write("Enter a Product Name: ");
                    pname = Console.ReadLine();

                }
                if (pname?.ToLower() == "q")
                {
                    productManager?.Show();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("To enter a new product - enter \"P\" | To search for a product - enter: \"S\" | To quit - enter: \"Q\"");
                    Console.ResetColor();
                    var key = Console.ReadKey().KeyChar.ToString().ToLower().Trim();
                    if (key == "p")
                    {
                        continue;
                    }
                    else if (key == "s")
                    {
                        SearchProductPage();
                        return;
                    }
                    else if (key == "q")
                    {
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
                // Get product price from user input and validate
                Decimal pprice = 0;
                Console.Write("Enter a Product Price: ");
                string? ppricestr = Console.ReadLine();
                while (true)
                {
                    //Check if it's empty
                    if (string.IsNullOrEmpty(ppricestr))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: Product price may not be empty and must be a valid decimal number");
                        Console.ResetColor();
                        Console.Beep();
                        Thread.Sleep(1500);
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("To enter a new product follow the steps | Any other key to return to the main menu...");
                        Console.ResetColor();
                        Console.Write("Enter a Price: ");
                        ppricestr = Console.ReadLine();
                        continue;
                    }
                    //Check for quit
                    if (ppricestr.Trim().ToLower() == "q")
                    {
                        break;
                    }

                    if (decimal.TryParse(ppricestr, out pprice))
                    {
                        //Check if input is negative
                        if (pprice < 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error: Price cannot be negative");
                            Console.ResetColor();
                            Console.Beep();
                            Thread.Sleep(1500);
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("To enter a new product follow the steps | Any other key to return to the main menu...");
                            Console.ResetColor();
                            Console.Write("Enter a Price: ");
                            ppricestr = Console.ReadLine();
                            continue;
                        }
                        break;
                        
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Product price may not be empty and must be a valid decimal number");
                    Console.ResetColor();
                    Console.Beep();
                    Thread.Sleep(1500);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("To enter a new product follow the steps | Any other key to return to the main menu...");
                    Console.ResetColor();
                    Console.Write("Enter a Price: ");
                    ppricestr = Console.ReadLine();
                    continue;
                    
                    
                    
                }
                if (ppricestr?.ToLower().Trim() == "q")
                {
                    productManager?.Show();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("To enter a new product - enter \"P\" | To search for a product - enter: \"S\" | To quit - enter: \"Q\"");
                    Console.ResetColor();
                    string key = Console.ReadKey().KeyChar.ToString().ToLower().Trim();

                        
                        if (key == "p")
                        {
                            continue;
                        }
                        else if (key == "s")
                        {
                            SearchProductPage();
                            return;
                        }
                        else if (key == "q")
                        {
                            return;
                        }
                        else
                        {
                            return;
                        }


                }

                //Add the product to the product manager
                try
                {
                    productManager?.Add(new Product(pname, pcategory, pprice));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("The product added successfully");
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.ResetColor();
                }
                finally
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                continue;
            }
        }
    }
}
