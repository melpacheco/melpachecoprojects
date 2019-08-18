using Flooring.Models;
using Flooring.Models.InterFaces;
using Flooring.Models.Responses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Data
{
   public class ProdOrderRepository : IOrderRepository
    {
        private static Order _order = new Order();


        public static string CreateNewOrder(AddOrderResponse order)
        {
      
            string path = @"C:\Users\MelPacheco\Documents\SoftWareGuildAssignments\melissa - pacheco - individual - work\FlooringOrders"
                            + DateTime.Today;

            if (!File.Exists(path))
            {
                File.Create(path);

            }

            using (StreamWriter write = new StreamWriter(path))
            {
                write.WriteLine("OrderNumber, CustomerName, State, TaxRate, ProductType, Area, CostPerSquareFoot, LacorCostPerSquareFoot, MaterialCost, LaborCost, Tax, Total");
                write.WriteLine(order.OrderDate.ToString(), order.CustomerName, order.State, order.TaxRate, order.ProductType, order.Area, order.CostPerSquareFoot, order.LaborCostPerSquareFoot, order.MaterialCost, order.LaborCost, order.Tax, order.Total);
            }

            return path;

        }

        public List<Order> LoadList()
        {
            throw new NotImplementedException();
        }

        public Order LoadOrder(string OrderNumber)
        {

    

            Order order = new Order();
            if (File.Exists(OrderNumber))
            {
                string[] rows = File.ReadAllLines(OrderNumber);

                for (int i = 1; i < rows.Length; i++)
                {
                    string[] columns = rows[i].Split(',');


                    order.OrderNumber = columns[0];
                    order.CustomerName = columns[1];
                    order.State = columns[2];
                    order.TaxRate = decimal.Parse(columns[3]);
                    order.ProductType = columns[4];
                    order.Area = decimal.Parse(columns[5]);
                    order.CostPerSquareFoot = decimal.Parse(columns[6]);
                    order.LaborCostPerSquareFoot = decimal.Parse(columns[7]);
                    order.MaterialCost = decimal.Parse(columns[8]);
                    order.LaborCost = decimal.Parse(columns[9]);
                    order.Tax = decimal.Parse(columns[10]);
                    order.Total = decimal.Parse(columns[11]);

                }
            }


            else
            {
                Console.WriteLine("Could not find the file at {0}", OrderNumber);
                return null;
            }

            return order;
        }

        public Order LoadOrder(int OrderNumber)
        {
            throw new NotImplementedException();
        }

        public void SaveOrder(Order order)
        {
            _order = order;
        }
    }
}

