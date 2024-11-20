using Microsoft.Extensions.DependencyInjection;
using Storium.Domain.Abstractions;
using Storium.Domain.Categories;
using Storium.Domain.Orders;
using Storium.Domain.Products;
using Storium.Domain.Users;
using Storium.Infrastructure.Context;
using Storium.Infrastructure.Repositories;

namespace Storium.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>();
            services.AddScoped<IUnitOfWork>(opt=>opt.GetRequiredService<ApplicationDbContext>());

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}
