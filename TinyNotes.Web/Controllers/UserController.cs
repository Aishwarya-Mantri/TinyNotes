using System;
using Microsoft.AspNetCore.Mvc;
using TinyNotes.Common;
using TinyNotes.Domain;

namespace TinyNotes.Controllers
{
    [Route("api/v1.0/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [Route("register")]
        [HttpPost]
        public string RegisterUser([FromBody] UserRequest request)
        {
            var userService = new UserService();
            return userService.RegisterUser(request);
        }

        [Route("login")]
        [HttpPost]
        public User Login([FromBody] UserRequest request)
        {
            var userService = new UserService();
            return userService.LoginUser(request);
        }

        [Route("logout/{userid}")]
        [HttpGet]
        public string Logout(Guid userid)
        {
            var userService = new UserService();
            return userService.Logout(userid);
        }
    }
}
