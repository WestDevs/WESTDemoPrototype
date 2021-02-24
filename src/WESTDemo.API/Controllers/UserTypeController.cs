using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WESTDemo.API.Controllers;
using WESTDemo.API.Dto.UserTypeDto;
using WESTDemo.Domain.Interfaces;
using WESTDemo.Domain.Models;

namespace src.WESTDemo.API.Controllers
{
    public class UserTypeController : MainController
    {
        private readonly IUserTypeService _userTypeService;
        private readonly IMapper _mapper;
        public UserTypeController(IMapper mapper, IUserTypeService userTypeService)
        {
            _mapper = mapper;
            _userTypeService = userTypeService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userTypes = await _userTypeService.GetAll();
            return Ok(_mapper.Map<IEnumerable<UserTypeResultDto>>(userTypes));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var userType = await _userTypeService.GetById(id);

            if (userType == null) return NotFound();

            return Ok(_mapper.Map<UserTypeResultDto>(userType));

        }

        [HttpPost]
        public async Task<IActionResult> Add(UserTypeAddDto newUserType)
        {
            if (!ModelState.IsValid) return BadRequest();
            
            var userType = _mapper.Map<UserType>(newUserType);
            var userTypeResult = await _userTypeService.Add(userType);

            if (userTypeResult == null) return BadRequest();

            return Ok(_mapper.Map<UserTypeResultDto>(userTypeResult));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, UserTypeEditDto updatedUserType)
        {
            if (id != updatedUserType.Id) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();

            var userTypeResult = await _userTypeService.Update(_mapper.Map<UserType>(updatedUserType));
            if (userTypeResult == null) return BadRequest();

            return Ok(_mapper.Map<UserTypeResultDto>(userTypeResult));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Remove(int id)
        {
            var userType = await _userTypeService.GetById(id);

            if (userType == null) return NotFound();
            
            if (!await _userTypeService.Remove(userType))
                return BadRequest();
                
            return Ok();
        }

        [HttpGet("search/{typeName}")]
        public async Task<IActionResult> Search(string typeName)
        {
            var userTypes = _mapper.Map<List<UserType>>(await _userTypeService.Search(typeName));

            if (userTypes == null || userTypes.Count == 0) return NotFound("No user type found");

            return Ok(_mapper.Map<IEnumerable<UserTypeResultDto>>(userTypes));

        } 


    }
}