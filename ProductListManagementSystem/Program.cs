using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProductListManagementSystem
{
    internal class Program
    {
        static ProductManager? productManager = new ProductManager();
        private static readonly string menuText =
    @"=============================
Product Management System
=============================

1. Add Product
2. Show Products
3. Search Product
4. Edit Product
5. Delete Product
6. Statistics
7. Save Products
8. Load Products
9. Exit
";



        static void Main(string[] args)
        {


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
                        EditProductPage();
                        break;
                    case '5':
                        DeleteProductPage();
                        break;
                    case '6':
                        StatisticsPage();
                        break;
                    case '7':
                        SaveProductsPage();
                        break;
                    case '8':
                        LoadProductsPage();
                        break;
                    case '9':
                        return;
                    default:
                        Console.Beep();
                        break;

                }
            }

            static void PrintMainMenu() => Console.WriteLine(menuText);



        }

        private static void LoadProductsPage()
        {
            throw new NotImplementedException();
        }

        private static void SaveProductsPage()
        {
            throw new NotImplementedException();
        }

        private static void StatisticsPage()
        {
            throw new NotImplementedException();
        }

        private static void DeleteProductPage()
        {
            throw new NotImplementedException();
        }

        private static void EditProductPage()
        {
            throw new NotImplementedException();
        }

        private static void SearchProductPage()
        {
            throw new NotImplementedException();
        }


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
                Console.WriteLine("To enter a new product follow the steps | To quit - enter: \"Q\"");
                Console.ResetColor();

                //Get product category from user input and validate
                Console.Write("Enter a Category: ");
                string? pcategory = Console.ReadLine();

                while (string.IsNullOrEmpty(pcategory))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Category name may not be empty");
                    Console.ResetColor();
                    Console.Write("Enter a Category: ");
                    pcategory = Console.ReadLine();

                }
                // If user enter q, show the product list, and get input
                if (pcategory?.ToLower() == "q")
                {
                    productManager?.Show();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\nTo enter a new product - enter \"P\" | To search for a product - enter: \"S\" | To quit - enter: \"Q\"");
                    Console.ResetColor();
                    var key = Console.ReadKey().KeyChar.ToString().ToLower().Trim();
                    if (key == "p")
                    {
                        continue;
                    }
                    else if (key == "s")
                    {
                        SearchProductPage();
                    }
                    else if (key == "q")
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
                    }
                    else if (key == "q")
                    {
                        return;
                    }
                }
                // Get product price from user input and validate
                Decimal pprice;
                Console.Write("Enter a Product Price: ");
                string? ppricestr = Console.ReadLine();
                // "q" is the only acceptable character
                while (string.IsNullOrEmpty(ppricestr) || (!decimal.TryParse(ppricestr, out pprice) && ppricestr?.ToLower().Trim() != "q"))
                {
                    if (!decimal.TryParse(ppricestr, out pprice))
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Product price may not be empty and must be a valid decimal number");
                    Console.ResetColor();
                    Console.Write("Enter a Price: ");
                    ppricestr = Console.ReadLine();
                }
                if (ppricestr?.ToLower() == "q")
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
                    }
                    else if (key == "q")
                    {
                        return;
                    }

                }

                //Add the product to the product manager and handle any exceptions
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
