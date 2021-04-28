﻿using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Service
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository) : base(customerRepository)
        {
            _customerRepository = customerRepository;
        }

        protected override void Validate(Customer entity)
        {
            // Check dữ liệu có trống hay không
            var customer = entity as Customer;
            if (string.IsNullOrEmpty(customer.CustomerCode))
            {
                throw new Exception("Bạn không được để trống mã khách hàng, hãy nhập nó");
            }



            // Check dữ liệu đã tồn tại hay chưa
            if (entity is Customer)
            {


                //Validate dữ liệu
                // Check các thông tin bắt buộc nhập
                // CustomerExeption.CheckCustomerCodeEmpty(customer.CustomerCode)

                // Check trùng mã  
                var isExist = _customerRepository.CheckCustomerCodeExist(customer.CustomerCode);
                if (isExist == true)
                {
                    throw new Exception("Mã khách hàng đã tồn tại trên hệ thống!.");
                }
            }


        }


        //public int Delete(Guid customerId)
        //{
        //    var rowsAffect = _customerRepository.Delete(customerId);
        //    return rowsAffect;
        //}

        //public IEnumerable<Customer> GetAll()
        //{
        //    var customers = _customerRepository.GetAll();
        //    return customers;
        //}

        //public Customer GetById(Guid customerId)
        //{
        //    var customers = _customerRepository.GetById(customerId);
        //    return customers;
        //}

        //public int Insert(Customer customer)
        //{

        //    // Validate dữ liệu 
        //    // Check các thông tin bắt buộc nhập
        //    if (string.IsNullOrEmpty(customer.CustomerCode))
        //    {
        //        var response = new
        //        {
        //            devMsg = "Mã khách hàng không được để trống",
        //            MISACode = "001"
        //        };
        //        throw new Exception("Mã khách hàng không được phép để trống!!!");
        //    }
        //    var rowsAffect = _customerRepository.Insert(customer);
        //    return rowsAffect;
        //}

        //public int Update(Customer customer)
        //{
        //    var rowsAffect = _customerRepository.Update(customer);
        //    return rowsAffect;
        //}
    }
}
