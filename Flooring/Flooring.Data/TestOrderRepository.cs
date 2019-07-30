using Flooring.Models;
using Flooring.Models.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Data
{
    public class TestOrderRepository : IOrderRepository
    {
        private static List<Order> _Order = new List<Order>()
        {
            new Order {OrderNumber = "1", CustomerName = "Wise", State = "Ohio",
            TaxRate = 6.25M, ProductType = "Wood", Area = 100.0M, CostPerSquareFoot = 5.14M,
            LaborCostPerSquareFoot = 4.75M, MaterialCost = 515.00M, LaborCost = 475.00M,
            Tax = 61.88M, Total = 1051.88M}

        };


       

        public List<Order> LoadList()
        {
            return _Order;
        }

        public Order LoadOrder(string ordernumber)
        {
            var order = _Order.Where(p => p.OrderNumber == ordernumber);
            return order.First();
        }

        public void SaveOrder(Order order)
        {
            _Order.Add(order);
        }
    }
}
