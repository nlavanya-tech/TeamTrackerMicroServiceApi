using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsersMicroservice.BusinessLayer.Interface;
using UsersMicroservice.Entities;

namespace UsersMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;

        }
        // GET: api/User
        [HttpGet]
        public async Task<IEnumerable<Users>> GetAllUsers()
        {
            var user = await _service.UserReadAsync();
            return user;
        }

        // POST: api/User
        [HttpPost]
        public void AddNewUser([FromBody] Users users)
        {
            _service.UserCreateAsync(users);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void UpdateUser(string email, [FromBody] Users user)
        {
            _service.UserUpdateAsync(user);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void DeleteUser(string email)
        {
            _service.UserDeleteAsync(email);
        }
    }
}