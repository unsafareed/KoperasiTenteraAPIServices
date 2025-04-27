using KoperasiTenteraAPIServices.Application.DTOs.Customers;

namespace KoperasiTenteraAPIServices.Application.Inerfaces.Customers
{
    public interface ICustomerService
    {
        Task<RegisterCustomerResponseDTO> RegisterCustomerAsync(RegisterCustomerDTO customer, CancellationToken ct);
        Task<GetCustomerDto> CustomerLoginByICNumberAsync(string IcNumber, CancellationToken ct);
        Task<bool> SetCustomerPinAsync(SetCustomerPinDto request, CancellationToken ct);
        Task<bool> VerifyCustomerPinAsync(VerifyCustomerPinDto request, CancellationToken ct);
        Task<bool> SetCustomerBiometricAsync(SetCustomerBiometric request, CancellationToken ct);
    }
}
