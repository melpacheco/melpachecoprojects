using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main()
        {
            //PrintAllProducts();
            //PrintAllCustomers();

            //Use these 2 methods so you can test your linq queries.
            //If you do Console.Writeline(Inemuerable); then you won't loop through the data.
            //PrintCustomerInformation();
            //PrintProductInformation();

            //I also created a method for you to make testing less of a pain in the ass.
            //I didn't type all of them out i just looped and printed it out to the console and copy
            //and pasted it to make the method. See below. That's how you work lazy!
            //for (int i = 1; i < 32; i++)
            //{
            //    Console.WriteLine($"case {i} :");
            //    Console.WriteLine($"Excercise{i}();");
            //    Console.WriteLine("break;");
            //}

            //This method will make testing a lot easier. You're welcome.
            DisplayExcerciseData();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }


        #region "Sample Code"
        /// <summary>
        /// Sample, load and print all the product objects
        /// </summary>
        static void PrintAllProducts()
        {
            List<Product> products = DataLoader.LoadProducts();
            PrintProductInformation(products);
        }

        

        /// <summary>
        /// This will print a nicely formatted list of products
        /// </summary>
        /// <param name="products">The collection of products to print</param>
        static void PrintProductInformation(IEnumerable<Product> products)
        {
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var product in products)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock);
            }

        }

        /// <summary>
        /// Sample, load and print all the customer objects and their orders
        /// </summary>
        static void PrintAllCustomers()
        {
            var customers = DataLoader.LoadCustomers();
            PrintCustomerInformation(customers);
        }

        /// <summary>
        /// This will print a nicely formated list of customers
        /// </summary>
        /// <param name="customers">The collection of customer objects to print</param>
        static void PrintCustomerInformation(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine(customer.CompanyName);
                Console.WriteLine(customer.Address);
                Console.WriteLine("{0}, {1} {2} {3}", customer.City, customer.Region, customer.PostalCode, customer.Country);
                Console.WriteLine("p:{0} f:{1}", customer.Phone, customer.Fax);
                Console.WriteLine();
                Console.WriteLine("\tOrders");
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine("\t{0} {1:MM-dd-yyyy} {2,10:c}", order.OrderID, order.OrderDate, order.Total);
                }
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }
        }
        #endregion

        /// <summary>
        /// Print all products that are out of stock.
        /// </summary>
        static void Exercise1()
        {
            

            

            var outofstock = DataLoader.LoadProducts().Where(p => p.UnitsInStock == 0);

            PrintProductInformation(outofstock);
           //done 

        }

        /// <summary>
        /// Print all products that are in stock and cost more than 3.00 per unit.
        /// </summary>
        static void Exercise2()
        {
          

            var ThreeDollars = DataLoader.LoadProducts().Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3.00M);

            PrintProductInformation(ThreeDollars);

            //done

        }

        /// <summary>
        /// Print all customer and their order information for the Washington (WA) region.
        /// </summary>
        static void Exercise3()
        {


            var WARegion = DataLoader.LoadCustomers().Where(p => p.Region == "WA");

            PrintCustomerInformation(WARegion);

            //done

        }

        /// <summary>
        /// Create and print an anonymous type with just the ProductName
        /// </summary>
        static void Exercise4()
        {

            
            var NewType = from p in DataLoader.LoadProducts()
                          select new
                          {
                              ProductName = p.ProductName
                          };

            foreach (var p in NewType)
            {
                Console.WriteLine(p);

            }
            //done
        }

        /// <summary>
        /// Create and print an anonymous type of all product information but increase the unit price by 25%
        /// </summary>
        static void Exercise5()
        {

            var NewType = from p in DataLoader.LoadProducts()
                          
                          select new
                          {
                              
                              ProductID = p.ProductID,
                              ProductName = p.ProductName,
                              ProductCategory = p.Category,
                              ProductUnitPrice = (p.UnitPrice * .25M + p.UnitPrice),
                              ProductUnitInStock = p.UnitsInStock

                          };

            foreach (var p in NewType)
            {
                Console.WriteLine(p);

            }
            //done

        }

        /// <summary>
        /// Create and print an anonymous type of only ProductName and Category with all the letters in upper case
        /// </summary>
        static void Exercise6()
        {       

            var UpperCase = from p in DataLoader.LoadProducts()

                          select new
                          {        
                              ProductName = p.ProductName.ToUpper(),
                              ProductCategory = p.Category.ToUpper(),   
                          };

            foreach (var p in UpperCase)
            {
                Console.WriteLine(p);
            }

            //done

        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra bool property ReOrder which should 
        /// be set to true if the Units in Stock is less than 3
        /// 
        /// Hint: use a ternary expression
        /// </summary>
        static void Exercise7()
        {

            var ReOrder = from p in DataLoader.LoadProducts()

                          select new
                          {

                              ProductID = p.ProductID,
                              ProductName = p.ProductName,
                              ProductCategory = p.Category,
                              ProductUnitPrice = p.UnitPrice,
                              ProductUnitInStock = p.UnitsInStock,
                              ProductOrder = p.UnitsInStock < 3 ? true : false,
                              
                          };

            foreach (var p in ReOrder)
            {
                Console.WriteLine(p);
            }
       //done

        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra decimal called 
        /// StockValue which should be the product of unit price and units in stock
        /// </summary>
        static void Exercise8()
        {
            var newValue = DataLoader.LoadProducts().Select(p => new
            {
                ProductID = p.ProductID,
                ProductName = p.ProductName,
                ProductCategory = p.Category,
                ProductUnitPrice = p.UnitPrice,
                ProductUnitInStock = p.UnitsInStock,
                StockValue = p.UnitsInStock * p.UnitPrice,
            });

                        
            foreach (var p in newValue)
            {
                Console.WriteLine(p);
            }
    
            //done
        }

        /// <summary>
        /// Print only the even numbers in NumbersA
        /// </summary>
        static void Exercise9()
        {

            var EvenNumbers = DataLoader.NumbersA.Where(n => n % 2 == 0); 

            foreach (var p in EvenNumbers)
            {
                Console.WriteLine(p);
            }
            //done
        }

        /// <summary>
        /// Print only customers that have an order whos total is less than $500
        /// </summary>
        static void Exercise10()
        {
            //var orders = from c in DataLoader.LoadCustomers()
            //             from o in c.Orders
            //             where o.Total < 500m
            //             select c;

            // var orders = DataLoader.LoadCustomers().Where(o => o.Orders.Where(c => c.Total < 500m)
            var customers = DataLoader.LoadCustomers();

            var lessThanFiveHundred = customers.Where(o => o.Orders.Any(t => t.Total < 500m));
            foreach (var item in customers)
            {
                Console.WriteLine(item.CompanyName);
            }
            
        }

        /// <summary>
        /// Print only the first 3 odd numbers from NumbersC
        /// </summary>
        static void Exercise11()
        {

            var topodd = DataLoader.NumbersC.Where(n => n % 2 != 0).Take(3);
            //var topodd = from n in DataLoader.NumbersC
            //             where n % 2 != 0
            //             select n;
            //var first3 = topodd.Take(3);

            foreach (var p in topodd)
            {
                Console.WriteLine(p);
            }
                        
            //done
        }

        /// <summary>
        /// Print the numbers from NumbersB except the first 3
        /// </summary>
        static void Exercise12()
        {

            var numbers = DataLoader.NumbersB.Skip(3);

            foreach (var n in numbers)
            {
                Console.WriteLine(n);
            }
            //done
        }

        /// <summary>
        /// Print the Company Name and most recent order for each customer in Washington
        /// </summary>
        static void Exercise13()
        {

   
            var customersInWA = DataLoader.LoadCustomers().Where(c => c.Region == "WA");

            foreach (var item in customersInWA)
            {
                var recentOrder = item.Orders.OrderByDescending(mR => mR.OrderDate)
                                                .FirstOrDefault();

       
                Console.WriteLine(item.CompanyName);
                Console.WriteLine(recentOrder.OrderID);


            }



        }

        /// <summary>
        /// Print all the numbers in NumbersC until a number is >= 6
        /// </summary>
        static void Exercise14()
        {

            var list = DataLoader.NumbersC.TakeWhile(n => n < 6);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
                       


            
        }

        /// <summary>
        /// Print all the numbers in NumbersC that come after the first number divisible by 3
        /// </summary>
        static void Exercise15()
        {
            var list = DataLoader.NumbersC.SkipWhile(n => n % 3 != 0);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }


        }

        /// <summary>
        /// Print the products alphabetically by name
        /// </summary>
        static void Exercise16()
        {
            var alpha = DataLoader.LoadProducts();

            var list = alpha.OrderBy(p => p.ProductName);

            PrintProductInformation(list);

        }

        /// <summary>
        /// Print the products in descending order by units in stock
        /// </summary>
        static void Exercise17()
        {
            var products = DataLoader.LoadProducts();

            var list = products.OrderByDescending(s => s.UnitsInStock);

            PrintProductInformation(list);

        }

        /// <summary>
        /// Print the list of products ordered first by category, then by unit price, from highest to lowest.
        /// </summary>
        static void Exercise18()
        {
            //var products = DataLoader.LoadProducts();

            //var groupings = from p in products
            //                orderby p.Category, p.UnitPrice
            //                group p by p.Category;

            var groupings = DataLoader.LoadProducts().OrderBy(p => p.Category).OrderBy(p => p.UnitPrice).GroupBy(p => p.Category);

            foreach (var group in groupings)
            {
                Console.WriteLine(group.Key);

                foreach (var g in group)
                {
                    Console.WriteLine("\t{0}",g.UnitPrice);
                }

            }
                           
    

        }

        /// <summary>
        /// Print NumbersB in reverse order
        /// </summary>
        static void Exercise19()
        {
            var reverse = DataLoader.NumbersB.Reverse();

            foreach (var n in reverse)
            {
                Console.WriteLine(n);
            }
        }

        /// <summary>
        /// Group products by category, then print each category name and its products
        /// ex:
        /// 
        /// Beverages
        /// Tea
        /// Coffee
        /// 
        /// Sandwiches
        /// Turkey
        /// Ham
        /// </summary>
        static void Exercise20()
        {
            //var products = DataLoader.LoadProducts();

            //var list = from p in products
            //           group p by p.Category;

            var list = DataLoader.LoadProducts().GroupBy(p => p.Category);

            foreach (var group in list)
            {
                Console.WriteLine(group.Key);

                foreach (var i in group)
                {
                    Console.WriteLine("\t{0}", i.ProductName);
                }
            }

        }

        /// <summary>
        /// Print all Customers with their orders by Year then Month
        /// ex:
        /// 
        /// Joe's Diner
        /// 2015
        ///     1 -  $500.00
        ///     3 -  $750.00
        /// 2016
        ///     2 - $1000.00
        /// </summary>
        static void Exercise21()
        {
            //var customers = DataLoader.LoadCustomers();

            //var list = from c in customers
            //           from o in c.Orders
            //           orderby o.OrderDate.Year, o.OrderDate.Month
            //           select c;

            

            //PrintCustomerInformation(list);

            
            

        }

        /// <summary>
        /// Print the unique list of product categories no duplicates
        /// </summary>
        static void Exercise22()
        {
            var products = DataLoader.LoadProducts();
            var list = products.Select(p => p.Category).Distinct();

            foreach (var i in list)
            {
                Console.WriteLine(i);
            }


        }

        /// <summary>
        /// Write code to check to see if Product 789 exists
        /// </summary>
        static void Exercise23()
        {
            var list = DataLoader.LoadProducts().Select(p => p.ProductID);

            Console.WriteLine(list.Contains(789));

           

        }

        /// <summary>
        /// Print a list of categories that have at least one product out of stock
        /// </summary>
        static void Exercise24()
        {
            //var products = DataLoader.LoadProducts();

            //var list = from p in products
            //           where p.UnitsInStock == 0
            //           select p.Category;

            var list = DataLoader.LoadProducts().Where(p => p.UnitsInStock == 0).Select(p => p.Category);

            foreach (var i in list)
            {
                Console.WriteLine(i);
            }

        }

        /// <summary>
        /// Print a list of categories that have no products out of stock
        /// </summary>
        static void Exercise25()
        {
            //var products = DataLoader.LoadProducts();

            //var list = from p in products
            //           where p.UnitsInStock != 0
            //           select p.Category;

            var list = DataLoader.LoadProducts().Where(p => p.UnitsInStock != 0).Select(p => p.Category);

            foreach (var i in list)
            {
                Console.WriteLine(i);
            }
        }

        /// <summary>
        /// Count the number of odd numbers in NumbersA
        /// </summary>
        static void Exercise26()
        {
            //var count = from n in DataLoader.NumbersA
            //            where n % 2 != 0
            //            select n;

            var count = DataLoader.NumbersA.Where(n => n % 2 != 0);

            Console.WriteLine(count.Count());

            

        }

        /// <summary>
        /// Create and print an anonymous type containing CustomerId and the count of their orders
        /// </summary>
        static void Exercise27()
        {
            //var customers = DataLoader.LoadCustomers();

            //var list = from c in customers
            //           select new
            //           {
            //               CustomerId = c.CustomerID,
            //               OrderCount = c.Orders.Count()
            //           };

            var list = DataLoader.LoadCustomers().Select(c => new
            {
                CustomerId = c.CustomerID,
                OrderCount = c.Orders.Count()
            });

            foreach (var i in list)
            {
                Console.WriteLine(i);
            }

        }

        /// <summary>
        /// Print a distinct list of product categories and the count of the products they contain
        /// </summary>
        static void Exercise28()
        {
            //var products = DataLoader.LoadProducts();

            //var list = from p in products
            //           group p by p.Category;

            var list = DataLoader.LoadProducts().GroupBy(p => p.Category);
                       

            foreach (var group in list)
            {

                
                Console.WriteLine(group.Key);
                Console.WriteLine(group.Count());

            }


        }

        /// <summary>
        /// Print a distinct list of product categories and the total units in stock
        /// </summary>
        static void Exercise29()
        {
            //var products = DataLoader.LoadProducts();

            //var list = from p in products
            //           group p.UnitsInStock by p.Category;

            

            //foreach (var group in list)
            //{
            //    Console.WriteLine(group.Key);
            //    Console.WriteLine(group.Sum());
            //}

        }

        /// <summary>
        /// Print a distinct list of product categories and the lowest priced product in that category
        /// </summary>
        static void Exercise30()
        {
            var products = DataLoader.LoadProducts();

            var list = from p in products
                       group p by p.Category;

           foreach (var item in list)
            {
                var lowestprice = item.OrderBy(o => o.UnitPrice).FirstOrDefault();

                Console.WriteLine(item.Key);
                Console.WriteLine(lowestprice.ProductName);
               
            }
        }

        /// <summary>
        /// Print the top 3 categories by the average unit price of their products
        /// </summary>
        static void Exercise31()
        {
            var list = DataLoader.LoadProducts().GroupBy(p => p.Category);

            var averagePrice = list.OrderByDescending(x => x.Average(l => l.UnitPrice)).Take(3);

            foreach (var item in averagePrice)
            {
                Console.WriteLine(item.Key);
            }

        }


        static void DisplayExcerciseData()
        {
            bool keepGoing = true;
            int choice; 

            while (keepGoing)
            {
                Console.WriteLine("Enter 0 to exit. Otherwise, enter 1 - 31 to start excercise.");
                string response = Console.ReadLine();

                if(!int.TryParse(response, out choice))
                {
                    //force the switch statement to say invalid if a correct choice is not entered.
                    choice = -1;
                }

                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Thanks for playing.");
                        keepGoing = false;
                        break;
                    case 1:
                        Exercise1();
                        break;
                    case 2:
                        Exercise2();
                        break;
                    case 3:
                        Exercise3();
                        break;
                    case 4:
                        Exercise4();
                        break;
                    case 5:
                        Exercise5();
                        break;
                    case 6:
                        Exercise6();
                        break;
                    case 7:
                        Exercise7();
                        break;
                    case 8:
                        Exercise8();
                        break;
                    case 9:
                        Exercise9();
                        break;
                    case 10:
                        Exercise10();
                        break;
                    case 11:
                        Exercise11();
                        break;
                    case 12:
                        Exercise12();
                        break;
                    case 13:
                        Exercise13();
                        break;
                    case 14:
                        Exercise14();
                        break;
                    case 15:
                        Exercise15();
                        break;
                    case 16:
                        Exercise16();
                        break;
                    case 17:
                        Exercise17();
                        break;
                    case 18:
                        Exercise18();
                        break;
                    case 19:
                        Exercise19();
                        break;
                    case 20:
                        Exercise20();
                        break;
                    case 21:
                        Exercise21();
                        break;
                    case 22:
                        Exercise22();
                        break;
                    case 23:
                        Exercise23();
                        break;
                    case 24:
                        Exercise24();
                        break;
                    case 25:
                        Exercise25();
                        break;
                    case 26:
                        Exercise26();
                        break;
                    case 27:
                        Exercise27();
                        break;
                    case 28:
                        Exercise28();
                        break;
                    case 29:
                        Exercise29();
                        break;
                    case 30:
                        Exercise30();
                        break;
                    case 31:
                        Exercise31();
                        break;
                    default:
                        Console.WriteLine("That was not a valid entry. Try again.");
                        break;
                }
            }
        }
    }
}
