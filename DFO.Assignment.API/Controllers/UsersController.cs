using AutoMapper;
using DFO.Assignment.API.Repositories;
using DFO.Assignment.Domain.Entities;
using DFO.Assignment.Domain.Models.Users;
using Microsoft.AspNetCore.Mvc;


namespace DFO.Assignment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpGet("/{id}")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(404)]
        public IActionResult GetById(int id)
        {
            var user = _userRepository.FindById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_userRepository.GetAll());
        }

        [ProducesResponseType(201, Type = typeof(User))]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        [HttpPost]
        public IActionResult PostUser(UserCreationModel userModel)
        {
            if (_userRepository.IsUserExisted(userModel.Name))
            {
                return Conflict();
            }

            var user = _mapper.Map<UserCreationModel, User>(userModel);

            var newUserId = _userRepository.Insert(user);

            if (newUserId <= 0)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetById), new { id = newUserId }, user);
        }

        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        [HttpPut]
        public IActionResult PutUser(UserModel userModel)
        {
            if (_userRepository.IsUserExisted(userModel.Name))
            {
                return Conflict();
            }

            var user = _mapper.Map<User>(userModel);

            if (!_userRepository.Update(user))
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}