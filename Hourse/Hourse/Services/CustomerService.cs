using Hourse.Models.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hourse.ViewModel;
using Hourse.Models;
namespace Hourse.Services
{
    public partial class CustomerService
    {
        private readonly CustomerUnitOfWork _CustomerUnitOfWork;
        public CustomerService()
        {
            _CustomerUnitOfWork = new CustomerUnitOfWork();
        }
        public List<CustomerViewModel> GetCustomerList()
        {
            return _CustomerUnitOfWork.GetCustomerList();
        }
        public CustomerViewModel GetCustomerDetail(int Id)
        {
            return _CustomerUnitOfWork.GetCustomerDetail(Id);
        }
        public void CreateCustomer(Customer customer)
        {
            _CustomerUnitOfWork.CreateCustomer(customer);
        }
        public void UpdateCustomer(Customer customer)
        {
            _CustomerUnitOfWork.UpdateCustomer(customer);
        }
        public void DeleteCustomer(int id)
        {
            _CustomerUnitOfWork.DeleteCustomer(id);
        }
    }
}