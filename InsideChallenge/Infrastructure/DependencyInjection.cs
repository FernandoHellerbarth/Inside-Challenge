using InsideChallenge.Domain.Repositories;
using InsideChallenge.Infrastructure.Data;
using InsideChallenge.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InsideChallenge.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistence(configuration);
            return services;
        }

        private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<InsideChallengeContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
