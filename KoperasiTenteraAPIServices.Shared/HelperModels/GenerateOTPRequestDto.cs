using KoperasiTenteraAPIServices.Shared.Enums;

namespace KoperasiTenteraAPIServices.Shared.HelperModels
{
    public class GenerateOTPRequestDto
    {
        public string CustomerId { get; set; } = default!;
        public OtpPurpose OtpPurpose { get; set; }
    }
}
