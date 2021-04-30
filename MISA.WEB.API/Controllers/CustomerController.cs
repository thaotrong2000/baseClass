using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MySqlConnector;
using System.Data;
using MISA.Core.Interfaces.Services;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Entities;
using MISA.Core.Service;

namespace MISA.WEB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerService _customerService;
        ICustomerRepository _customerRepository;

        public CustomerController(ICustomerService customerService, ICustomerRepository customerRepository)
        {
            _customerService = customerService;
            _customerRepository = customerRepository;
        }


        /// <summary>
        /// Thông tin toàn bộ khách hàng
        /// </summary>
        /// <returns>
        /// StatusCode: 
        /// 200: Lấy thông tin thành công 
        /// 204: Không lấy được thông tin gì 
        /// </returns>
        /// CreatedBy:NTThao(19/04/2021)
        [HttpGet()]
        public IActionResult Get()
        {
            // Lấy dữ liệu
            var customers = _customerRepository.GetAll();

            // Kiểm tra điều kiện hiển thị dữ liệu
            if (customers.Count() > 0)
            {
                return Ok(customers);
            }
            else
            {
                return NoContent();
            }
        }


        /// <summary>
        /// Thêm một khách hàng mới
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>
        /// StatusCode: 
        /// 201: Created - thêm thành công
        /// 204: Không thêm thành công
        /// </returns>
        /// CreatedBy: NTThao(20/04/2021)
        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            var customers = _customerService.Insert(customer);
            if (customers > 0)
            {
                return Ok("Bạn đã thêm dữ liệu thành công");
            }
            else
            {
                return NoContent();
            }
        }

        /// <summary>
        /// Hiển thị thông tin của khách hàng thông qua CustomerId
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpGet("{customerId}")]
        public IActionResult getCustomerById(Guid customerId)
        {
            var customer = _customerRepository.GetById(customerId);

            if (customer == null)
            {
                var res = new
                {
                    devMsg = "CustomerId của bạn nhập không chính xác, hãy thử lại!!!",
                    MISACode = "MISA004"
                };
                return StatusCode(400, res);
            }
            else
            {
                return Ok(customer);
            }
        }



        /// <summary>
        /// Xóa một khách hàng theo CustomerId
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <returns>
        /// StatusCode: 
        /// 204 - Xóa thành công 
        /// 500 - Xóa không thành công
        /// </returns>
        [HttpDelete("{CustomerId}")]
        public IActionResult DeleteById(Guid CustomerId)
        {

            var customers = _customerRepository.Delete(CustomerId);
            if (customers > 0)
            {
                return StatusCode(204);
            }
            else
            {
                var res = new
                {
                    devMsg = "Không xóa được dữ liệu,vui lòng kiểm tra lại CustomerId bạn vừa nhập !!!",
                    MISACode = "MISA006"
                };
                return StatusCode(400, res);
            }


        }

        /// <summary>
        /// Sửa thông tin của một khách hàng: Cập nhật thông tin mới 'customer'
        /// </summary>
        /// <param name="CustomerCode"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put(Customer customer)
        {
            var updateCustomer = _customerRepository.Update(customer);
            if (updateCustomer > 0)
            {
                return Created("Ok Sửa", "Cập nhật dữ liệu thành công");
            }
            else
            {
                return StatusCode(400, "Khong cap nhat duoc");
            }
        }

    }








}
