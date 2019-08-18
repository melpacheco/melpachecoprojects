using Flooring.UI.WorkFlows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.UI
{
    public class Menu
    {
        public static void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("SG Flooring Program");
                Console.WriteLine("___________________________");
                Console.WriteLine("1. Display an Order");
                Console.WriteLine("2. Add an Order");
                Console.WriteLine("3. Edit an Order");
                Console.WriteLine("4. Remove an Order");

                Console.WriteLine("\n Q to quit");
                Console.Write("\n Enter your selection here: ");
                string UserInput = Console.ReadLine();

                switch (UserInput)
                {
                    case "1":
                        DisplayOrderWorkFlow displayOrderWorkFlow = new DisplayOrderWorkFlow();
                        displayOrderWorkFlow.Execute();
                        Console.ReadLine();
                        break;
                    case "2":
                        AddOrderWorkFlow addOrderWorkFlow = new AddOrderWorkFlow();
                        addOrderWorkFlow.Execute();
                        Console.ReadLine();
                        break;
                    case "3":
                        //EditOrder
                        break;
                    case "4":
                        // remove an order
                        break;
                    case "Q":
                        return;
                    default:
                        break;
                }
            }
        }
    }
}
