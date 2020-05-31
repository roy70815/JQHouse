using Hourse.Services;
using Hourse.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
namespace Hourse.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _HomeService;
        public HomeController(IHomeService homeService)
        {
            _HomeService = homeService;
        }
        public ActionResult CustomerList()
        {
            return View(); 
        }
        #region 訂單管理CRUD
        [HttpGet]
        public ActionResult OrderList(int page = 1,string SearchString="")
        {
            return View(_HomeService.GetOrderList(page ,SearchString));
        }
        [HttpGet]
        public ActionResult OrderDetail(int OrderId=1)
        {
            return Json(_HomeService.GetOrderDetail(OrderId), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult CreateOrder(string Customer_Name,int Customer_Price,string MemberId , string ProductName,string Remark)
        {
            try
            {
                _HomeService.CreateOrder(Customer_Name, Customer_Price, MemberId, ProductName, Remark);
                return RedirectToAction("OrderList");
            }
            catch
            {
                return View();
            }
        }
        [HttpPut]
        public ActionResult UpdateOrder(OrderInfoList Order)
        {
            _HomeService.UpdateOrder(Order);
            return  new HttpStatusCodeResult(HttpStatusCode.NoContent);
        }
        [HttpPost]
        public ActionResult DeleteOrder(int id)
        {
            try
            {
                _HomeService.DeleteOrder(id);
                return RedirectToAction("OrderList");
            }
            catch
            {
                return View();
            }
        }
        #endregion
        public ActionResult ProductList()
        {
            return View();
        }
    }
}