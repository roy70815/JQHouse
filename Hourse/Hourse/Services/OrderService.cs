using Hourse.Models.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hourse.Services
{
    public partial class OrderService
    {
        private readonly OrderUnitOfWork _OrderUnitOfWork;
        public OrderService()
        {
            _OrderUnitOfWork = new OrderUnitOfWork();
        }
    }
}