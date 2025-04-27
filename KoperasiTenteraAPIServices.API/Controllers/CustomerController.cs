using KoperasiTenteraAPIServices.Application.DTOs.Customers;
using KoperasiTenteraAPIServices.Application.Inerfaces.Customers;
using KoperasiTenteraAPIServices.Shared.Exceptions;
using KoperasiTenteraAPIServices.Shared.HelperModels;
using Microsoft.AspNetCore.Mvc;

namespace KoperasiTenteraAPIServices.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;

        public CustomerController(ILogger<CustomerController> logger,
                                  ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterCustomerAsync([FromBody] RegisterCustomerDTO request, CancellationToken ct)
        {
            try
            {
                var response = await _customerService.RegisterCustomerAsync(request, ct);

                return Ok(response);
            }
            catch (BusinessFailureException ex)
            {
                return StatusCode(ex.StatusCode, ex.ExceptionDetails);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);

                var exceptionModel = new ExceptionModel
                {
                    Title = "Application Error Occurred",
                    Message = "There is some issue while processing your request.",
                    StatusCode = 500
                };

                return StatusCode(500, exceptionModel);
            }
        }

        [HttpGet("login")]
        public async Task<IActionResult> CustomerLoginAsync([FromQuery] string IcNumber, CancellationToken ct)
        {
            try
            {
                var response = await _customerService.CustomerLoginByICNumberAsync(IcNumber, ct);

                return Ok(response);
            }
            catch (BusinessFailureException ex)
            {
                return StatusCode(ex.StatusCode, ex.ExceptionDetails);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);

                var exceptionModel = new ExceptionModel
                {
                    Title = "Application Error Occurred",
                    Message = "There is some issue while processing your request.",
                    StatusCode = 500
                };

                return StatusCode(500, exceptionModel);
            }
        }

        [HttpPost("set-pin")]
        public async Task<IActionResult> SetCustomerPinAsync([FromBody] SetCustomerPinDto request, CancellationToken ct)
        {
            try
            {
                var response = await _customerService.SetCustomerPinAsync(request, ct);

                return Ok(response);
            }
            catch (BusinessFailureException ex)
            {
                return StatusCode(ex.StatusCode, ex.ExceptionDetails);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);

                var exceptionModel = new ExceptionModel
                {
                    Title = "Application Error Occurred",
                    Message = "There is some issue while processing your request.",
                    StatusCode = 500
                };

                return StatusCode(500, exceptionModel);
            }
        }

        [HttpPost("verify-pin")]
        public async Task<IActionResult> VerifyCustomerPinAsync([FromBody] VerifyCustomerPinDto request, CancellationToken ct)
        {
            try
            {
                var response = await _customerService.VerifyCustomerPinAsync(request, ct);

                return Ok(response);
            }
            catch (BusinessFailureException ex)
            {
                return StatusCode(ex.StatusCode, ex.ExceptionDetails);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);

                var exceptionModel = new ExceptionModel
                {
                    Title = "Application Error Occurred",
                    Message = "There is some issue while processing your request.",
                    StatusCode = 500
                };

                return StatusCode(500, exceptionModel);
            }
        }

        [HttpPost("set-biometric")]
        public async Task<IActionResult> SetCustomerBiometricAsync([FromBody] SetCustomerBiometric request, CancellationToken ct)
        {
            try
            {
                var response = await _customerService.SetCustomerBiometricAsync(request, ct);

                return Ok(response);
            }
            catch (BusinessFailureException ex)
            {
                return StatusCode(ex.StatusCode, ex.ExceptionDetails);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);

                var exceptionModel = new ExceptionModel
                {
                    Title = "Application Error Occurred",
                    Message = "There is some issue while processing your request.",
                    StatusCode = 500
                };

                return StatusCode(500, exceptionModel);
            }
        }
    }
}
