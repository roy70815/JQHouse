using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hourse.Models;
using Hourse.Models.UnitOfWorks;

namespace Hourse.Service
{
    public partial class ProductService
    {
        private readonly ProductUnitOfWork _ProductUnitOfWork;
        public ProductService()
        {
            _ProductUnitOfWork = new ProductUnitOfWork();
        }
        public List<Product> GetProduct()
        {
            return _ProductUnitOfWork.GetProduct();
        }
    }
}