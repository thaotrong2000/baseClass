using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Services;
using System;

namespace MISA.Core.Service
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        private ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository) : base(customerRepository)
        {
            _customerRepository = customerRepository;
        }

        protected override void Validate(Customer entity)
        {
            // Kiểm tra dữ liệu trống
            var customer = entity as Customer;
            if (string.IsNullOrEmpty(customer.CustomerCode))
            {
                throw new Exception("Bạn không được để trống mã khách hàng, hãy nhập nó");
            }

            // Kiểm tra dữ liệu đã tồn tại hay chưa?
            if (entity is Customer)
            {
                // Validate dữ liệu
                // CustomerExeption.CheckCustomerCodeEmpty(customer.CustomerCode)

                // Check trùng mã
                var isExist = _customerRepository.CheckCustomerCodeExist(customer.CustomerCode);
                if (isExist == true)
                {
                    throw new Exception("Mã khách hàng đã tồn tại trên hệ thống!.");
                }
            }
        }
    }
}