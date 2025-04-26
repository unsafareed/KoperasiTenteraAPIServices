using KoperasiTenteraAPIServices.Application.DTOs.Customers;
using Microsoft.AspNetCore.Mvc;

namespace KoperasiTenteraAPIServices.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterCustomerAsync([FromBody] RegisterCustomerDTO request, CancellationToken ct)
        {
            try
            {
                //await _otpService.GenerateEmailOtpAsync(request.Email);
                return Ok(new { Message = "OTP Sent" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
