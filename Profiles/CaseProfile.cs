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
            CreateMap<CaseCreateDto, Case>();
            CreateMap<CaseUpdateDto, Case>();
            CreateMap<Case, CaseUpdateDto>();
        }
    }
}