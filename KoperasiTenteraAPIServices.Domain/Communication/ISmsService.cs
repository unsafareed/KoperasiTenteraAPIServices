using KoperasiTenteraAPIServices.Shared.HelperModels;

namespace KoperasiTenteraAPIServices.Domain.Communication
{
    public interface ISmsService
    {
        Task<bool> Send(SmsDto sms);   
    }
}
