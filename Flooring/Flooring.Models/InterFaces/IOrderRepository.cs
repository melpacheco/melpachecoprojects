using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Models.InterFaces
{
  public interface IOrderRepository
    {
       List< Order> LoadList();
        void SaveOrder(Order order);
        Order LoadOrder(string ordernumber);
    }
}
