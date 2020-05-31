using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PagedList;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hourse.ViewModel
{
    public class OrderViewModel
    {
        public IPagedList<OrderInfoList> OrderInfoList { get; set; }
        public List<SelectListItem> MemberList { get; set; }
        public string MemberId { get; set; }
        public List<SelectListItem> ProductList { get; set; }
        public string ProductName { get; set; }
        public string SearchString { get; set; }
    }
    public class OrderInfoList
    {
        [Display(Name = "訂單編號")]
        public int OrdersId { get; set; }
        [Display(Name = "員工編號")]
        public int Id { get; set; }
        [Display(Name = "員工姓名")]
        public string MemberName { get; set; }
        [Display(Name = "客戶姓名")]
        public string CustomerName { get; set; }
        [Display(Name = "價格")]
        public int Price { get; set; }
        [Display(Name = "產品名稱")]
        public string ProductName { get; set; }
        [Display(Name = "建立時間")]
        public string CreateDateStr { get; set; }
        [Display(Name = "備註")]
        public string Remark { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}