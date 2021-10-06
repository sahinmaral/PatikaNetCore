using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace MovieStoreAppWebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        //[HttpPost("login")]
        //public IActionResult Login([FromBody] ReadCustomerViewModel viewModel)
        //{

        //}

        //[HttpPost("signup")]
        //public IActionResult SignUp([FromBody] CreateCustomerViewModel viewModel)
        //{

        //}
    }
}
