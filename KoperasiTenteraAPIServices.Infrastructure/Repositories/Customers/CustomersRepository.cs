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

    }
}
