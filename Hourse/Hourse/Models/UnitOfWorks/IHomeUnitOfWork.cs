using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hourse.Models;
using Hourse.ViewModel;
namespace Hourse.Models.UnitOfWorks
{
    public interface IHomeUnitOfWork
    {
        OrderViewModel GetOrderList(string SearchString);
    }
}