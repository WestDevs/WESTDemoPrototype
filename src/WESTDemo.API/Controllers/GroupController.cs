using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WESTDemo.API.Dto.GroupDto;
using WESTDemo.Domain.Interfaces;
using WESTDemo.Domain.Models;

namespace WESTDemo.API.Controllers
{
    public class GroupController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IGroupService _groupService;
        public GroupController(IMapper mapper,
                               IGroupService groupService)
        {
            _groupService = groupService;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var groups = await _groupService.GetAll();

            return Ok(_mapper.Map<IEnumerable<GroupResultDto>>(groups));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var group = await _groupService.GetById(id);
            if (group == null) return NotFound("Group not found");

            return Ok(_mapper.Map<GroupResultDto>(group));
        }

        [HttpPost]
        public async Task<IActionResult> Add(GroupAddDto newGroup)
        {
            if (!ModelState.IsValid) return BadRequest();
            var group = await _groupService.Add(_mapper.Map<Group>(newGroup));
            if (group == null) return BadRequest();

            return Ok(_mapper.Map<GroupResultDto>(group));



        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, GroupEditDto updatedGroup)
        {
            if (id != updatedGroup.Id) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();

            var groupResult = await _groupService.Update(_mapper.Map<Group>(updatedGroup));
            if (groupResult == null) return BadRequest();

            return Ok(_mapper.Map<GroupResultDto>(groupResult));

        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Remove(int id)
        {
            var group = await _groupService.GetById(id);

            if(group == null) return NotFound("Group don't exist");

            if (!await _groupService.Remove(group)) return BadRequest();

            return Ok();
        }

        [HttpGet("search/{groupName}")]
        public async Task<IActionResult> Search(string groupName)
        {
            // implemented a little differently than in UsersController
            var groups = await _groupService.Search(groupName);

            if (groups == null || groups.ToList().Count == 0) return NotFound("No search results");

            return Ok(_mapper.Map<IEnumerable<GroupResultDto>>(groups));
        }

    }
}