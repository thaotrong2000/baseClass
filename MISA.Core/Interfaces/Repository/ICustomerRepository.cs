using MISA.Core.Entities;
using System.Collections.Generic;

namespace MISA.Core.Interfaces.Repository
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        public bool CheckCustomerCodeExist(string customerCode);

        public bool CheckPhoneNumberExist(string phoneNumber);

        public IEnumerable<Customer> CustomerFilter(int pageIndex, int pageSize, string fullName, string phoneNumber);
    }
}