using KoperasiTenteraAPIServices.Domain.Communication;
using KoperasiTenteraAPIServices.Shared.HelperModels;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace KoperasiTenteraAPIServices.Infrastructure.Communication
{
    public class SmtpEmailSender : ISmtpEmailSender
    {
        private readonly SmtpConfigModel _smtpConfig;

        public SmtpEmailSender(IOptions<SmtpConfigModel> smtpConfig)
        {
            _smtpConfig = smtpConfig.Value;
        }

        public async Task<string> SendEmail(UserEmailOptions emailOptions)
        {
            try
            {
                MailMessage mail = new MailMessage()
                {
                    Subject = emailOptions.subject,
                    Body = emailOptions.body,
                    From = new MailAddress(_smtpConfig.senderAddress, _smtpConfig.senderDisplayName),
                    IsBodyHtml = _smtpConfig.isBodyHtml,
                    BodyEncoding = Encoding.Default
                };

                mail.To.Add(new MailAddress(emailOptions.toEmail));

                NetworkCredential networkCredential = new NetworkCredential(_smtpConfig.userName, _smtpConfig.password);

                SmtpClient client = new SmtpClient()
                {
                    Host = _smtpConfig.host,
                    Port = _smtpConfig.port,
                    EnableSsl = _smtpConfig.enableSsl,
                    Credentials = networkCredential
                };

                await client.SendMailAsync(mail);

                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
    }
}
