using Hourse.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Hourse.ViewModel;
using Hourse.Models;
namespace Hourse.Controllers
{
    public class CustomersController : ApiController
    {
        private readonly CustomerService _CustomerService;
        public CustomersController()
        {
            _CustomerService = new CustomerService();
        }

        [HttpGet]
        [Route("api/Customers/GetCustomerList")]
        public HttpResponseMessage GetCustomerList()
        {
            try
            {
                 return Request.CreateResponse<List<CustomerViewModel>>(HttpStatusCode.Created, _CustomerService.GetCustomerList(), GlobalConfiguration.Configuration.Formatters.JsonFormatter);
            }
            catch(Exception e)
            {
                return Request.CreateResponse<Exception>(HttpStatusCode.Created, e, GlobalConfiguration.Configuration.Formatters.JsonFormatter);
            }
        }
        [HttpGet]
        [Route("api/Customers/GetCustomerDetail")]
        public HttpResponseMessage GetCustomerDetail(int Id)
        {
            try
            {
                return Request.CreateResponse<Customer>(HttpStatusCode.Created, _CustomerService.GetCustomerDetail(Id), GlobalConfiguration.Configuration.Formatters.JsonFormatter);
            }
            catch (Exception e)
            {
                return Request.CreateResponse<Exception>(HttpStatusCode.Created, e, GlobalConfiguration.Configuration.Formatters.JsonFormatter);
            }
        }
        [HttpPost]
        [Route("api/Customers/CreateCustomer")]
        public HttpResponseMessage CreateCustomer(Customer customer)
        {
            try
            {
                _CustomerService.CreateCustomer(customer);
                return Request.CreateResponse<List<CustomerViewModel>>(HttpStatusCode.Created, _CustomerService.GetCustomerList(), GlobalConfiguration.Configuration.Formatters.JsonFormatter);
            }
            catch (Exception e)
            {
                return Request.CreateResponse<Exception>(HttpStatusCode.Created, e, GlobalConfiguration.Configuration.Formatters.JsonFormatter);
            }
        }
        [HttpPut]
        [Route("api/Customers/UpdateCustomer")]
        public HttpResponseMessage UpdateCustomer(Customer customer)
        {
            try
            {
                _CustomerService.UpdateCustomer(customer);
                return Request.CreateResponse<List<CustomerViewModel>>(HttpStatusCode.Created, _CustomerService.GetCustomerList(), GlobalConfiguration.Configuration.Formatters.JsonFormatter);
            }
            catch (Exception e)
            {
                return Request.CreateResponse<Exception>(HttpStatusCode.Created, e, GlobalConfiguration.Configuration.Formatters.JsonFormatter);
            }
        }
        [HttpDelete]
        [Route("api/Customers/DeleteCustomer/{Id}")]
        public HttpResponseMessage DeleteCustomer(int Id)
        {
            try
            {
                _CustomerService.DeleteCustomer(Id);
                return Request.CreateResponse<List<CustomerViewModel>>(HttpStatusCode.Created, _CustomerService.GetCustomerList(), GlobalConfiguration.Configuration.Formatters.JsonFormatter);
            }
            catch (Exception e)
            {
                return Request.CreateResponse<Exception>(HttpStatusCode.Created, e, GlobalConfiguration.Configuration.Formatters.JsonFormatter);
            }
        }
    }
}
