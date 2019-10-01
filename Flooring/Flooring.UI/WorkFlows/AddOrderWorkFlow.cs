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
            ConsoleIO console = new ConsoleIO();
            Order order = new Order();
            Response response = new Response();

            order.OrderDate = console.GetFutureAddDate();
   
            order.CustomerName = console.AddCustomerName();

            order.State = console.AddStateName();

            response = manager.CheckStateTax(order.State);
            if (response.Success == false)
            {
                Console.WriteLine(response.Message);
                return;
                
            }
            

            Console.WriteLine("The following are the available types of material: ");
            foreach (var p in manager.ProductAvailability())
            {
                Console.WriteLine($"{p.ProductType}");
            }
            do
            {
                Console.WriteLine("Enter the Product here: ");
                order.ProductType = Console.ReadLine();
                response = manager.IsValidProduct(order.ProductType);
            }

            while (response.Success == false);

            order.Area = console.AddArea();

           response = manager.AddOrder(order);
          

            if (response.Success == true)
            {
              
                ConsoleIO.DisplayOrderInformation(response.Order);
                Console.WriteLine("Enter 1 to save this order, 2 to cancel order and return to menu: ");
                string okayToSave = Console.ReadLine();

                   switch (okayToSave)
                {
                    case "1":

                        manager.SaveOrder(response.Order);
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
