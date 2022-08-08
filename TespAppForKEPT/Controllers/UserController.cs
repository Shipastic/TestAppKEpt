using Domain.Logic.MappingDTO;
using Domain.Logic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace TespAppForKEPT.Controllers
{
    public class UserController : BaseController
    {
        private readonly IService<UserDTO> _serviceUserDTO;
        public UserController(IService<UserDTO> service)
        {
            _serviceUserDTO = service;
        }

        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> Users()
        {
            var users = await _serviceUserDTO.GetAllAsync();
            if(users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }

        [HttpGet]
        [Route("GetUser")]
        public async Task<IActionResult> User([FromQuery] string userName)
        {
            var user = await _serviceUserDTO.GetByNameAsync(userName);
            if(user == null)
            {
                UserNull userNull = new UserNull();
                return Ok(userNull);
            }
            return Ok(user);
        }

        [HttpPost]
        [Route("CreateUser")]
        public void Create([FromQuery] string companyName, CancellationToken cancellationToken, string userName)
        {
            _serviceUserDTO.CreateAsync(companyName, cancellationToken, userName);
        }

        [HttpPut]
        [Route("UpdateUser")]
        public void Update([FromQuery] string userName, string newUserName, CancellationToken cancellationToken)
        {
            _serviceUserDTO.UpdateAsync(userName, newUserName, cancellationToken);
        }
    }
}
