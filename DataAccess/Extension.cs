using DataAccess.IRepositories;
using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess
{
    public static class Extension
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            return services.AddScoped<EStoreContext>()
                .AddScoped<IMemberRepository, MemberRepository>()
                .AddScoped<IProductRepository, ProductRepository>()
                .AddScoped<IOrderDetailRepository, OrderDetailRepository>()
                .AddScoped<IOrderRepository, OrderRepository>()
                .AddScoped<ICategoryRepository, CategoryRepository>();
            //.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }
    }
}
