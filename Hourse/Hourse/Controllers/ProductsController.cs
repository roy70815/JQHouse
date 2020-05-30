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
        [Route("api/Products/GetProduct")]
        public HttpResponseMessage GetProduct()
        {
            return Request.CreateResponse<List<Product>>(HttpStatusCode.Created, _ProductService.GetProduct(), GlobalConfiguration.Configuration.Formatters.JsonFormatter);
        }
    }
}
