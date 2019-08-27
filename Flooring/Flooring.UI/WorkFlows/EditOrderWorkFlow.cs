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
            Response response = new Response();
            Response ToBeEditedOrder = new Response();
            ToBeEditedOrder.Order = new Order();
            Response ProductValidation = new Response();
            OrderManager manager = OrderManagerFactory.Create();
            Response newOrder = new Response();
            newOrder.Order = new Order();
            ConsoleIO console = new ConsoleIO();

            string orderDate = console.GetOrderDate();

            int orderNumber = console.GetOrderNumber();

            ToBeEditedOrder = manager.LoadOrder(orderDate, orderNumber);

            if (ToBeEditedOrder.Success != true)
            {
                Console.WriteLine(ToBeEditedOrder.Message);
                return;
            }

            newOrder.Order.CustomerName = console.GetNewEditedName(ToBeEditedOrder.Order.CustomerName);

            newOrder.Order.State = console.GetNewEditedState(ToBeEditedOrder.Order.State);

            response = manager.CheckStateTax(newOrder.Order.State);
                if (response.Success == false)
                {
                    Console.WriteLine(response.Message);
                    return;

                }


            newOrder.Order.ProductType = console.GetNewEditedProduct(ToBeEditedOrder.Order.ProductType);

            ProductValidation = manager.IsValidProduct(newOrder.Order.ProductType);

            if(ProductValidation.Success != true)
            {
                Console.WriteLine(ProductValidation.Message);
                return;
            }

            newOrder.Order.Area = console.GetNewEditedArea(ToBeEditedOrder.Order.Area);

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

