using Flooring.BLL;
using Flooring.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.UI.WorkFlows
{
    public class DisplayOrderWorkFlow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();

            Console.Clear();
            Console.WriteLine("Look up an order using the order date.");
            Console.WriteLine("____________________________________");
            Console.WriteLine("Enter order date here: ");
            string orderDate = Console.ReadLine();

            DisplayOrderResponse response = manager.DisplayOrder(orderDate);

            if (response.Success)
            {
                ConsoleIO.DisplayOrderInformation(response.OrderDate);
            }
            else
            {
                Console.WriteLine("That order does not exist");
            }
        }
    }
}
