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
        public List<Product> GetProduct()
        {
            var result = db.Product.ToList();
            return result;
        }
    }
}