using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WESTDemo.API.Dto.UserDto;
using WESTDemo.Domain.Interfaces;
using WESTDemo.Domain.Models;

namespace WESTDemo.API.Controllers
{
    public class UsersController : MainController
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IMapper mapper,
                                IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAll();

            return Ok(_mapper.Map<IEnumerable<UserResultDto>>(users));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetById(id);

            if (user == null) return NotFound();

            return Ok(_mapper.Map<UserResultDto>(user));
        }

        [Route("org/{id:int}")]
        [HttpGet]
        public async Task<IActionResult> GetByOrganisationId(int id)
        {
            var user = await _userService.GetById(id);

            if (user == null) return NotFound();

            return Ok(_mapper.Map<UserResultDto>(user));
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserAddDto userDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var user = _mapper.Map<User>(userDto);
            var userResult = await _userService.Add(user);

            if (userResult == null) return BadRequest();

            return Ok(_mapper.Map<UserResultDto>(userResult));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, UserEditDto userDto)
        {
            if (id != userDto.Id) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            await _userService.Update(_mapper.Map<User>(userDto));

            return Ok(userDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Remove(int id)
        {
            var user = await _userService.GetById(id);
            if (user == null) return NotFound();

            await _userService.Remove(user);

            return Ok();
        }

        [Route("search/{userName}")]
        [HttpGet]
        public async Task<ActionResult<List<User>>> Search(string userName)
        {
            var users = _mapper.Map<List<User>>(await _userService.Search(userName));

            if (users == null || users.Count == 0) return NotFound("No user were found");

            return Ok(users);
        }

        [Route("search-users/{searchedValue}")]
        [HttpGet]
        public async Task<ActionResult<List<User>>> SearchUsers(string searchedValue)
        {
            var users = _mapper.Map<List<User>>(await _userService.SearchUsers(searchedValue));

            if (!users.Any()) return NotFound("None user were found");

            return Ok(_mapper.Map<IEnumerable<UserResultDto>>(users));
        }

    }
}
