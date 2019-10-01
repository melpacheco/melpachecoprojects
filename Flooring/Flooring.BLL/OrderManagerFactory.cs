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
        private static string _path = $"C:\\Users\\MelPacheco\\Documents\\SoftWareGuildAssignments\\melissa-pacheco-individual-work\\online-net-melpacheco\\Flooring\\FlooringOrders\\";

        public static OrderManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();
            string FilePath = ConfigurationManager.AppSettings["FilePath"].ToString();

            switch (mode)
            {
                case "Test":
                    return new OrderManager(new TestOrderRepository(FilePath), new TestTaxRepository(FilePath), new TestProductRepository(FilePath));
                case "Live":
                    return new OrderManager(new ProdOrderRepository(FilePath), new ProdTaxRepository(FilePath), new ProdProductRepository(FilePath));
                default:
                    throw new Exception("Mode does not exist.");
            }

            
        }

 
    }
}
