using KoperasiTenteraAPIServices.Application.DTOs.Customers;
using KoperasiTenteraAPIServices.Application.Interfaces.OTP;
using KoperasiTenteraAPIServices.Shared.Exceptions;
using KoperasiTenteraAPIServices.Shared.HelperModels;
using Microsoft.AspNetCore.Mvc;

namespace KoperasiTenteraAPIServices.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OTPController : ControllerBase
    {
        private readonly ILogger<OTPController> _logger;
        private readonly IOTPService _oTPService;

        public OTPController(ILogger<OTPController> logger,
                             IOTPService oTPService)
        {
            _logger = logger;
            _oTPService = oTPService;
        }

        [HttpPost("generate-and-send")]
        public async Task<IActionResult> GenerateOTPAndSendAsync([FromBody] GenerateOTPRequestDto request, CancellationToken ct)
        {
            try
            {
                var response = await _oTPService.GenerateOTPAndSendAsync(request, ct);

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

        [HttpPost("verify")]
        public async Task<IActionResult> VerifyOTPAsync([FromBody] VerifyOTPRequestDto request, CancellationToken ct)
        {
            try
            {
                var response = await _oTPService.VerifyOTPAsync(request, ct);

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
