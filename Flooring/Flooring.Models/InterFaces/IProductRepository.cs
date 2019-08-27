using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Models.InterFaces
{
    public interface IProductRepository
    {
         Product LoadProduct(string ProductType);
        void SaveNewProduct (Product product);
        List<Product> ProductList();
    }
}
