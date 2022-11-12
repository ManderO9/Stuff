using Microsoft.AspNetCore.Identity;
using Stuff.Core;

namespace Stuff.Server
{
    /// <summary>
    /// Extension methods for the <see cref="IServiceCollection"/> class
    /// </summary>
    public static  class ServiceConfiguration
    {
        /// <summary>
        /// Adds all the required services by our application to the DI container
        /// </summary>
        /// <param name="services">The services container to add services to</param>
        public static void AddApplicationServices(this IServiceCollection services)
        {
            // Add the identity system to the application
            services.AddIdentityCore<IdentityUser>()
                // Add the roles to the system
                .AddRoles<IdentityRole>()
                // Add the persistent stores
                .AddEntityFrameworkStores<ApplicationDbContext>()
                // Add token providers
                .AddDefaultTokenProviders();


            // Add data access for the products
            services.AddScoped<IProductDataAccess, ProductDataAccess>();

        }
    }
}
