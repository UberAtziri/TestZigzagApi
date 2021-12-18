using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using TestZigzagApi.Data.Entities;
using TestZigzagApi.Data.Repositories;
using TestZigzagApi.Data.Repositories.Interfaces;

namespace TestZigzagApi.Data.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataLayer(this IServiceCollection collection, string connectionString, string databaseName)
        {
            collection.AddTransient<IUserRepository, UserRepository>();
            collection.AddTransient<IRepository<AnimeEntity>, Repository<AnimeEntity>>();

            collection.AddSingleton<IMongoClient>(c => { return new MongoClient(connectionString); });
            collection.AddScoped(x =>
            {
                var mongoDb = x.GetRequiredService<IMongoClient>();
                return mongoDb.GetDatabase(databaseName).GetCollection<AnimeEntity>(nameof(AnimeEntity));
            });
            collection.AddScoped(x =>
            {
                var mongoDb = x.GetRequiredService<IMongoClient>();
                return mongoDb.GetDatabase(databaseName).GetCollection<UserEntity>(nameof(UserEntity));
            });
            
            return collection;
        }
    }
}