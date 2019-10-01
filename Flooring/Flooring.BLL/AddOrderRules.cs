using Flooring.Data;
using Flooring.Models;
using Flooring.Models.InterFaces;
using Flooring.Models.Responses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.BLL
{
    public class AddOrderRules
    {
        public Response AddOrder(Order order, Product product, Tax tax)
        {
            Response response = new Response();
            response.Order = new Order();
           
            

            if (order.Area < 0)
            {
                response.Success = false;
                response.Message = "Area must be greater than 0";
                return response;
            }

            if (order.Area < 100)
            {
                response.Success = false;
                response.Message = "Area must be at least 100 square feet";
                return response;
            }

            response.Success = true;

            response.Order.OrderDate = order.OrderDate;
            response.Order.CustomerName = order.CustomerName;
            response.Order.ProductType = order.ProductType;
            response.Order.State = order.State;
            response.Order.TaxRate = tax.TaxRate;
            response.Order.Area = order.Area;
            response.Order.CostPerSquareFoot = product.CostPerSquareFoot;
            response.Order.LaborCostPerSquareFoot = product.LaborCostPerSquareFoot;
            response.Order.MaterialCost = order.Area * product.CostPerSquareFoot;
            response.Order.LaborCost = order.Area * product.LaborCostPerSquareFoot;
            response.Order.Tax = (response.Order.MaterialCost + response.Order.LaborCost) * (tax.TaxRate / 100);
            response.Order.Total = response.Order.MaterialCost + response.Order.LaborCost + response.Order.Tax;
            return response;

        }



    }
}

