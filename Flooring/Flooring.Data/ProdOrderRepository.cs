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
        private static List<Order> _OrderList;
       

        public Response RemoveOrder(Order order)
        {
            _OrderList = LoadList(order.OrderDate);
            _OrderList.RemoveAll(p => p.OrderNumber == order.OrderNumber);
            WriteFile(_OrderList, order.OrderDate);
            Response response = new Response();
            response.Success = true;
            response.Message = "Order has been deleted";
            return response;
        }

        public void SaveOrder(Order order)
        {

            LoadList(order.OrderDate);
            //int OrderNumber = _OrderList.Count();
            //order.OrderNumber = OrderNumber++.ToString();
            // NEED TO PUT ORDERNUMBERMETHOD HERE
            _OrderList.Add(order);
            WriteFile(_OrderList, order.OrderDate);
        }

        public void WriteFile(List<Order> ordersList, string OrderDate)
        {
            DateTime date = DateTime.Parse(OrderDate);

            string path = $"C:\\Users\\MelPacheco\\Documents\\SoftWareGuildAssignments\\melissa-pacheco-individual-work\\online-net-melpacheco\\Flooring\\FlooringOrders\\Orders_{date.ToString("MMddyyyy")}.txt";
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }

            using (TextWriter write = new StreamWriter(path))
            {
                write.WriteLine("OrderNumber, CustomerName, State, TaxRate, ProductType, Area, CostPerSquareFoot, LacorCostPerSquareFoot, MaterialCost, LaborCost, Tax, Total");
                foreach (var s in _OrderList)
                {
                    write.WriteLine($"{s.OrderNumber},{s.CustomerName},{s.State},{s.TaxRate},{s.ProductType},{s.Area},{s.CostPerSquareFoot},{s.LaborCostPerSquareFoot},{s.MaterialCost},{s.LaborCost},{s.Tax},{s.Total}");

                }
            }
        }

        public List<Order> LoadList(string OrderDate)
        {

            DateTime date = DateTime.Parse(OrderDate);

            string path = $"C:\\Users\\MelPacheco\\Documents\\SoftWareGuildAssignments\\melissa-pacheco-individual-work\\online-net-melpacheco\\Flooring\\FlooringOrders\\Orders_{date.ToString("MMddyyyy")}.txt";
            List<Order> OrderList = new List<Order>();

            
            if (File.Exists(path))
            {
                string[] rows = File.ReadAllLines(path);

                for (int i = 1; i < rows.Length; i++)
                {
                    string[] columns = rows[i].Split(',');

                    Order newOrder = new Order();
                    newOrder.OrderNumber = int.Parse(columns[0]);
                    newOrder.CustomerName = columns[1];
                    newOrder.State = columns[2];
                    newOrder.TaxRate = decimal.Parse(columns[3]);
                    newOrder.ProductType = columns[4];
                    newOrder.Area = decimal.Parse(columns[5]);
                    newOrder.CostPerSquareFoot = decimal.Parse(columns[6]);
                    newOrder.LaborCostPerSquareFoot = decimal.Parse(columns[7]);
                    newOrder.MaterialCost = decimal.Parse(columns[8]);
                    newOrder.LaborCost = decimal.Parse(columns[9]);
                    newOrder.Tax = decimal.Parse(columns[10]);
                    newOrder.Total = decimal.Parse(columns[11]);

                    OrderList.Add(newOrder);
                }
            }
            _OrderList =  OrderList;
            return OrderList;
        }

        public Response LoadOrder(string OrderDate, int OrderNumber)
        {
            Response response = new Response();
            response.Order = new Order();

            LoadList(OrderDate);
            foreach (var x in _OrderList)
            {
                if (x.OrderNumber == OrderNumber)
                {
                    response.Success = true;
                    response.Order = x;
                    return response;
                    
                }

            }
            response.Success = false;
            response.Message = "That order could not be found. Please verify correct order date and order number.";
            return response;
        }


    }
}

