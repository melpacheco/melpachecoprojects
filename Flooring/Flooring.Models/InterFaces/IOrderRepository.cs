using Flooring.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Models.InterFaces
{
  public interface IOrderRepository
    {
       List<Order> LoadList(string OrderDate);
       void SaveOrder(Order order);
        Response LoadOrder(string OrderDate, int ordernumber);
       Response RemoveOrder(Order order);
    }
}
