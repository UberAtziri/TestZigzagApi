using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestZigzag.Core.Common;

namespace TestZigzagApi.Business.Services.Interfaces
{
    public interface IAnimeService
    {
        Task<List<AnimeDomain>> GetAllAsync();

        Task<AnimeDomain> CreateAsync(AnimeDomain domain);

        Task<AnimeDomain> UpdateAsync(AnimeDomain animeDomain);

        Task DeleteAsync(Guid id);

        Task<IEnumerable<string>> GetCategoriesAsync();

        Task<IEnumerable<AnimeDomain>> GetByCategoryAsync(string categoryName);
    }
}