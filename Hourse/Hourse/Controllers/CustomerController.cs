using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hourse.Controllers
{
    public class CustomerController : Controller
    {
        public ActionResult CustomerList()
        {
            return View(); 
        }
    }
}