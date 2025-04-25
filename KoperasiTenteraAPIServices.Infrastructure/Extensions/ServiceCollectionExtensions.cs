using KoperasiTenteraAPIServices.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
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

            services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddEntityFrameworkStores<APIServicesDbContext>()
                    .AddDefaultTokenProviders();

            // Register other services and repositories
            //services.AddTransient<IConversationsRepository, ConversationsRepository>();
            //services.AddTransient<IMessagesRepository, MessagesRepository>();
            //services.AddTransient<IUsersRepository, UsersRepository>();

            return services;
        }
    }
}
