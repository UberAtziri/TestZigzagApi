using System.Collections.Generic;
using System.Linq;
using TestZigzag.Core.Common;
using TestZigzagApi.Data.Entities;

namespace TestZigzagApi.Business.Mappers
{
    public static class AnimeMapper
    {
        public static AnimeDomain ToAnimeDomain(this AnimeEntity entity)
        {
            return entity == null
                ? default
                : new AnimeDomain
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Rating = entity.Rating,
                    Description = entity.Description,
                    ReleaseDate = entity.ReleaseDate,
                    NumberOfEpisodes = entity.NumberOfEpisodes,
                    CategoryName = entity.CategoryName
                };
        }

        public static List<AnimeDomain> AllToAnimeDomain(this IEnumerable<AnimeEntity> entities)
        {
            return entities?.Select(ToAnimeDomain).ToList();
        }

        public static AnimeEntity ToAnimeEntity(this AnimeDomain domain)
        {
            return domain == null
                ? default
                : new AnimeEntity
                {
                    Id = domain.Id,
                    Name = domain.Name,
                    Rating = domain.Rating,
                    Description = domain.Description,
                    ReleaseDate = domain.ReleaseDate,
                    NumberOfEpisodes = domain.NumberOfEpisodes,
                    CategoryName = domain.CategoryName
                };
        }
    }
}