using FluentValidation;
using InsideChallenge.Application.Features.Orders.Commands.AddProductsToOrder;
using InsideChallenge.Application.Features.Orders.Commands.CloseOrder;
using InsideChallenge.Application.Features.Orders.Commands.RemoveProductsFromOrder;
using System.Reflection;

namespace InsideChallenge.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            AddAutoMapper(services);
            AddMediatR(services);
            AddValidators(services);
            return services;
        }

        private static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }

        private static IServiceCollection AddMediatR(this IServiceCollection services)
        {
            services.AddMediatR(options =>
            {
                options.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly);

            });
            return services;
        }

        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            //Poderia ter usado o pacote Scrutor para tornar isso mais sucinto 
            services.AddTransient<IValidator<RemoveProductFromOrderCommand>, RemoveProductFromOrderValidator>();
            services.AddTransient<IValidator<AddProductsToOrderCommand>, AddProductToOrderCommandValidator>();
            services.AddTransient<IValidator<CloseOrderCommand>, CloseOrderCommandValidator>();
            return services;
        }


    }
}