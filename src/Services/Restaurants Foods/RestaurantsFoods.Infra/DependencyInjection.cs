using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestaurantsFoods.Domain.Repositories;
using RestaurantsFoods.Infra.Persistence;
using RestaurantsFoods.Infra.Persistence.Repositories;

namespace RestaurantsFoods.Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RestaurantsFoodsContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("RestaurantsFoodsContext"),
                    b => b.MigrationsAssembly(typeof(RestaurantsFoodsContext).Assembly.FullName)));

            services.AddScoped<ICategoryRepository, CategoryRepository>();

            return services;
        }
    }
}
