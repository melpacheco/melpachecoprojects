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
    public class EditOrderWorkFlow
    {
        public void Execute()
        {
            Response ToBeEditedOrder = new Response();
            Response ProductValidation = new Response();
            OrderManager manager = OrderManagerFactory.Create();
            Response newOrder = new Response();
            newOrder.Order = new Order();

            Console.WriteLine("Enter the order date here: ");
            string orderDate = Console.ReadLine();

            Console.WriteLine("Enter the order number here: ");
            string userNumber = Console.ReadLine();
            int.TryParse(userNumber, out int orderNumber);

            ToBeEditedOrder = manager.LoadOrder(orderDate, orderNumber);

            if (ToBeEditedOrder.Success != true)
            {
                Console.WriteLine(ToBeEditedOrder.Message);
                return;
            }

            Console.WriteLine("The order will be displayed. Please enter any changes to that field. If none, just hit enter.");
            Console.Write($"CustomerName:{ToBeEditedOrder.Order.CustomerName}: ");
            newOrder.Order.CustomerName = Console.ReadLine();

            Console.Write($"State: {ToBeEditedOrder.Order.State}: ");
            newOrder.Order.State = Console.ReadLine();

            Console.Write($"Product Type: {ToBeEditedOrder.Order.ProductType}");
            newOrder.Order.ProductType = Console.ReadLine();
            ProductValidation = manager.IsValidProduct(newOrder.Order.ProductType);

            if(ProductValidation.Success != true)
            {
                Console.WriteLine(ProductValidation.Message);
                return;
            }

            Console.Write($"Area: {ToBeEditedOrder.Order.Area}: ");
            newOrder.Order.Area = decimal.Parse(Console.ReadLine());



            //NewFieldsResponse = manager.Edit(editOrderResponse);
            newOrder = manager.Edit(newOrder.Order, ToBeEditedOrder.Order);
            if (newOrder.Success == true)
            {
                ConsoleIO.DisplayOrderInformation(newOrder.Order);
                Console.WriteLine("Enter 1 to save, enter 2 to return cancel edit and return to main menu: ");
                string okayToSave = Console.ReadLine();
                switch (okayToSave)
                {
                    case "1":
                        ToBeEditedOrder.Order.OrderDate = orderDate;
                        manager.OkayedToRemove(ToBeEditedOrder.Order);
                        newOrder.Order.OrderDate = orderDate;
                        manager.SaveOrder(newOrder.Order);
                        Console.WriteLine("Order saved!");
                        Console.ReadLine();
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
                Console.WriteLine(newOrder.Message);
            }



        }
    }
}

