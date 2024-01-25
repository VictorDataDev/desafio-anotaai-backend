using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AnotaAi.Infrastructure.Config.mongo
{
    public static class MongoDbConfig
    {
        public static IServiceCollection AddMongo(this IServiceCollection services)
        {

            services.AddSingleton<MongoDbOptions>(sp =>
            {
                var configuration = sp.GetService<IConfiguration>();
                var options = new MongoDbOptions();

                configuration.GetSection("MongoConnection").Bind(options);

                return options;
            });

            services.AddSingleton<IMongoClient>(sp =>
            {
                var configuration = sp.GetService<IConfiguration>();
                var options = sp.GetService<MongoDbOptions>();

                var client = new MongoClient(options.ConnectionString);
                var db = client.GetDatabase(options.Database);

                return client;
            });

            services.AddTransient(sp =>
            {
                BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;

                var options = sp.GetService<MongoDbOptions>();
                var mongoClient = sp.GetService<IMongoClient>();

                var db = mongoClient.GetDatabase(options.Database);

                return db;
            });

            return services;
        }
    }
}
