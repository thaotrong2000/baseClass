using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Services;
using System;

namespace MISA.Core.Service
{
    public class CustomerGroupService : BaseService<CustomerGroup>, ICustomerGroupService
    {
        private ICustomerGroupRepository _customerGroupRepository;

        public CustomerGroupService(ICustomerGroupRepository customerGroupRepository) : base(customerGroupRepository)
        {
            _customerGroupRepository = customerGroupRepository;
        }

        protected override void CustomValidate(CustomerGroup entity)
        {
            //throw new Exception("Nguyen Trong Thao");
            if (string.IsNullOrEmpty(entity.CustomerGroupName))
            {
                throw new Exception("Bạn không được để trống CustomerGroupName");
            }
        }
    }
}