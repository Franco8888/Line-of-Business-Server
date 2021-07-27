using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LOB_server_template.Controllers
{
    //[Authorize(Roles = )]
    [ApiController]
    [Route("api/lob/admin")]
    public class AdminController : ControllerBase
    {
        [HttpPost("customer/{customerId}/addCustomer")]
        public IActionResult AddCustomer()
        {
            return Ok();
        }
    }
}
