using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Hourse.Models;
namespace Hourse.Models.UnitOfWorks
{
    public partial class ProductUnitOfWork
    {
        JQHomeEntities db = new JQHomeEntities();
        public List<Product> GetProductList()
        {
            var result = db.Product.ToList();
            return result;
        }
        public Product GetProductDetail(int Id)
        {
            return db.Product.Find(Id);
        }
        public void CreateProduct(string ProductName)
        {
            Product Product = new Product { ProductName = ProductName };
            db.Product.Add(Product);
            db.SaveChanges();
        }
        public void UpdateProduct(Product product)
        {
            Product Product = db.Product.Find(product.ProductId);
            Product.ProductName = product.ProductName;
            db.SaveChanges();
        }
        public void DeleteProduct(int id)
        {
            Product product = db.Product.Find(id);
            db.Product.Remove(product);
            db.SaveChanges();
        }
    }
}