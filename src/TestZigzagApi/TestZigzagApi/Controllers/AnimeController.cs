using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestZigzagApi.Business.Services.Interfaces;
using TestZigzagApi.Models;
using TestZigzagApi.Models.Mappers;

namespace TestZigzagApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimeController : ControllerBase
    {
        private readonly IAnimeService animeService;
        
        public AnimeController(IAnimeService animeService)
        {
            this.animeService = animeService;
        }
        
        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<AnimeResponse>> GetAll()
        {
            var result = await this.animeService.GetAll();

            return result.AllToAnimeResponse();
        }
        
        [Authorize]
        [HttpGet]
        [Route("category")]
        public async Task<IEnumerable<AnimeResponse>> GetAll([FromQuery] string categoryName)
        {
            var result = await this.animeService.GetByCategory(categoryName);

            return result.AllToAnimeResponse();
        }

        [Authorize]
        [HttpPost]
        public async Task<AnimeResponse> Create([FromBody] AnimeCreateRequest request)
        {
            var result = await this.animeService.Create(request.ToAnimeDomain());

            return result.ToAnimeResponse();
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
            var result = await this.animeService.Update(request.ToAnimeDomain());

            return result.ToAnimeResponse();
        }
    }
}