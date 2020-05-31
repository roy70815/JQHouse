using Hourse.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult OrderList(int page = 1,string SearchString="")
        {
            return View(_HomeService.GetOrderList(SearchString));
        }
        public ActionResult ProductList()
        {
            return View();
        }
    }
}