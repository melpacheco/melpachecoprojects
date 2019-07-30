using Flooring.Models;
using Flooring.Models.InterFaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Data
{
   public class TestProductRepository : IProductRepository
    {

        Product product = new Product();
        public static List<Product> productList = new List<Product>()
        {
          new Product{ ProductType = "Tile", CostPerSquareFoot = 3.50M, LaborCostPerSquareFoot = 4.15M}
      

        };

        public Product LoadProduct(string ProductType)
        {
            var ProductObject = productList.Where(p => p.ProductType == ProductType);

            return ProductObject.FirstOrDefault();
        }

        public void SaveList(Product product)
        {
            productList.Add(product);
        }

    

        // should inherit from product or IProduct? What should be in IProduct??? Same with tax?
    }
}
