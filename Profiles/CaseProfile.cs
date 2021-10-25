using AutoMapper;
using GroomingService.Dtos;
using GroomingService.Models;

namespace GroomingService.Profiles
{
    public class CaseProfile : Profile
    {
        public CaseProfile()
        {
            CreateMap<Case, CaseReadDto>();
        }
    }
}