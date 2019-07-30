using Flooring.Data;
using Flooring.Models;
using Flooring.Models.InterFaces;
using Flooring.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.BLL
{
    public class AddOrderRules 
    {
        public AddOrderResponse AddOrder(Order order, Product product, Tax tax)
        {
           
            AddOrderResponse response = new AddOrderResponse();

           if (order.Area < 0)
            {
                response.Success = false;
                response.Message = "Area must be greater than 0";
                return response;
            }

            if (order.Area <= 100)
            {
                response.Success = false;
                response.Message = "Area must be at least 100 square feet";
                return response;
            }

            response.Success = true;
            response.OrderDate = order.OrderDate;
            //response.OrderNumber = AssignOrderNumber()
            response.CustomerName = order.CustomerName;
            response.State = tax.StateName;
            response.TaxRate = tax.TaxRate;
            response.ProductType = product.ProductType;
            response.Area = order.Area;
            response.CostPerSquareFoot = product.CostPerSquareFoot;
            response.LaborCostPerSquareFoot = product.LaborCostPerSquareFoot;
            response.MaterialCost = response.Area * response.CostPerSquareFoot;
            response.LaborCost = response.Area * response.LaborCostPerSquareFoot;
            response.Tax = (response.MaterialCost + response.LaborCost) * (response.TaxRate / 100);
            response.Total = response.MaterialCost + response.LaborCost + response.Tax;
            return response;
        }

        public Order LoadOrder(string OrderNumber)
        {
            throw new NotImplementedException();
        }

        public void SaveOrder(Order order)
        {
            throw new NotImplementedException();
        }

     

        public List<Order> LoadList()
        {
            throw new NotImplementedException();
        }
    }
    }

