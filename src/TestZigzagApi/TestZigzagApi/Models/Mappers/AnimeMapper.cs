using System.Collections.Generic;
using System.Linq;
using TestZigzag.Core.Common;

namespace TestZigzagApi.Models.Mappers
{
    public static class AnimeMapper
    {
        public static AnimeResponse ToAnimeResponse(this AnimeDomain domain)
        {
            return domain == null
                ? default
                : new AnimeResponse
                {
                    Id = domain.Id.ToString(),
                    Name = domain.Name,
                    Rating = domain.Rating,
                    Description = domain.Description,
                    ReleaseDate = domain.ReleaseDate,
                    NumberOfEpisodes = domain.NumberOfEpisodes,
                    CategoryName = domain.CategoryName
                };
        }

        public static List<AnimeResponse> AllToAnimeResponse(this IEnumerable<AnimeDomain> domains)
        {
            return domains?.Select(ToAnimeResponse).ToList();
        }

        public static AnimeDomain ToAnimeDomain(this AnimeCreateRequest request)
        {
            return request == null
                ? default
                : new AnimeDomain
                {
                    Name = request.Name,
                    Rating = request.Rating,
                    Description = request.Description,
                    ReleaseDate = request.ReleaseDate,
                    NumberOfEpisodes = request.NumberOfEpisodes,
                    CategoryName = request.CategoryName
                };
        }

        public static AnimeDomain ToAnimeDomain(this AnimeUpdateRequest request)
        {
            return request == null
                ? default
                : new AnimeDomain
                {
                    Name = request.Name,
                    Rating = request.Rating,
                    Description = request.Description,
                    ReleaseDate = request.ReleaseDate,
                    NumberOfEpisodes = request.NumberOfEpisodes,
                    CategoryName = request.CategoryName
                };
        }
    }
}