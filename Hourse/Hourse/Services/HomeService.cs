using Hourse.Models.UnitOfWorks;
using Hourse.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hourse.Services
{
    public class HomeService : IHomeService
    {
        private readonly IHomeUnitOfWork _HomeUnitOfWork;
        public HomeService(IHomeUnitOfWork homeUnitOfWork)
        {
            _HomeUnitOfWork = homeUnitOfWork;
        }
        public OrderViewModel GetOrderList(string SearchString)
        {
            return _HomeUnitOfWork.GetOrderList(SearchString);
        }
    }
}