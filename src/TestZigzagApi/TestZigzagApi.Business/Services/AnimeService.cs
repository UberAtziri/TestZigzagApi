using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestZigzag.Core.Common;
using TestZigzagApi.Business.Mappers;
using TestZigzagApi.Business.Services.Interfaces;
using TestZigzagApi.Data.Entities;
using TestZigzagApi.Data.Repositories.Interfaces;

namespace TestZigzagApi.Business.Services
{
    public class AnimeService : IAnimeService
    {
        private readonly IRepository<AnimeEntity> animeRepository;

        public AnimeService(IRepository<AnimeEntity> animeRepository)
        {
            this.animeRepository = animeRepository;
        }

        public async Task<List<AnimeDomain>> GetAll()
        {
            var entities = await this.animeRepository.GetAllAsync();

            return entities.AllToAnimeDomain();
        }

        public async Task<AnimeDomain> Create(AnimeDomain domain)
        {
            var created = await this.animeRepository.CreateAsync(domain.ToAnimeEntity());
            
            return created.ToAnimeDomain();
        }

        public async Task<AnimeDomain> Update(AnimeDomain animeDomain)
        {
            var updated = await this.animeRepository.UpdateAsync(animeDomain.ToAnimeEntity());

            return updated.ToAnimeDomain();
        }

        public async Task Delete(Guid id)
        {
            await this.animeRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<string>> GetCategories()
        {
            var categories = await this.animeRepository.GetFieldValue(
                x => x.CategoryName != null,
                y => y.CategoryName);

            return categories.Select(x => x.ToLowerInvariant()).Distinct();
        }

        public async Task<IEnumerable<AnimeDomain>> GetByCategory(string categoryName)
        {
            if (categoryName == null)
            {
                return await this.GetAll();
            }

            var entities = await this.animeRepository
                .GetByFilter(x => x.CategoryName != null &&
                                  x.CategoryName.ToLowerInvariant() == categoryName.ToLowerInvariant());

            return entities.AllToAnimeDomain();
        }
    }
}