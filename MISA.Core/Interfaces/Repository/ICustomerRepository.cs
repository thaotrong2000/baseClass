using MISA.Core.Entities;

namespace MISA.Core.Interfaces.Repository
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        public bool CheckCustomerCodeExist(string customerCode);

        public bool CheckPhoneNumberExist(string phoneNumber);
    }
}