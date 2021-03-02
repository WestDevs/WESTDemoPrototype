using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WESTDemo.API.Dto.LearnerDto;
using WESTDemo.API.Dto.LearnerStatusDto;
using WESTDemo.API.Dto.UserTypeDto;
using WESTDemo.Domain.Interfaces;
using WESTDemo.Domain.Models;

namespace WESTDemo.API.Controllers
{
    public class LearnerController : MainController
    {
        private readonly IMapper _mapper;
        private readonly ILearnerService _learnerService;
        public LearnerController(IMapper mapper, ILearnerService learnerService)
        {
            _learnerService = learnerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var learners = await _learnerService.GetAll();

            return Ok(_mapper.Map<IEnumerable<LearnerResultDto>>(learners));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var learner = await _learnerService.GetById(id);
            if (learner == null) return NotFound("Learner not found");

            return Ok(_mapper.Map<LearnerResultDto>(learner));
        }
        
        [HttpPost]
        public async Task<IActionResult> Add(LearnerAddDto newLearner)
        {
            if(!ModelState.IsValid) return BadRequest("Invalid Learner details");

            var learnerResult = await _learnerService.Add(_mapper.Map<Learner>(newLearner));

            if (learnerResult == null) return BadRequest("Learner not added successfully");

            return Ok(_mapper.Map<LearnerResultDto>(learnerResult));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, LearnerEditDto updatedLearner)
        {   
            if (id != updatedLearner.Id) return BadRequest();

            var learner = await _learnerService.GetById(id);
            if (learner == null) return NotFound("Learner not found");

            var learnerResult = await _learnerService.Update(_mapper.Map<Learner>(updatedLearner));

            if(learnerResult == null) return BadRequest("Learner not updated");

            return Ok(_mapper.Map<LearnerResultDto>(learnerResult));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Remove(int id)
        {
            var learner = await _learnerService.GetById(id);
            if (learner == null) return NotFound("Learner not found");

            if (!await _learnerService.Remove(learner)) return BadRequest("Failed to delete learner");

            return Ok();
        }

        [HttpGet("search/{searchValue}")]
        public async Task<IActionResult> Search(string searchValue)
        {
            var learners = _mapper.Map<List<Learner>>(await _learnerService.SearchLearners(searchValue));

            if (learners == null || learners.Count == 0) return NotFound("No learner found");

            return Ok(_mapper.Map<IEnumerable<LearnerResultDto>>(learners));
        }

        [HttpGet("org/{organisationId}")]
        public async Task<IActionResult> GetLearnersByOrganisation(int organisationId)
        {
            var learners = await _learnerService.GetLearnersByOrganisation(organisationId);

            if (learners == null || learners.ToList().Count == 0) return NotFound("No learner found");

            return Ok(_mapper.Map<IEnumerable<LearnerResultDto>>(learners));
        }
        
        [HttpGet("group/{groupId}")]
        public async Task<IActionResult> GetLearnersByGroup(int groupId)
        {
            var learners = await _learnerService.GetLearnersByGroup(groupId);

            if (learners == null || learners.ToList().Count == 0) return NotFound("No learner found");

            return Ok(_mapper.Map<IEnumerable<LearnerResultDto>>(learners));
        }

        [HttpPost("update-status/{id:int}")]
        public async Task<IActionResult> UpdateLearnerStatus(int id, LearnerStatusAddDto learnerStatus)
        {
            if (id != learnerStatus.LearnerId) return BadRequest();

            if(!ModelState.IsValid) return BadRequest("Invalid Learner details");
            
            var learner = await _learnerService.GetById(id);
            if (learner == null) return NotFound("Learner not found");

            var newLearnerStatus = _mapper.Map<LearnerStatus>(learnerStatus);
            var learnerStatusResult = await _learnerService.UpdateLearnerStatus(newLearnerStatus);

            if (learnerStatusResult == null) return BadRequest("Update unsuccessful");

            return Ok(_mapper.Map<IEnumerable<LearnerResultDto>>(learnerStatusResult));
        }
    }
}