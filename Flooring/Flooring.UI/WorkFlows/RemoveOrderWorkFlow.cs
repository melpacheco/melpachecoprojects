using Flooring.BLL;
using Flooring.Models;
using Flooring.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.UI.WorkFlows
{
    public class RemoveOrderWorkFlow
    {
        public void Execute()
        {
            Order orderToBeRemoved = new Order();
            Response response = new Response();
            OrderManager manager = OrderManagerFactory.Create();

            Console.WriteLine("Enter order date: ");
            string orderDate = Console.ReadLine();
            response = manager.ValidDate(orderDate);
            if(response.Success == false)
            {
                Console.WriteLine(response.Message);
                return;
            }

            Console.WriteLine("Enter order number: ");
            string userNumber = Console.ReadLine();
            int.TryParse(userNumber, out int orderNumber);

            response = manager.LoadOrder(orderDate, orderNumber);
            if (response.Success != true)
            {
                Console.WriteLine(response.Message);
                return;
            }

            response = manager.RemoveOrder(orderDate, orderNumber);

            if (response.Success == true)
            {
                ConsoleIO.DisplayOrderInformation(response.Order);
                Console.WriteLine("Enter 1 to delete this order and 2 to cancel and return to main menu: ");
                string OkayToRemove = Console.ReadLine();
                switch (OkayToRemove)
                {
                    case "1":
                        response.Order.OrderDate = orderDate;
                       response = manager.OkayedToRemove(response.Order);
                        Console.WriteLine(response.Message);
                            break;  
                    default:
                        break;
                }
            }

            else
            {
                Console.WriteLine("An error has occurred: ");
                Console.WriteLine(response.Message);
                Console.ReadLine();
            }
        }
    }
}
