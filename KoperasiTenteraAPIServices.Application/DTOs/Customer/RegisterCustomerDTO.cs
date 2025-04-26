using System.ComponentModel.DataAnnotations;

namespace KoperasiTenteraAPIServices.Application.DTOs.Customers
{
    public class RegisterCustomerDTO
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
    }
}
