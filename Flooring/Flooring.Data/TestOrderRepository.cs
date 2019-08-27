using Flooring.Models;
using Flooring.Models.InterFaces;
using Flooring.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Data
{
    public class TestOrderRepository : IOrderRepository
    {
        private static string _path;

        public TestOrderRepository(string path)
        {
            _path = path;
        }
        private static List<Order> _Order = new List<Order>()
        {
            new Order {OrderNumber = 1, CustomerName = "Wise", State = "Ohio",
            TaxRate = 6.25M, ProductType = "Wood", Area = 100.0M, CostPerSquareFoot = 5.14M,
            LaborCostPerSquareFoot = 4.75M, MaterialCost = 515.00M, LaborCost = 475.00M,
            Tax = 61.88M, Total = 1051.88M, OrderDate = "06/13/2013"}

        };


        public List<Order> LoadList(string orderDate)
        {
            List<Order> NewList = new List<Order>();

            NewList = _Order;

            return NewList;
        }

        public Response LoadOrder(string orderDate, int ordernumber)
        {
            Response response = new Response();

            var order = _Order.Where(p => p.OrderNumber == ordernumber);
            response.Order = order.First();

            if (response.Order == null)
            {
                response.Success = false;
                response.Message = "That order could not be found. Please verify order date and order number.";
                return response;
            }

            response.Success = true;
            return response;
           
        }

        public void SaveOrder(Order order)
        {
            _Order.Add(order);
        }

        public Response RemoveOrder(Order order)
        {
            Response response = new Response();
            _Order.RemoveAll(p => p.OrderNumber == order.OrderNumber);
            response.Success = true;
            response.Message = "Order has been removed.";
            return response;


        }
    }
}
