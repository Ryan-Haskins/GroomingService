using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using GroomingService.Models;
using System.Collections.Generic;
using GroomingService.Data;
using GroomingService.Dtos;

namespace GroomingService.Controllers
{
    //api/cases can just put hard name in instead of [controller]
    [Route("api/cases")]
    [ApiController]
    public class CasesController : ControllerBase
    {
        private readonly ICaseRepo _repository;
        private readonly IMapper _mapper;
        public CasesController(ICaseRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult <IEnumerable<CaseReadDto>> GetAllCases()
        {
            var cases = _repository.GetAllCases();

            return Ok(_mapper.Map<IEnumerable<CaseReadDto>>(cases));
        }

        [HttpGet("{id}", Name="GetCaseById")]
        public ActionResult <CaseReadDto> GetCaseById(int id)
        {
            var caseItem = _repository.GetCaseById(id);
            if(caseItem != null)
            {
                return Ok(_mapper.Map<CaseReadDto>(caseItem));
            }
            
            return NotFound();
        }

        [HttpPost]
        public ActionResult <CaseReadDto> CreateCase(CaseCreateDto caseCreateDto)
        {
            //mapping the case data coming in to the case model using auto mapper.
            var caseModel = _mapper.Map<Case>(caseCreateDto);
            _repository.CreateCase(caseModel);
            _repository.SaveChanges();

            var CaseReadDto = _mapper.Map<CaseReadDto>(caseModel);
            
            //creates 201 created route  grab url for header, grab ID to know what id needs to be addded to url then add the data.
            return CreatedAtRoute(nameof(GetCaseById), new {Id = CaseReadDto.Id}, CaseReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCase(int id, CaseUpdateDto caseUpdateDto)
        {
            var getCaseModel = _repository.GetCaseById(id);
            if (getCaseModel == null)
            {
                return NotFound();
            }
            
            _mapper.Map(caseUpdateDto, getCaseModel);
            _repository.UpdateCase(getCaseModel);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialCaseUpdate(int id, JsonPatchDocument<CaseUpdateDto> patchDoc)
        {
            var getCaseModel = _repository.GetCaseById(id);
            if (getCaseModel == null)
            {
                return NotFound();
            }

            var caseToPatch = _mapper.Map<CaseUpdateDto>(getCaseModel);
            patchDoc.ApplyTo(caseToPatch, ModelState);

            //Validation check
            if(!TryValidateModel(caseToPatch))
            {
                return ValidationProblem(ModelState);
            }

            //Update Model data from repo
            _mapper.Map(caseToPatch, getCaseModel);
            _repository.UpdateCase(getCaseModel);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCase(int id)
        {
            var getCaseModel = _repository.GetCaseById(id);
            if (getCaseModel == null)
            {
                return NotFound();
            }
            _repository.DeleteCase(getCaseModel);
            _repository.SaveChanges();
            
            return NoContent();
        }
    }
}