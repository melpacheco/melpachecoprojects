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
    public class OrderManager

    {
        private IOrderRepository _orderRepository;
        private ITaxRepository _taxRepository;
        private IProductRepository _productRepository;


        public OrderManager(IOrderRepository orderRepository, ITaxRepository taxRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _taxRepository = taxRepository;
            _productRepository = productRepository;

        }

        public Response LoadOrder(string orderDate, int OrderNumber)
        {
            Response response = new Response();
            Order order = new Order();
            response = _orderRepository.LoadOrder(orderDate, OrderNumber);
            return response;
        }

        public List<Product> ProductAvailability()
        {
            List<Product> ProductList = new List<Product>();
            ProductList = _productRepository.ProductList();
            return ProductList;
        }

        public Response DisplayOrder(string OrderDate, int orderNumber) //this works!!!
                                                                           // I AM A FUCKING GENIUS
        {
            Response response = new Response();


            response = _orderRepository.LoadOrder(OrderDate, orderNumber);

            if (response.Order.OrderNumber != orderNumber)
            {
                response.Success = false;
                response.Message = "This orderNumber does not exist.";
                return response;
            }

            response.Success = true;
            return response;
        }
        public Response AddOrder(Order order)
        {
            AddOrderRules addOrderRules = new AddOrderRules();
            Response response = new Response();
            Tax taxObject = new Tax();
            Product productObject = new Product();


            taxObject = _taxRepository.LoadTaxObject(order.State);
            productObject = _productRepository.LoadProduct(order.ProductType);

            response = addOrderRules.AddOrder(order, productObject, taxObject);
            response.Order.OrderNumber = GetOrderNumber(order.OrderDate);

            return response;


        }

        public Response CheckStateTax(string state, List<Tax> TaxList)
        {
            Response response = new Response();
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



        public void SaveOrder(Order order)
        {
            _orderRepository.SaveOrder(order);
        }

        public Response Edit(Order newOrderInfo, Order OldOrderInfo)
        {
            Response response = new Response();
            AddOrderRules addOrder = new AddOrderRules();
            Tax TaxObject = new Tax();
            Product ProductObject = new Product();


            TaxObject = _taxRepository.LoadTaxObject(newOrderInfo.State);
            ProductObject = _productRepository.LoadProduct(newOrderInfo.ProductType);

            response = addOrder.AddOrder(newOrderInfo, ProductObject, TaxObject);
            if (response.Success == true)
            {
                response.Order.OrderDate = OldOrderInfo.OrderDate;
                response.Order.OrderNumber = OldOrderInfo.OrderNumber;
                return response;
            }

            return response;
        }


        public Response RemoveOrder(string OrderDate, int OrderNumber)
        {
            Response response = new Response();
            response.Order = new Order();

            response = _orderRepository.LoadOrder(OrderDate, OrderNumber);

            if (response.Order.OrderNumber != OrderNumber)
            {
                response.Success = false;
                response.Message = "This orderNumber does not exist.";
                return response;
            }
            response.Success = true;
            return response;


        }

        public Response OkayedToRemove(Order order)
        {
            Response response = new Response();

            response = _orderRepository.RemoveOrder(order);

            return response;
        }

        public Response CheckStateTax(string state)
        {
            Response response = new Response();
            foreach (var x in _taxRepository.TaxList())
            {
                if (x.StateName == state)
                {
                    response.Success = true;
                    return response;
                }
            }

            response.Success = false;
            return response;
        }

        public int GetOrderNumber(string OrderDate)
        {
            List<Order> NumberList = new List<Order>();
            List<int> List = new List<int>();
            NumberList = _orderRepository.LoadList(OrderDate);
            int Number;
            if (NumberList.Count == 0)
            {
                return Number = 1;
            }

            else
            {
                foreach (var x in NumberList)
                {
                    List.Add(x.OrderNumber);
                }
                int number = List.Max();
              
                return ++number;
            }
        }

        public Response IsInFutureDate(string orderDate)
        {
            Response response = new Response();
            DateTime dateTime = DateTime.Parse(orderDate);

            while (dateTime < DateTime.Today)
            {
                response.Success = false;
                Console.WriteLine("Order Date must be in the future");             
                return response;
            }

            response.Success = true;
            return response;
        }

        public Response IsValidProduct(string ProductType)
        {
            Response response = new Response();

            foreach (var x in ProductAvailability())
            {
                if (x.ProductType == "ProductType")
                {
                    response.Success = true;
                    return response;
                }

                response.Success = false;
               
            }
            Console.WriteLine("You must choose from the products listed.");
            return response;
        }

      //public Response IsValidOrderDate(string orderDate, int ordernumber)
      //  {
      //      Response response = new Response();

      //      response = _orderRepository.LoadOrder(orderDate, ordernumber);

      //      return response;
      //  }
    }
}






    

