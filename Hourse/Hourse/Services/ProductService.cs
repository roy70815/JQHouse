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
        public List<Product> GetProductList()
        {
            return _ProductUnitOfWork.GetProductList();
        }
        public Product GetProductDetail(int Id)
        {
            return _ProductUnitOfWork.GetProductDetail(Id);
        }
        public void CreateProduct(string ProductName)
        {
            _ProductUnitOfWork.CreateProduct(ProductName);
        }
        public void UpdateProduct(Product product)
        {
            _ProductUnitOfWork.UpdateProduct(product);
        }
        public void DeleteProduct(int id)
        {
            _ProductUnitOfWork.DeleteProduct(id);
        }
    }
}