using Microsoft.Extensions.DependencyInjection;
using TestZigzagApi.Models.Mappers;

namespace TestZigzagApi.Configuration.AutoMapper
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddConfiguredAutoMapper(this IServiceCollection collection)
        {
            collection.AddAutoMapper(opt =>
                {
                    opt.AddProfile<AnimeMapperProfile>();
                    opt.AddProfile<Business.Mappers.AnimeMapperProfile>();
                }
            );

            return collection;
        }
    }
}