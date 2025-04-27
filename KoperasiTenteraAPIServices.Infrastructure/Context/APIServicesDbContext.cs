using KoperasiTenteraAPIServices.Domain.Models.Database_Models;
using Microsoft.EntityFrameworkCore;

namespace KoperasiTenteraAPIServices.Infrastructure.Context
{
    public class APIServicesDbContext : DbContext
    {
        public APIServicesDbContext(DbContextOptions<APIServicesDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerOtpVerification> CustomerOtpVerifications { get; set; }
    }
}
