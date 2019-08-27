using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Flooring.Data;

namespace Flooring.BLL
{
    public class OrderManagerFactory
    {
        private static string _path = $"C:\\Users\\MelPacheco\\Documents\\SoftWareGuildAssignments\\melissa-pacheco-individual-work\\online-net-melpacheco\\Flooring\\FlooringOrders\\Orders_";

        public static OrderManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "Test":
                    return new OrderManager(new TestOrderRepository(_path), new TestTaxRepository(), new TestProductRepository());
                case "Live":
                    return new OrderManager(new ProdOrderRepository(_path), new ProdTaxRepository(), new ProdProductRepository());
                default:
                    throw new Exception("Mode does not exist.");
            }

            
        }

 
    }
}
