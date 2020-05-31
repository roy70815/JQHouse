using Hourse.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hourse.Services
{
    public interface IHomeService
    {
        OrderViewModel GetOrderList(string SearchString);
    }
}