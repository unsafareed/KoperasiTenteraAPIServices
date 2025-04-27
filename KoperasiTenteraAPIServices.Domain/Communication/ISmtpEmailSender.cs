using KoperasiTenteraAPIServices.Shared.HelperModels;

namespace KoperasiTenteraAPIServices.Domain.Communication
{
    public interface ISmtpEmailSender
    {
        Task<string> SendEmail(UserEmailOptions emailOptions);
    }
}
