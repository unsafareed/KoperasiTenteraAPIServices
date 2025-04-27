using KoperasiTenteraAPIServices.Domain.Models.Database_Models;

namespace KoperasiTenteraAPIServices.Domain.Repositories.Customers
{
    public interface ICustomerRepository
    {
        Task<bool> IsCustomerExistsAsync(string ICNumber, CancellationToken ct);
        Task<string> RegisterCustomerAsync(Customer customer, CancellationToken ct);
        Task<Customer?> GetCustomerByIcNumberAsync(string customerId, CancellationToken ct);
        Task<int> SetCustomerPinAsync((string customerId, string pin) request, CancellationToken ct);
        Task<bool> VerifyCustomerPinAsync((string customerId, string pin) request, CancellationToken ct);
        Task<int> SetCustomerBiometricAsync((string customerId, byte[] biometric) request, CancellationToken ct);
        Task<Customer?> GetCustomerDetailsByIdAsync(string customerId, CancellationToken ct);
    }
}
