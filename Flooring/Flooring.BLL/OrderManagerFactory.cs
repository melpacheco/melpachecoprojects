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
                    return new OrderManager(new TestOrderRepository(), new TestTaxRepository(), new TestProductRepository());
                case "Live":
                    return new OrderManager(new ProdOrderRepository(), new ProdTaxRepository(), new ProdProductRepository());
                default:
                    throw new Exception("Mode does not exist.");
            }
        }
    }
}
