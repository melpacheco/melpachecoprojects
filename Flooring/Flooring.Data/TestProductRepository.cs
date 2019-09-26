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
        private string _path;

        public TestProductRepository(string path)
        {
            _path = path;
        }

        Product product = new Product();
        public List<Product> ProductList()
        { List<Product> ProductList = new List<Product>();

            ProductList.Add(new Product { ProductType = "Tile", CostPerSquareFoot = 3.50M, LaborCostPerSquareFoot = 4.15M });

            return ProductList;
        }

        public Product LoadProduct(string ProductType)
        {
            var ProductObject = ProductList().Where(p => p.ProductType.ToLower() == ProductType.ToLower());

            return ProductObject.FirstOrDefault();
        }

        public void SaveNewProduct(Product product)
        {
            ProductList().Add(product);
        }

    }
}
