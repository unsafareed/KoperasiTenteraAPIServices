using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KoperasiTenteraAPIServices.Infrastructure.Context
{
    public class APIServicesDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public APIServicesDbContext(DbContextOptions<APIServicesDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
