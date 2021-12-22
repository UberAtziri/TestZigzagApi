using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TestZigzag.Core.Common;
using TestZigzagApi.Business.Services.Interfaces;
using TestZigzagApi.Data.Entities;
using TestZigzagApi.Data.Repositories.Interfaces;

namespace TestZigzagApi.Business.Services
{
    public class AnimeService : IAnimeService
    {
        private readonly IRepository<AnimeEntity> animeRepository;
        private readonly IMapper mapper;

        public AnimeService(IRepository<AnimeEntity> animeRepository, IMapper mapper)
        {
            this.animeRepository = animeRepository;
            this.mapper = mapper;
        }

        public async Task<List<AnimeDomain>> GetAllAsync()
        {
            var entities = await this.animeRepository.GetAllAsync();

            return this.mapper.Map<List<AnimeDomain>>(entities);
        }

        public async Task<AnimeDomain> CreateAsync(AnimeDomain domain)
        {
            var created = await this.animeRepository.CreateAsync(this.mapper.Map<AnimeEntity>(domain));
            
            return this.mapper.Map<AnimeDomain>(created);
        }

        public async Task<AnimeDomain> UpdateAsync(AnimeDomain animeDomain)
        {
            var updated = await this.animeRepository.UpdateAsync(this.mapper.Map<AnimeEntity>(animeDomain));

            return this.mapper.Map<AnimeDomain>(updated);
        }

        public async Task DeleteAsync(Guid id)
        {
            await this.animeRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<string>> GetCategoriesAsync()
        {
            var categories = await this.animeRepository.GetFieldValueAsync(
                x => x.CategoryName != null,
                y => y.CategoryName);

            return categories.Select(x => x.ToLowerInvariant()).Distinct();
        }

        public async Task<IEnumerable<AnimeDomain>> GetByCategoryAsync(string categoryName)
        {
            if (categoryName == null)
            {
                return await this.GetAllAsync();
            }

            var entities = await this.animeRepository
                .GetByFilterAsync(x => x.CategoryName != null &&
                                  x.CategoryName.ToLowerInvariant() == categoryName.ToLowerInvariant());

            return this.mapper.Map<List<AnimeDomain>>(entities);
        }
    }
}