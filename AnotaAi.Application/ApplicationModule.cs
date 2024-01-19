using AnotaAi.Application.Services.Category;
using AnotaAi.Application.Services.Product;
using AnotaAi.Application.Services.ServiceBus;
using Microsoft.Extensions.DependencyInjection;

namespace AnotaAi.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddApplicationServices();

            return services;
        }

        private static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IPublishService, PublishService>();

            return services;
        }
    }
}
