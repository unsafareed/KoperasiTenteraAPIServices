using KoperasiTenteraAPIServices.Domain.Communication;
using KoperasiTenteraAPIServices.Shared.HelperModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text;

namespace KoperasiTenteraAPIServices.Infrastructure.Communication
{
    public class SmsService : ISmsService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<SmsService> _logger;

        public SmsService(IConfiguration configuration,
                          ILogger<SmsService> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<bool> Send(SmsDto sms)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var DataInJson = JsonConvert.SerializeObject(sms);

                    var stringContent = new StringContent(DataInJson, Encoding.UTF8, "application/json");

                    httpClient.BaseAddress = new Uri(_configuration.GetSection("SMS:SmsApiUrl").Value!);

                    System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                    httpClient.DefaultRequestHeaders.Add("x-Gateway-APIKey", "TestingGUID");

                    var response = await httpClient.PostAsync("Home/SendMessage", stringContent);

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);

                return false;
            }
        }
    }
}
