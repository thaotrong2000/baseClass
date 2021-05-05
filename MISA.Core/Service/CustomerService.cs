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
    /// <summary>
    /// Xử lý nghiệp vụ riêng cho riêng Customer
    /// Class này kế thừa những nghiệp vụ chung từ BaseService
    /// Class này custom thêm các nghiệp vụ riêng cần thiết
    /// </summary>
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
            // Kiểm tra dữ liệu đã tồn tại hay chưa?
            if (entity != null)
            {
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
            // Số thứ tự trang và số phần tử trên trang phải lớn hơn 0
            // int PageIndex, int PageSize
            if (pageIndex <= 0 || pageSize <= 0)
            {
                throw new CustomerException("Dữ liệu bạn nhập vào không đúng, hãy nhập lại");
            }

            /// Nếu không nhập FullName và PhoneNumber thì nó sẽ tự nhận là chuỗi rỗng ( Empty )
            if (string.IsNullOrEmpty(fullName))
            {
                fullName = string.Empty;
            }
            if (string.IsNullOrEmpty(phoneNumber))
            {
                phoneNumber = string.Empty;
            }
            var filterCustomer = _customerRepository.CustomerFilter(pageIndex, pageSize, fullName, phoneNumber);

            // validate dữ liệu được thêm vào để lọc

            return filterCustomer;
        }
    }
}