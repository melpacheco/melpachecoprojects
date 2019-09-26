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
    public class ProdProductRepository : IProductRepository
    {
        private string _path;
      
        public ProdProductRepository(string path)
        {
            _path = path;
        }

        public  List<Product> ProductList()
        {
            string path = @"C:\Users\MelPacheco\Documents\SoftWareGuildAssignments\melissa-pacheco-individual-work\online-net-melpacheco\Flooring\FlooringOrders\Products.txt";
            List<Product> ProductList = new List<Product>();
          

            if (File.Exists(path))
            {
                string[] rows = File.ReadAllLines(path);

                for (int i = 1; i < rows.Length; i++)
                {
                    Product product = new Product();
                    string[] columns = rows[i].Split(',');
                    product.ProductType = columns[0];
                    product.CostPerSquareFoot = decimal.Parse(columns[1]);
                    product.LaborCostPerSquareFoot = decimal.Parse(columns[2]);

                    ProductList.Add(product);
                }

                return ProductList;
            }

            else
            {
                return null;
            }
        }

        public Product LoadProduct(string ProductType)
        {
            var Product = ProductList().Where(p => p.ProductType.ToLower() == ProductType.ToLower());

            return Product.FirstOrDefault();
        }

        public void SaveNewProduct(Product product)
        {
            ProductList().Add(product);
        }

   
    }
}
