using Flooring.BLL;
using Flooring.Data;
using Flooring.Models;
using Flooring.Models.InterFaces;
using Flooring.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.UI.WorkFlows
{
   public class AddOrderWorkFlow
    {
    
        public void Execute()
        {
            Console.Clear();
            OrderManager manager = OrderManagerFactory.Create();
            
            Order order = new Order();
           

            Console.WriteLine("Enter the Order Date Here: ");
            order.OrderNumber = Console.ReadLine();
            

            Console.WriteLine("Enter the Customer Name here: ");
            order.CustomerName = Console.ReadLine();

            Console.WriteLine("Enter the State Here: ");
            order.State = Console.ReadLine();

            Console.WriteLine("The following are the available types of material: ");
            foreach (var p in manager.GetProductList())
            {
                Console.WriteLine($"{p.ProductType}");
            }
            
            Console.WriteLine("Enter the Product here: ");
            order.ProductType = Console.ReadLine();


            Console.WriteLine("Enter the Area Here: ");
            order.Area = Decimal.Parse(Console.ReadLine());

            AddOrderResponse response = manager.AddOrder(order);

            if (response.Success == true)
            {

                //save order
                Console.WriteLine("Please verify the following information.");
                Console.WriteLine($"Order Date: { response.OrderDate}");
                Console.WriteLine($"Order Number: {response.OrderNumber}");
                Console.WriteLine($"Customer Name: {response.CustomerName}");
                Console.WriteLine($"State: {response.State}");
                Console.WriteLine($"Product:{response.ProductType}");
                Console.WriteLine($"Materials:{response.MaterialCost}");
                Console.WriteLine($"Labor:{response.LaborCost}");
                Console.WriteLine($"Tax:{response.Tax}");
                Console.WriteLine($"Total:{response.Total}");
                string okayToSave = Console.ReadLine();
                switch (okayToSave)
                {
                    case "1":
                        manager.SaveOrder(order);
                        break;
                    case "2":
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number: ");
                        break;
                }

            }
            else
            {
                
                Console.WriteLine("An error has occured.");
                Console.WriteLine(response.Message);
            }

            
        }
    }
}
