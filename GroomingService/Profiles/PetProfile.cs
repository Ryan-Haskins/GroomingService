using AutoMapper;
using GroomingService.Dtos;
using GroomingService.Models;

namespace GroomingService.Profiles
{
    public class PetProfile : Profile
    {
        public PetProfile()
        {
            CreateMap<Pet, PetReadDto>();
            CreateMap<PetCreateDto, Pet>();
            CreateMap<PetUpdateDto, Pet>();
            CreateMap<Pet, PetUpdateDto>();
        }
    }
}
