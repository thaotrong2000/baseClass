using Microsoft.AspNetCore.Mvc;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Services;
using System;
using System.Linq;

namespace MISA.WEB.API.Controllers
{
    [Route("api/v1/customer-groups")]
    [ApiController]
    public class CustomerGroupController : ControllerBase
    {
        private ICustomerGroupService _customerGroupService;
        private ICustomerGroupRepository _customerGroupRepository;

        public CustomerGroupController(ICustomerGroupRepository customerGroupRepository, ICustomerGroupService customerGroupService)
        {
            _customerGroupRepository = customerGroupRepository;
            _customerGroupService = customerGroupService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var customerGroups = _customerGroupService.GetAll();
            if (customerGroups.Count() == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(customerGroups);
            }
        }

        [HttpGet("{customerGroupId}")]
        public IActionResult GetById(Guid customerGroupId)
        {
            var customerGroup = _customerGroupService.GetById(customerGroupId);
            if (customerGroup == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(customerGroup);
            }
        }
    }
}