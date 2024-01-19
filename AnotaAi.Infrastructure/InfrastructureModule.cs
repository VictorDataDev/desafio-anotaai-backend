using AnotaAi.Infrastructure.Config.mongo;
using AnotaAi.Infrastructure.Repositories.Category;
using AnotaAi.Infrastructure.Repositories.Product;
using Microsoft.Extensions.DependencyInjection;

namespace AnotaAi.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services
                .AddMongo()
                .AddRepositories();

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
