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
            Response response = new Response();
            ConsoleIO console = new ConsoleIO();
            Console.Clear();
            Console.WriteLine("Look up an order using the order date.");
            Console.WriteLine("____________________________________");
            string orderDate = console.GetOrderDate();

            response = manager.ValidDate(orderDate);
            if (response.Success == false)
            {
                Console.WriteLine(response.Message);
                return;
            }

            int orderNumber = console.GetOrderNumber();

               response =  manager.DisplayOrder( orderDate, orderNumber);

            if (response.Success)
            {
                ConsoleIO.DisplayOrderInformation(response.Order);
            }

            else
            {
                Console.WriteLine(response.Message);
            }
        }
    }
}
