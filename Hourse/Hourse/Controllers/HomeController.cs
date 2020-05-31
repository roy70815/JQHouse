using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Hourse.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult CustomerList()
        {
            return View(); 
        }
        public ActionResult OrderList()
        {
            return View();
        }
        public ActionResult ProductList()
        {
            return View();
        }
    }
}