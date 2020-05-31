using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hourse.ViewModel;
using Hourse.Models;
using System.Web.Mvc;
using PagedList;
namespace Hourse.Models.UnitOfWorks
{
    public class HomeUnitOfWork : IHomeUnitOfWork
    {
        JQHomeEntities db = new JQHomeEntities();
        #region 訂單管理CRUD
        public OrderViewModel GetOrderList(int page = 1 ,string SearchString="")
        {
            int PageSize = 5;
            var MemberDic = db.Members.ToList().ToDictionary(x => x.MemberId, x => x.MemberName);
            OrderViewModel result = new OrderViewModel();
            var OrderInfoList = db.Orders
                .Select(y=> new OrderInfoList
                {
                    OrdersId = y.OrdersId,
                    Id =y.Id,
                    CustomerName = y.CustomerName,
                    Price =y.Price,
                    ProductName=y.ProductName,
                    CreateDate=y.CreateDate
                }).ToList();
            
            foreach (var Order in OrderInfoList)
            {
                Order.CreateDateStr = Order.CreateDate != null ? Order.CreateDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "";
                Order.MemberName = MemberDic[Order.Id];
            }
            if (SearchString != "")
            {
                result.OrderInfoList = OrderInfoList
                    .Where(x => x.CustomerName.Contains(SearchString)|| x.ProductName.Contains(SearchString)).ToPagedList(page, PageSize);
            }
            else
            {
                result.OrderInfoList = OrderInfoList.ToPagedList(page, PageSize);
            }
            List<SelectListItem> MemberList = new List<SelectListItem>();
            MemberList.Add(new SelectListItem
            {
                Value = "-1",
                Text = "請選擇員工",
                Selected = true,
                Disabled = true
            });
            MemberList.AddRange(db.Members.Select(x => new SelectListItem
            {
                Text = x.MemberName,
                Value = x.MemberId.ToString()
            }));
            List<SelectListItem> ProductList = new List<SelectListItem>();
            ProductList.Add(new SelectListItem
            {
                Value = "-1",
                Text = "請選擇產品",
                Selected = true,
                Disabled = true
            });
            ProductList.AddRange(db.Product.Select(x => new SelectListItem
            {
                Text = x.ProductName,
                Value = x.ProductName
            }));
            result.MemberList = MemberList;
            result.ProductList = ProductList;
            result.ProductName = "-1";
            result.MemberId = "-1";
            result.SearchString = SearchString;
            return result;
        }
        public OrderInfoList GetOrderDetail(int OrderId)
        {
            var MemberDic = db.Members.ToList().ToDictionary(x => x.MemberId, x => x.MemberName);
            var Order = db.Orders.Find(OrderId);
            OrderInfoList result = new OrderInfoList();
            result.OrdersId = Order.OrdersId;
            result.Id = Order.Id;
            result.CustomerName = Order.CustomerName;
            result.Price = Order.Price;
            result.ProductName = Order.ProductName;
            result.CreateDate = Order.CreateDate;
            result.CreateDateStr = Order.CreateDate != null ? Order.CreateDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "";
            result.MemberName = MemberDic[Order.Id];
            result.Remark = Order.Remark;
            return result;
        }
        public void CreateOrder(string Customer_Name, int Customer_Price, string MemberId, string ProductName , string Remark)
        {
            Orders Order = new Orders();
            Order.CustomerName = Customer_Name;
            Order.Price = Customer_Price;
            Order.Id = int.Parse(MemberId);
            Order.ProductName = ProductName;
            Order.Remark = "";
            Order.CreateDate = DateTime.Now;
            Order.ModifyDate = DateTime.Now;
            db.Orders.Add(Order);
            db.SaveChanges();
        }
        public void UpdateOrder(OrderInfoList Order)
        {
            Orders OrderEntity = db.Orders.Find(Order.OrdersId);
            OrderEntity.Id = Order.Id;
            OrderEntity.Price = Order.Price;
            OrderEntity.ProductName = Order.ProductName;
            OrderEntity.Remark = Order.Remark;
            OrderEntity.ModifyDate = DateTime.Now;
            db.SaveChanges();
        }
        public void DeleteOrder(int id)
        {
            Orders Order = db.Orders.Find(id);
            db.Orders.Remove(Order);
            db.SaveChanges();
        }
        #endregion
    }
}