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
   public class OrderManager : IOrderRepository

    {
        private IOrderRepository _orderRepository;
        private ITaxRepository _taxRepository;
        private IProductRepository _productRepository;

        public OrderManager (IOrderRepository orderRepository, ITaxRepository taxRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _taxRepository = taxRepository;
            _productRepository = productRepository;
        }

       

        public List<Tax> GetTaxList()
        {
            List<Tax> TaxList = new List<Tax>();
            TaxList = TestTaxRepository.taxList;
            return TaxList;
        }

        public  List<Product> GetProductList()
        {
            List<Product> ProductList = new List<Product>();
            ProductList = TestProductRepository.productList;
            return ProductList;

        }

        

        public OrderManager(IOrderRepository orderRepository, IProductRepository productRepository, ITaxRepository taxRepository)
        {
            _orderRepository = orderRepository;
            _taxRepository = taxRepository;
            _productRepository = productRepository;
        }

        public DisplayOrderResponse DisplayOrder(string orderNumber) //this works!!!
            // I AM A FUCKING GENIUS
        {
            DisplayOrderResponse response = new DisplayOrderResponse();

            response.OrderDate = _orderRepository.LoadOrder(orderNumber);

            if (response.OrderDate.OrderNumber != orderNumber)
            {
                response.Success = false;
                response.Message = "This orderNumber does not exist.";
                return response;
            }

            response.Success = true;
            return response;
        }
        public AddOrderResponse AddOrder(Order order) 
        {
            AddOrderRules addOrderRules = new AddOrderRules();
            AddOrderResponse addOrderResponse = new AddOrderResponse();
            Tax taxObject = new Tax();
            Product productObject = new Product();
            addOrderResponse = CheckStateTax(order.State, GetTaxList());
            if (addOrderResponse.Success == false)
            {
                addOrderResponse.Message = $"We cannot sell in {order.State} at this time. ";
                return addOrderResponse;
            }
            



            taxObject = _taxRepository.LoadTaxObject(order.State);
            productObject = _productRepository.LoadProduct(order.ProductType);

            addOrderResponse = addOrderRules.AddOrder(order, productObject, taxObject);


            List<Order> OrderList = _orderRepository.LoadList();
            int ordercount = OrderList.Count();
            addOrderResponse.OrderNumber = ordercount++.ToString();
            return addOrderResponse;

        }

        public AddOrderResponse CheckStateTax(string state, List<Tax> TaxList)
        {
            AddOrderResponse response = new AddOrderResponse();
            foreach (var p in TaxList)
            {
                if (p.StateName == state)
                {
                    response.Success = true;
                    return response;
                }

            }
            response.Success = false;
            return response;
        }

        public Order LoadOrder(string OrderNumber)
        {
            var order = _orderRepository.LoadList().Where(p => p.OrderNumber == OrderNumber);

            return order.First();
        }

        public void SaveOrder(Order order)
        {
            _orderRepository.SaveOrder(order);
        }

        public List<Order> LoadList()
        {
            throw new NotImplementedException();
        }
        public EditOrderResponse Edit(DateTime orderDate, string OrderNumber)
        {
            EditOrderResponse response = new EditOrderResponse();
            Order OldOrder = new Order();

            OldOrder = LoadOrder(OrderNumber);

            response.
            
            

        }
        //public RemoveOrderResponse RemoveOrder (DateTime orderDate, int OrderNumber)


        //{

        //}


    }
}
