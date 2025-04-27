using KoperasiTenteraAPIServices.Domain.Models.BaseModels;
using KoperasiTenteraAPIServices.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace KoperasiTenteraAPIServices.Domain.Models.Database_Models
{
    public class CustomerOtpVerification : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string CustomerReference { get; set; } = default!;
        // You can store CustomerId or ICNumber or Email here to map OTP to customer.

        [Required]
        [MaxLength(10)]
        public string OtpCode { get; set; } = default!;

        [Required]
        public OtpPurpose Purpose { get; set; }

        [Required]
        public DateTime ExpiryTime { get; set; }

        public bool IsUsed { get; set; } = false;
    }

}
