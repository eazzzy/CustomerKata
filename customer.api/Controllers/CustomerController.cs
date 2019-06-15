using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using customerdata.lib;
using Microsoft.AspNetCore.Mvc;

namespace customer.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public ICustomerService _customerService { get; set; }

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _customerService.GetAll();

            return (result != null && result.Any())
                ? (IActionResult)Ok(Models.CustomerModel.Parse(result))
                : NoContent();
        }

        [HttpGet("{query}")]
        public async Task<IActionResult> Search(string query)
        {
            var result = await _customerService.Search(query);

            return (result != null && result.Any())
                ? (IActionResult)Ok(Models.CustomerModel.Parse(result))
                : NoContent();
        }
    }
}
