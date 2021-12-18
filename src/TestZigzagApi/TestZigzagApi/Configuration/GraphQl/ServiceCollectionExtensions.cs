using Microsoft.Extensions.DependencyInjection;
using TestZigzagApi.Business.GraphQl.Mutations;
using TestZigzagApi.Business.GraphQl.Queries;

namespace TestZigzagApi.Configuration.GraphQl
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGraphQl(this IServiceCollection collection)
        {
            collection.AddGraphQLServer()
                .AddQueryType<AnimeQueries>()
                .AddMutationType<AnimeMutation>()
                .AddMongoDbFiltering()
                .AddMongoDbSorting()
                .AddMongoDbPagingProviders();

            return collection;
        }
    }
}