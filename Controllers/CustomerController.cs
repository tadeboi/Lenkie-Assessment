using Lenkie_Assessment.Models;
using Lenkie_Assessment.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lenkie_Assessment.Controllers
{
    [Route("api/[controller]/[action]")]
    //[Authorize]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAccount(SignUpModel model)
        {
            return Ok(await _customerService.CreateUserAccount(model));
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin(LoginModel model)
        {
            return Ok(await _customerService.UserLogin(model));
        }
    }
}
