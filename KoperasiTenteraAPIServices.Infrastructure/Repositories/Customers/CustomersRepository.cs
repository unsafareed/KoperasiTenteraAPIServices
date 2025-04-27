using KoperasiTenteraAPIServices.Domain.Models.Database_Models;
using KoperasiTenteraAPIServices.Domain.Repositories.Customers;
using KoperasiTenteraAPIServices.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace KoperasiTenteraAPIServices.Infrastructure.Repositories.Customers
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly APIServicesDbContext _context;

        public CustomerRepository(APIServicesDbContext context)
        {
            _context = context;
        }

        public async Task<bool> IsCustomerExistsAsync(string ICNumber, CancellationToken ct)
        {
            var isCustomerExists = await _context.Customers
                                                 .AnyAsync(x => x.ICNumber == ICNumber, ct);

            return isCustomerExists;
        }

        public async Task<string> RegisterCustomerAsync(Customer customer, CancellationToken ct)
        {
            await _context.Customers.AddAsync(customer, ct);
            await _context.SaveChangesAsync(ct);

            return customer.Id;
        }

        public async Task<Customer?> GetCustomerByIcNumberAsync(string icNumber, CancellationToken ct)
        {
            Customer? customer = await _context.Customers
                                                 .FirstOrDefaultAsync(x => x.ICNumber == icNumber, ct);

            return customer;
        }

        public async Task<int> SetCustomerPinAsync((string customerId, string pin) request, CancellationToken ct)
        {
            var updatedRecords = await _context.Customers
                                        .Where(c => c.Id == request.customerId)
                                        .ExecuteUpdateAsync(c => c.SetProperty(c => c.Pin, c => request.pin), ct);

            return updatedRecords;
        }

        public async Task<bool> VerifyCustomerPinAsync((string customerId, string pin) request, CancellationToken ct)
        {
            Customer? entity = await _context.Customers
                                             .FirstOrDefaultAsync(x => x.Id == request.customerId, ct);
            if(entity is null)
            {
                return false;
            }

            if(entity.Pin != request.pin)
            {
                return false;
            }

            entity.IsPinVerified = true;

            _context.Customers.Update(entity);

            await _context.SaveChangesAsync(ct);
            
            return true;
        }

        public async Task<int> SetCustomerBiometricAsync((string customerId, byte[] biometric) request, CancellationToken ct)
        {
            var updatedRecords = await _context.Customers
                                        .Where(c => c.Id == request.customerId)
                                        .ExecuteUpdateAsync(c => c.SetProperty(c => c.Biometric, c => request.biometric), ct);

            return updatedRecords;
        }

        public async Task<Customer?> GetCustomerDetailsByIdAsync(string customerId, CancellationToken ct)
        {
            Customer? customer = await _context.Customers
                                            .FirstOrDefaultAsync(x => x.Id == customerId, ct);

            return customer;
        }
    }
}
