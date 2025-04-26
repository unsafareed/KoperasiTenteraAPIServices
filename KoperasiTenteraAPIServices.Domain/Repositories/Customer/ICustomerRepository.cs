using KoperasiTenteraAPIServices.Domain.Models.Database_Models;

namespace KoperasiTenteraAPIServices.Domain.Repositories.Customers
{
    public interface ICustomerRepository
    {
        Task<bool> IsCustomerExistsAsync(string ICNumber, CancellationToken ct);
        Task<string> RegisterCustomerAsync(Customer customer, CancellationToken ct);
    }
}
