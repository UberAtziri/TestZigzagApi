using System;
using AutoMapper;
using TestZigzag.Core.Common;

namespace TestZigzagApi.Models.Mappers
{
    public class AnimeMapperProfile : Profile
    {
        public AnimeMapperProfile()
        {
            CreateMap<AnimeDomain, AnimeResponse>()
                .ForMember(
                    x => x.Id,
                    opt => opt.MapFrom(x => x.Id.ToString()));
            
            CreateMap<AnimeCreateRequest, AnimeDomain>();
            CreateMap<AnimeUpdateRequest, AnimeDomain>()
                .ForMember(
                    x => x.Id,
                    opt => opt.MapFrom(x => Guid.Parse(x.Id)));
        }
    }
}