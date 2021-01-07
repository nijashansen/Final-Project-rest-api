using FinalProject.Core.DomainService;
using FinalProjectAPI.Helpers;
using FinalProjectAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectAPI.Controllers
{
    [Route("/token")]
    public class TokenController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private IAuthenticationHelper _authenticationHelper;

        public TokenController(IUserRepository userRepository, IAuthenticationHelper authHelper)
        {
            _userRepository = userRepository;
            _authenticationHelper = authHelper;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginInputModel model)
        {
            var user = _userRepository.GetAllUsers().FirstOrDefault(u => u.Username == model.Username);
            if (user == null)
            {
                return Unauthorized("user was not found.");
            }
            if (!_authenticationHelper.VerifyPasswordHash(model.Password, user.PasswordHash, user.PasswordSalt))
            {
                return Unauthorized("it is not the right password");
            }
            return Ok(new
            {
                username = user.Username,
                token = _authenticationHelper.GenerateToken(user)
            });
        }
    }
}
