using EasyCashIdentityProject.BusinessLayer.Abstract;
using EasyCashIdentityProject.DataAccessLayer.Abstract;
using EasyCashIdentityProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.BusinessLayer.Concrete
{
    public class CustomerAccountManager : ICustomerAccountService
    {
        private readonly ICustomerAccountDal _customerAccountDal;

        public CustomerAccountManager(ICustomerAccountDal customerAccountDal)
        {
            _customerAccountDal = customerAccountDal;
        }

        public void TDelete(CustomerAccont t)
        {
           _customerAccountDal.Delete(t);
        }

        public CustomerAccont TGetByID(int id)
        {
            return _customerAccountDal.GetByID(id);
        }

        public List<CustomerAccont> TGetList()
        {
           return _customerAccountDal.GetList();
        }

        public void TInsert(CustomerAccont t)
        {
            _customerAccountDal.Insert(t);
        }

        public void TUpdate(CustomerAccont t)
        {
           _customerAccountDal.Update(t);
        }
    }
}
