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
            Console.Clear();
            Console.WriteLine("Look up an order using the order date.");
            Console.WriteLine("____________________________________");
            Console.Write("Enter order date here: ");
            string orderDate = Console.ReadLine();
            response = manager.ValidDate(orderDate);
            if (response.Success == false)
            {
                Console.WriteLine(response.Message);
                return;
            }

            
            Console.Write("Enter order number here: ");
            string userNumber = Console.ReadLine();
            int.TryParse(userNumber, out int orderNumber);

            

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
