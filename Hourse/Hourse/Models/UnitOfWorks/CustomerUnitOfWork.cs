using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hourse.Models;
using Hourse.ViewModel;
namespace Hourse.Models.UnitOfWorks
{
    public class CustomerUnitOfWork
    {
        JQHomeEntities db = new JQHomeEntities();
        public List<CustomerViewModel> GetCustomerList()
        {
            return db.Customer.Select(x => new CustomerViewModel { CustomerId = x.Id, CustomerName = x.CustomerName, Phone = x.Phone }).ToList();
        }
        public CustomerViewModel GetCustomerDetail(int Id)
        {
            Customer Customer = db.Customer.Find(Id);
            var result = new CustomerViewModel()
            {
                CustomerId = Customer.Id,
                Address = Customer.Address,
                CustomerName = Customer.CustomerName,
                Phone = Customer.Phone
            };
            return result;
        }
        public void CreateCustomer(Customer customer)
        {
            db.Customer.Add(customer);
            db.SaveChanges();
        }
        public void UpdateCustomer(Customer customer)
        {
            Customer Customer = db.Customer.Find(customer.Id);
            Customer.CustomerName = customer.CustomerName;
            Customer.Address = customer.Address;
            Customer.Phone = customer.Phone;
            db.SaveChanges();
        }
        public void DeleteCustomer(int id)
        {
            //有FK，必須先刪！
            List<Orders> OrderList = new List<Orders>();
            OrderList = db.Orders.Where(x => x.Id == id).ToList();
            foreach(var Order in OrderList)
            {
                db.Orders.Remove(Order);
            }
            db.SaveChanges();
            Customer Customer = db.Customer.Find(id);
            db.Customer.Remove(Customer);
            db.SaveChanges();
        }
    }
}