using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.Security;
using MyProject.Security.Auth;

namespace MyProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        //private readonly IJwtAuthenticationManager jwtAuthenticationManager;

        //public SecurityController(IJwtAuthenticationManager jwtAuthenticationManager)
        //{
        //    this.jwtAuthenticationManager = jwtAuthenticationManager;
        //}
        private readonly ITokenManager _tokenManager;
        public SecurityController(ITokenManager tokenManager)
        {
            this._tokenManager = tokenManager;
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserCredential userCred)
        {
            //var token = jwtAuthenticationManager.Authenticate(userCred.UserName, userCred.Password);
            var token = _tokenManager.GetToken(userCred.UserName, userCred.Password);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }
    }
}
