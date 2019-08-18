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
        public static OrderManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "Test":
                    return new OrderManager(new TestOrderRepository(), new TestProductRepository(), new TestTaxRepository());
                case "Live":
                    return new OrderManager(new ProdOrderRepository(), new ProdProductRepository(), new ProdTaxRepository());
                default:
                    throw new Exception("Mode does not exist.");
            }
        }
    }
}
