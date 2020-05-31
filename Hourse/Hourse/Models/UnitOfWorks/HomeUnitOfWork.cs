using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hourse.ViewModel;
using Hourse.Models;
namespace Hourse.Models.UnitOfWorks
{
    public class HomeUnitOfWork : IHomeUnitOfWork
    {
       JQHomeEntities db = new JQHomeEntities();
        public OrderViewModel GetOrderList(string SearchString)
       {
            var MemberDic = db.Members.ToList().ToDictionary(x => x.MemberId, x => x.MemberName);
            OrderViewModel result = new OrderViewModel();
            result.OrderInfoList = db.Orders.Where(x => x.CustomerName.Contains(SearchString))
                .Select(y=> new OrderInfoList
                {
                   Id =y.Id,
                    CustomerName = y.CustomerName,
                    Price =y.Price,
                    ProductName=y.ProductName,
                    CreateDate=y.CreateDate
                }).ToList();
            foreach(var Order in result.OrderInfoList)
            {
                Order.CreateDateStr = Order.CreateDate != null ? Order.CreateDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "";
                Order.MemberName = MemberDic[Order.Id];
            }
            return result;
       }
    }
}