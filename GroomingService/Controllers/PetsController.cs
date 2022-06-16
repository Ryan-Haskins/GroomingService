using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using GroomingService.Models;
using System.Collections.Generic;
using GroomingService.Data;
using GroomingService.Dtos;

namespace GroomingService.Controllers
{
    [Route("api/pets")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetRepo _repository;
        private readonly IMapper _mapper;
        public PetsController(IPetRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PetReadDto>> GetAllPets()
        {
            var pets = _repository.GetAllPets();

            return Ok(_mapper.Map<IEnumerable<PetReadDto>>(pets));
        }

        [HttpGet("{id}", Name = "GetPetById")]
        public ActionResult<PetReadDto> GetPetById(int id)
        {
            var petItem = _repository.GetPetById(id);
            if (petItem != null)
            {
                return Ok(_mapper.Map<PetReadDto>(petItem));
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<PetReadDto> CreatePet(PetCreateDto petCreateDto)
        {
            var petModel = _mapper.Map<Pet>(petCreateDto);
            _repository.CreatePet(petModel);
            _repository.SaveChanges();

            var PetReadDto = _mapper.Map<PetReadDto>(petModel);

            return CreatedAtRoute(nameof(GetPetById), new { Id = PetReadDto.Id }, PetReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdatePet(int id, PetUpdateDto petUpdateDto)
        {
            var getPetModel = _repository.GetPetById(id);
            if (getPetModel == null)
            {
                return NotFound();
            }

            _mapper.Map(petUpdateDto, getPetModel);
            _repository.UpdatePet(getPetModel);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialPetUpdate(int id, JsonPatchDocument<PetUpdateDto> patchDoc)
        {
            var getPetModel = _repository.GetPetById(id);
            if (getPetModel == null)
            {
                return NotFound();
            }

            var petToPatch = _mapper.Map<PetUpdateDto>(getPetModel);
            patchDoc.ApplyTo(petToPatch, ModelState);

            if (!TryValidateModel(petToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(petToPatch, getPetModel);
            _repository.UpdatePet(getPetModel);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePet(int id)
        {
            var getPetModel = _repository.GetPetById(id);
            if (getPetModel == null)
            {
                return NotFound();
            }
            _repository.DeletePet(getPetModel);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
