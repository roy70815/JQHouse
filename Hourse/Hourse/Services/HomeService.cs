using Hourse.Models;
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
        #region 訂單管理CRUD
        public OrderViewModel GetOrderList(int page = 1 ,string SearchString="")
        {
            return _HomeUnitOfWork.GetOrderList(page , SearchString);
        }
        public OrderInfoList GetOrderDetail(int OrderId)
        {
            return _HomeUnitOfWork.GetOrderDetail(OrderId);
        }
        public void CreateOrder(string Customer_Name, int Customer_Price, string MemberId, string ProductName, string Remark)
        {
            _HomeUnitOfWork.CreateOrder(Customer_Name, Customer_Price, MemberId, ProductName, Remark);
        }
        public void UpdateOrder(OrderInfoList Order)
        {
            _HomeUnitOfWork.UpdateOrder(Order);
        }
        public void DeleteOrder(int id)
        {
            _HomeUnitOfWork.DeleteOrder(id);
        }
        #endregion
    }
}