using GetFood.Infra.Services;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace GetFood.Infra
{
    public static class Setup
    {
        public static void AddInfra(this IServiceCollection services)
        {
            services.AddCacheSetup();
            services.AddServices();
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICacheService, CacheService>();
        }

        private static void AddCacheSetup(this IServiceCollection services)
        {
            var optionsWrite = ConfigurationOptions.Parse("localhost:6379");
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = optionsWrite.ToString();
                options.InstanceName = "fsw";
            });
        }
    }
}
