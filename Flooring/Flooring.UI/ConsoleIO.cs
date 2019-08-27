using Flooring.Models;
using Flooring.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.UI
{
    public class ConsoleIO
    {
        public static void DisplayOrderInformation(Order order)
        {
            Console.WriteLine($"{order.OrderNumber}");
            Console.WriteLine($"{order.CustomerName}");
            Console.WriteLine($"{order.State}");
            Console.WriteLine($"Product: {order.ProductType}");
            Console.WriteLine($"Materials: {order.MaterialCost}");
            Console.WriteLine($"Labor: {order.LaborCost}");
            Console.WriteLine($"Tax: {order.Tax}");
            Console.WriteLine($"Total: {order.Total}");
        }

        public string GetOrderDate()
        {
            Console.Write("Enter order date: ");
            string userEntry = Console.ReadLine();

            while (!DateTime.TryParse(userEntry, out DateTime dateTime))
            {
                Console.Write("Enter a date (MM/DD/YYYY): ");
                userEntry = Console.ReadLine();
                
            }

            return userEntry;
        }

        public string GetFutureAddDate()
        {
            string userEntry = GetOrderDate();

            DateTime.Parse(userEntry);

            while ((DateTime.Parse(userEntry)) < DateTime.Now)
            {
                Console.WriteLine("Date must be in the future");
                userEntry = GetOrderDate();
            }

            return userEntry;
        }

        public int GetOrderNumber()
        {
            Console.Write("Enter order number: ");
            string userEntry = Console.ReadLine();
            int orderNumber;

            while (!int.TryParse(userEntry, out orderNumber))
            {
                Console.Write("Must enter a number: ");
                userEntry = Console.ReadLine();
            }

            return orderNumber;
        }

        public string GetNewEditedName(string oldName)
        {
            Console.WriteLine("The previously entered information will be displayed. Enter new information or hit enter.");
            Console.Write($"{oldName}: ");
            string newName = Console.ReadLine();

            if (newName == "")
            {
                return oldName;
            }

            return newName;
        }

        public string GetNewEditedState(string oldState)
        {
            Console.Write($"{oldState}: ");
            string NewState = Console.ReadLine();

            if (NewState == "")
            {
                return oldState;
            }

            return NewState;
        }

        public string GetNewEditedProduct(string oldProduct)
        {
            Console.Write($"{oldProduct}: ");
            string newProduct = Console.ReadLine();

            if (newProduct == "")
            {
                return oldProduct;
            }

            return newProduct;
        }

        public decimal GetNewEditedArea(decimal oldArea)
        {
            Console.Write($"{oldArea}: ");
            string userEntry = Console.ReadLine();

            if (userEntry == "")
            {
                return oldArea;
            }
            decimal NewArea;
            while (!decimal.TryParse(userEntry, out NewArea))
            {
                Console.Write("Must enter a number: ");
                userEntry = Console.ReadLine();
            }

            return NewArea;
            
        }

        public string AddCustomerName()
        {
            Console.Write("Enter customer name: ");
            string customerName = Console.ReadLine();

            while (customerName == "")
            {
                Console.Write("Must enter a name: ");
                customerName = Console.ReadLine();
            }

            return customerName;
        }

        public string AddStateName()
        {
            Console.Write("Enter state: ");
            string state = Console.ReadLine();

            while (state == "")
            {
                Console.Write("Must enter state: ");
                state = Console.ReadLine();
            }

            return state;
        }

        public decimal AddArea()
        {
            Console.Write("Enter area: ");
            string userEntry = Console.ReadLine();
            decimal Area;
            while (!decimal.TryParse(userEntry,out Area))
            {
                Console.Write("Must enter a number: ");
                userEntry = Console.ReadLine();
            }

            return Area;
        }
    }
}
