using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestZigzag.Core.Common;
using TestZigzagApi.Business.Services.Interfaces;
using TestZigzagApi.Models;

namespace TestZigzagApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimeController : ControllerBase
    {
        private readonly IAnimeService animeService;
        private readonly IMapper mapper;
        
        public AnimeController(IAnimeService animeService, IMapper mapper)
        {
            this.animeService = animeService;
            this.mapper = mapper;
        }
        
        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<AnimeResponse>> GetAll()
        {
            var result = await this.animeService.GetAll();

            return result.Select(this.mapper.Map<AnimeResponse>).ToList();
        }
        
        [Authorize]
        [HttpGet]
        [Route("category")]
        public async Task<IEnumerable<AnimeResponse>> GetAll([FromQuery] string categoryName)
        {
            var result = await this.animeService.GetByCategory(categoryName);

            return result.Select(this.mapper.Map<AnimeResponse>).ToList();
        }

        [Authorize]
        [HttpPost]
        public async Task<AnimeResponse> Create([FromBody] AnimeCreateRequest request)
        {
            var result = await this.animeService.Create(this.mapper.Map<AnimeDomain>(request));

            return this.mapper.Map<AnimeResponse>(result);
        }
        
        [Authorize]
        [HttpGet]
        [Route("/categories")]
        public async Task<IEnumerable<string>> GetCategories()
        {
            return await this.animeService.GetCategories();
        }

        [Authorize]
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await this.animeService.Delete(id);

            return Ok("Success");
        }

        [Authorize]
        [HttpPut]
        public async Task<AnimeResponse> Update([FromBody] AnimeUpdateRequest request)
        {
            var result = await this.animeService.Update(this.mapper.Map<AnimeDomain>(request));

            return this.mapper.Map<AnimeResponse>(result);
        }
    }
}