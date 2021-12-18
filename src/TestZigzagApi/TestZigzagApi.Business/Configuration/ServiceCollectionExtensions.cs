using Microsoft.Extensions.DependencyInjection;
using TestZigzagApi.Business.Services;
using TestZigzagApi.Business.Services.Interfaces;

namespace TestZigzagApi.Business.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessLayer(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IAuthService, AuthService>();
            serviceCollection.AddTransient<IAnimeService, AnimeService>();

            return serviceCollection;
        }
    }
}