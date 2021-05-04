using MISA.Core.AttributeCustom;
using MISA.Core.Entities;
using MISA.Core.Exceptions;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections;
using System.Collections.Generic;

namespace MISA.Core.Service
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        private ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository) : base(customerRepository)
        {
            _customerRepository = customerRepository;
        }

        /// <summary>
        /// Validate dữ liệu Customer
        /// </summary>
        /// <param name="entity"></param>
        /// CreatedBy: NTTHAO(3/5/2021)
        protected override void CustomValidate(Customer entity)
        {
            //if (string.IsNullOrEmpty(customer.CustomerCode))
            //{
            //    throw new Exception("Bạn không được để trống mã khách hàng, hãy nhập nó");
            //}
            // Kiểm tra dữ liệu trống

            // Kiểm tra dữ liệu đã tồn tại hay chưa?
            if (entity != null)
            {
                //CustomerException.CheckNullCustomerCode(entity.CustomerCode);
                // Validate dữ liệu
                // CustomerExeption.CheckCustomerCodeExist(customer.CustomerCode)

                // Check trùng mã
                var isExist = _customerRepository.CheckCustomerCodeExist(entity.CustomerCode);
                if (isExist == true)
                {
                    throw new Exception("Mã khách hàng đã tồn tại trên hệ thống!.");
                }
            }
        }

        /// <summary>
        /// Lọc dữ liệu theo FullName hoặc theo PhoneNumber
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="fullName"></param>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        /// CreatedBy: NTTHAO(4/5/2021)
        public IEnumerable<Customer> FilterCustomer(int pageIndex, int pageSize, string fullName, string phoneNumber)
        {
            if (pageIndex < 0 || pageSize < 0)
            {
                throw new Exception("Dữ liệu bạn nhập vào không đúng, hãy nhập lại");
            }

            var filterCustomer = _customerRepository.CustomerFilter(pageIndex, pageSize, fullName, phoneNumber);

            // validate dữ liệu được thêm vào để lọc

            return filterCustomer;
        }
    }
}