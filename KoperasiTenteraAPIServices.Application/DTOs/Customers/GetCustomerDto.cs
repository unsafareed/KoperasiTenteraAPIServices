namespace KoperasiTenteraAPIServices.Application.DTOs.Customers
{
    public class GetCustomerDto
    {
        public string Id { get; set; } = default!;
        public string CustomerName { get; set; } = default!;
        public string ICNumber { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string? Pin { get; set; }
        public byte[]? Biometric { get; set; }
        public bool IsPhoneVerified { get; set; }
        public bool IsEmailVerified { get; set; }
        public bool IsPinVerified { get; set; }
    }
}
