using KoperasiTenteraAPIServices.Domain.Communication;
using KoperasiTenteraAPIServices.Domain.Repositories.Customers;
using KoperasiTenteraAPIServices.Domain.Repositories.OTPs;
using KoperasiTenteraAPIServices.Infrastructure.Communication;
using KoperasiTenteraAPIServices.Infrastructure.Context;
using KoperasiTenteraAPIServices.Infrastructure.Repositories.Customers;
using KoperasiTenteraAPIServices.Infrastructure.Repositories.OTPs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KoperasiTenteraAPIServices.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<APIServicesDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


            // Register other services and repositories
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ISmtpEmailSender, SmtpEmailSender>();
            services.AddTransient<ISmsService, SmsService>();
            services.AddTransient<IOTPRepository, OTPRepository>();

            return services;
        }
    }
}
