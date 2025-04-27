using KoperasiTenteraAPIServices.Domain.Models.BaseModels;
using System.ComponentModel.DataAnnotations;

namespace KoperasiTenteraAPIServices.Domain.Models.Database_Models
{
    public class Customer : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string CustomerName { get; set; } = default!;

        [Required]
        [MaxLength(100)]
        public string ICNumber { get; set; } = default!;   

        [Required]
        [MaxLength(25)]
        [Phone]
        public string Phone { get; set; } = default!;

        [Required]
        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; } = default!;

        [MaxLength(6)]
        public string? Pin { get; set; }

        public byte[]? Biometric { get; set; }

        public bool IsPinVerified { get; set; } = false;
        public bool IsPhoneVerified { get; set; } = false;
        public bool IsEmailVerified { get; set; } = false;
    }
}
