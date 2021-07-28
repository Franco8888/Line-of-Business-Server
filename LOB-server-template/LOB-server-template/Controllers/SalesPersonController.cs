using LOB_server_template.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using static LOB_server_template.Services.SalesPersonService;

namespace LOB_server_template.Controllers
{
    //[Authorize(Roles = )]
    [ApiController]
    [Route("api/lob/salesPerson")]
    public class SalesPersonController : ControllerBase
    {
        private readonly ISalesPersonService _salesPersonService;

        // ------------------------------------------------------------------------------------------------------------------------------------------------------------ //
        // CTOR
        // ------------------------------------------------------------------------------------------------------------------------------------------------------------ //

        public SalesPersonController(
            ISalesPersonService salesPersonService)
        {
            _salesPersonService = salesPersonService;
        }

        // ------------------------------------------------------------------------------------------------------------------------------------------------------------ //
        // GET getAllCustomers
        // ------------------------------------------------------------------------------------------------------------------------------------------------------------ //

        [HttpGet("getAllCustomers")]
        public IActionResult GetCustomers()
        {
            var result = _salesPersonService.GetCustomers();
            if (result.Count == 0)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // ------------------------------------------------------------------------------------------------------------------------------------------------------------ //
        // GET customer/{customerId}
        // ------------------------------------------------------------------------------------------------------------------------------------------------------------ //

        [HttpGet("customer/{customerId}")]
        public IActionResult GetCustomer(string customerId)
        {
            var result = _salesPersonService.GetCustomer(customerId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // ------------------------------------------------------------------------------------------------------------------------------------------------------------ //
        // POST customer/addCustomer
        // ------------------------------------------------------------------------------------------------------------------------------------------------------------ //

        [HttpPost("customer/addCustomer")]
        public IActionResult AddCustomer([FromBody] DTO_IN_Customer customerData)
        {
            var yeet = ConfigurationManager.AppSettings["database"];

            System.Console.WriteLine(yeet); 

            var result = _salesPersonService.AddCustomer(customerData);

            return Ok(result);
        }

        // ------------------------------------------------------------------------------------------------------------------------------------------------------------ //
        // POST addCustomers
        // ------------------------------------------------------------------------------------------------------------------------------------------------------------ //

        [HttpPost("addCustomers")]
        public IActionResult AddCustomers([FromBody] List<DTO_IN_Customer> customersData)
        {
            var result = _salesPersonService.AddCustomers(customersData);

            return Ok(result);
        }

        // ------------------------------------------------------------------------------------------------------------------------------------------------------------ //
        // POST customer/{customerId}/update
        // ------------------------------------------------------------------------------------------------------------------------------------------------------------ //

        [HttpPost("customer/{customerId}/update")]
        public IActionResult UpdateCustomer(string customerId, [FromBody] DTO_IN_Customer customerData)
        {
            var result = _salesPersonService.UpdateCustomer(customerId, customerData);

            return Ok(result);
        }

        // ------------------------------------------------------------------------------------------------------------------------------------------------------------ //
        // Get customer/{customerId}/update
        // ------------------------------------------------------------------------------------------------------------------------------------------------------------ //

        [HttpGet("customer/{customerId}/delete")]
        public IActionResult DeleteCustomer(string customerId)
        {
            var result = _salesPersonService.DeleteCustomer(customerId);

            return Ok(result);
        }
    }
}
