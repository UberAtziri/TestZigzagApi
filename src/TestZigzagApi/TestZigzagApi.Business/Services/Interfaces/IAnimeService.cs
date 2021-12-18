using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestZigzag.Core.Common;

namespace TestZigzagApi.Business.Services.Interfaces
{
    public interface IAnimeService
    {
        Task<List<AnimeDomain>> GetAll();

        Task<AnimeDomain> Create(AnimeDomain domain);

        Task<AnimeDomain> Update(AnimeDomain animeDomain);

        Task Delete(Guid id);

        Task<IEnumerable<string>> GetCategories();

        Task<IEnumerable<AnimeDomain>> GetByCategory(string categoryName);
    }
}