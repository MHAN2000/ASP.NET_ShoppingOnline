using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShoppingOnline.Data.Repositories;
using ShoppingOnline.Models;
using ShoppingOnline.Models.DTO;

namespace ShoppingOnline.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> GetAll()
        {
            var users = await _userRepository.GetAll();
            return Ok(_mapper.Map<List<UserDTO>>(users));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user == null) return NotFound("The user has not been found");
            return Ok(_mapper.Map<UserDTO>(user));
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO?>> AddUser(UserDTO request)
        {
            var user = await _userRepository.AddUser(request);
            if (user == null) return StatusCode(500, "An error has ocurred while creating the User");
            return Ok(_mapper.Map<UserDTO>(user));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDTO?>> DeleteUser(int id)
        {
            var user = await _userRepository.DeleteUser(id);
            if (user == null) return NotFound("The user has not been found");
            return Ok(_mapper.Map<UserDTO>(user));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser([FromBody] UserDTO request, int id)
        {
            var user = await _userRepository.UpdateUser(request, id);
            if (user == null) return NotFound("The user has not been found");
            return Ok(user);
        }
    }
}
