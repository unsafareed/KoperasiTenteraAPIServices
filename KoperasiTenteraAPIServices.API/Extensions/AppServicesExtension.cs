using KoperasiTenteraAPIServices.Application.Inerfaces.Customers;
using KoperasiTenteraAPIServices.Application.Interfaces.OTP;
using KoperasiTenteraAPIServices.Application.Services.Customers;
using KoperasiTenteraAPIServices.Application.Services.OTP;

namespace KoperasiTenteraAPIServices.API.Extensions
{
    public static class AppServicesExtension
    {
        public static void RegisterAppServices(this IServiceCollection services)
        {
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IOTPService, OTPService>();

            

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        }
    }
}
