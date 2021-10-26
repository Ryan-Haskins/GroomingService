using AutoMapper;
using GroomingService.Dtos;
using GroomingService.Models;

namespace GroomingService.Profiles
{
    public class CaseProfile : Profile
    {
        public CaseProfile()
        {
            //Source -> target
            CreateMap<Case, CaseReadDto>();
            //target -> Source
            CreateMap<CaseCreateDto, Case>();
        }
    }
}