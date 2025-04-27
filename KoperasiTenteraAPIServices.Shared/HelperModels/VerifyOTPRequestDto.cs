using KoperasiTenteraAPIServices.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace KoperasiTenteraAPIServices.Shared.HelperModels
{
    public class VerifyOTPRequestDto
    {
        public string CustomerId { get; set; } = default!;

        [MaxLength(4)]
        public string OTP { get; set; } = default!;

        public OtpPurpose OtpPurpose { get; set; }
    }
}
