using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Services
{
    public interface ICustomerGroupService
    {
        public IEnumerable<CustomerGroup> GetAll();
        public CustomerGroup GetById(Guid customerId);
        public int Insert(CustomerGroup customer);
        public int Update(CustomerGroup customer);
        public int Delete(Guid customerId);
    }
}
