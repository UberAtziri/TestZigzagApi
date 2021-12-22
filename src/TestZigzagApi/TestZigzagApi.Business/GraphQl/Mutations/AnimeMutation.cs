using System.Threading.Tasks;
using HotChocolate;
using TestZigzag.Core.Common;
using TestZigzagApi.Business.Services.Interfaces;

namespace TestZigzagApi.Business.GraphQl.Mutations
{
    public class AnimeMutation
    {
        public async Task<AnimeDomain> CreateAnime(AnimeDomain domain, [Service] IAnimeService animeService)
        {
            var result = await animeService.CreateAsync(domain);

            return result;
        }
    }
}