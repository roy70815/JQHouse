using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Hourse.ViewModel
{
    public class OrderViewModel
    {
        public List<OrderInfoList> OrderInfoList { get; set; }
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
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}