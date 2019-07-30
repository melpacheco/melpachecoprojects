using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Models.Responses
{
    public class EditOrderResponse : Response
    {
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public string State { get; set; }
        public string ProductType { get; set; }//should this be a "product"
        public decimal Area { get; set; }
        public decimal CostPerSquareFoot { get; set; } //should this and  labor cost be a "product?"
        public decimal TaxRate { get; set; }//should this be a "tax"??
        public decimal LaborCostPerSquareFoot { get; set; }
        public decimal MaterialCost { get; set; }
        public decimal LaborCost { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
    }
}
