using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Models.Responses
{
   public class  Response 
    {
        //public Response()
        //{
        //    Order = new Order();
        //}
        public bool Success { get; set; }
        public string Message { get; set; }
        public Order Order { get; set; }
    }
}
