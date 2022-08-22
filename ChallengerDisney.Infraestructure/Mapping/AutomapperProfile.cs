using AutoMapper;
using ChallengerDisney.Core.DTOs;
using ChallengerDisney.Core.Entities;

namespace ChallengerDisney.Infraestructure.Mapping
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Character, CharacterDto>();
            CreateMap<CharacterDto, Character>();

            CreateMap<MovieOrSeries, MovieOrSeriesDto>();
            CreateMap<MovieOrSeriesDto, MovieOrSeries>();

        }
    }
}
