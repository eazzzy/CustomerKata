using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        /// <summary>
        /// Get All
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="204">No Content</response>
        /// <response code="400">Bad Request, invalid information</response>
        /// <response code="401">Unauthorised</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Internal error</response>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _customerService.GetAll();

                return (result != null && result.Any())
                    ? (IActionResult)Ok(Models.CustomerModel.Parse(result))
                    : NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        /// <summary>
        /// Search
        /// </summary>
        /// <param name="query">query</param>
        /// <response code="200">Ok</response>
        /// <response code="204">No Content</response>
        /// <response code="400">Bad Request, invalid information</response>
        /// <response code="401">Unauthorised</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Internal error</response>
        [HttpGet("{query}")]
        public async Task<IActionResult> Search(string query)
        {
            try
            {
                var result = await _customerService.Search(query);

                return (result != null && result.Any())
                    ? (IActionResult)Ok(Models.CustomerModel.Parse(result))
                    : NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
