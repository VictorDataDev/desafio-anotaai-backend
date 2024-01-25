using AnotaAi.Infrastructure.Config.mongo;
using AnotaAi.Core.Repositories.Categorys;
using AnotaAi.Core.Repositories.Products;
using Microsoft.Extensions.DependencyInjection;
using AnotaAi.Core.Interfaces;

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
            services.AddScoped<ICategoryRepository, CategoryMongoDbRepository>();
            services.AddScoped<IProductRepository, ProductMongoDbRepository>();

            return services;
        }
    }
}
