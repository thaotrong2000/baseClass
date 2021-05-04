using MISA.Core.Entities;
using System.Collections;
using System.Collections.Generic;

namespace MISA.Core.Interfaces.Services
{
    /// <summary>
    /// Service phục vụ cho đối tượng khách hàng
    /// </summary>
    /// CreatedBy: NTThao(21/04/2021)
    public interface ICustomerService : IBaseService<Customer>
    {
        public IEnumerable<Customer> FilterCustomer(int pageIndex, int pageSize, string fullName, string phoneNumber);
    }
}