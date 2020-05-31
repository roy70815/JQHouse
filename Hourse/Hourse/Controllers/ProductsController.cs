using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Hourse.Models;
using Hourse.Service;
namespace Hourse.Controllers
{
    public partial class ProductsController : ApiController
    {
        private readonly ProductService _ProductService;
        public ProductsController()
        {
            _ProductService = new ProductService();
        }

        [HttpGet]
        [Route("api/Products/GetProductList")]
        public HttpResponseMessage GetProduct()
        {
            return Request.CreateResponse<List<Product>>(HttpStatusCode.Created, _ProductService.GetProductList(), GlobalConfiguration.Configuration.Formatters.JsonFormatter);
        }
        [HttpGet]
        [Route("api/Products/GetCustomerDetail")]
        public HttpResponseMessage GetCustomerDetail(int Id)
        {
            try
            {
                return Request.CreateResponse<Product>(HttpStatusCode.Created, _ProductService.GetProductDetail(Id), GlobalConfiguration.Configuration.Formatters.JsonFormatter);
            }
            catch (Exception e)
            {
                return Request.CreateResponse<Exception>(HttpStatusCode.Created, e, GlobalConfiguration.Configuration.Formatters.JsonFormatter);
            }
        }
        [HttpPost]
        [Route("api/Products/CreateCustomer")]
        public HttpResponseMessage CreateCustomer(string ProductName)
        {
            try
            {
                _ProductService.CreateProduct(ProductName);
                return Request.CreateResponse<List<Product>>(HttpStatusCode.Created, _ProductService.GetProductList(), GlobalConfiguration.Configuration.Formatters.JsonFormatter);
            }
            catch (Exception e)
            {
                return Request.CreateResponse<Exception>(HttpStatusCode.Created, e, GlobalConfiguration.Configuration.Formatters.JsonFormatter);
            }
        }
        [HttpPut]
        [Route("api/Products/UpdateCustomer")]
        public HttpResponseMessage UpdateCustomer(Product product)
        {
            try
            {
                _ProductService.UpdateProduct(product);
                return Request.CreateResponse<List<Product>>(HttpStatusCode.Created, _ProductService.GetProductList(), GlobalConfiguration.Configuration.Formatters.JsonFormatter);
            }
            catch (Exception e)
            {
                return Request.CreateResponse<Exception>(HttpStatusCode.Created, e, GlobalConfiguration.Configuration.Formatters.JsonFormatter);
            }
        }
        [HttpDelete]
        [Route("api/Products/DeleteCustomer/{Id}")]
        public HttpResponseMessage DeleteProduct(int Id)
        {
            try
            {
                _ProductService.DeleteProduct(Id);
                return Request.CreateResponse<List<Product>>(HttpStatusCode.Created, _ProductService.GetProductList(), GlobalConfiguration.Configuration.Formatters.JsonFormatter);
            }
            catch (Exception e)
            {
                return Request.CreateResponse<Exception>(HttpStatusCode.Created, e, GlobalConfiguration.Configuration.Formatters.JsonFormatter);
            }
        }
    }
}
