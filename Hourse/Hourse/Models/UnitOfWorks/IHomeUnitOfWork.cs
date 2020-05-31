﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hourse.Models;
using Hourse.ViewModel;
namespace Hourse.Models.UnitOfWorks
{
    public interface IHomeUnitOfWork
    {
        #region 訂單管理CRUD
        OrderViewModel GetOrderList(int page = 1,string SearchString = "");
        OrderInfoList GetOrderDetail(int OrderId);
        void CreateOrder(string Customer_Name, int Customer_Price, string MemberId, string ProductName, string Remark);
        void UpdateOrder(OrderInfoList Order);
        void DeleteOrder(int id);
        #endregion
    }
}