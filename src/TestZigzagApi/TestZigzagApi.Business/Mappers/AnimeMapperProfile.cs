using AutoMapper;
using TestZigzag.Core.Common;
using TestZigzagApi.Data.Entities;

namespace TestZigzagApi.Business.Mappers
{
    public class AnimeMapperProfile : Profile
    {
        public AnimeMapperProfile()
        {
            CreateMap<AnimeEntity, AnimeDomain>().ReverseMap();
        }
    }
}