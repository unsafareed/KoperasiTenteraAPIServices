namespace KoperasiTenteraAPIServices.Application.DTOs.Customers
{
    public class SetCustomerPinDto
    {
        public string CustomerId { get; set; } = default!;
        public string Pin { get; set; } = default!;
    }
}
