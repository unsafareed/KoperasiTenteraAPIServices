using Microsoft.AspNetCore.Http;
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

        [HttpGet]
        [Route("UnsaIsLove")]
        public string GetLoveLevel()
        {
            _logger.LogInformation("Unsaah loves Ushhhman <3");

            _logger.LogInformation("Usman loves Unsaah <3");

            return "To infinity and beyond ❤";
        }
    }
}
