using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyProject.Contracts;
using MyProject.Entities.DataTransferObjects;
using MyProject.Entities.Models;
using MyProject.Security.Auth;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public AccountController(IRepositoryWrapper repositoryWrapper, ITokenManager tokenManager)
        {
            RepositoryWrapper = repositoryWrapper;
            TokenMgr = tokenManager;
        }
        public IRepositoryWrapper RepositoryWrapper { get; }
        public ITokenManager TokenMgr { get; set; }

        [AllowAnonymous]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="registerDto"></param>
        /// <returns></returns>
        [HttpPost("Register")]
        public IActionResult Register([FromBody]RegisterDto registerDto)
        {
            using var hmac = new HMACSHA512();
            var user = new AppUsers
            {
                UserName = registerDto.UserName,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                MobileNo = registerDto.MobileNo,
                Email = registerDto.Email,
                RoleId = registerDto.RoleId
            };
            var result = RepositoryWrapper.AppUsers.Register(user);
            return Ok("User register successfully");       
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginDto"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        public ActionResult<UserDto> Login(LoginDto loginDto)
        {
            AppUsers appUsers = RepositoryWrapper.AppUsers.GetUsers(loginDto);
            if (appUsers == null) return Ok("Error: Invalid User Name provided.");

            using var hmac = new HMACSHA512(appUsers.PasswordSalt);
            var computHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));
            for (int i = 0; i < computHash.Length; i++)
            {
                if (computHash[i] != appUsers.PasswordHash[i]) return Ok("Error: Invalid Password provided.");
            }

            
             var UserDto = new
            {
                Id = appUsers.Id,
                FirstName = appUsers.FirstName,
                LastName = appUsers.LastName,
                MobileNo = appUsers.MobileNo,
                Email = appUsers.Email,
                Role = ((Roles)appUsers.RoleId).ToString(),
                UserName = appUsers.UserName,
                Token = TokenMgr.GetToken(loginDto.UserName, loginDto.Password, ((Roles)appUsers.RoleId).ToString())
            };
            Response.Headers.Add("UserDetails", JsonConvert.SerializeObject(UserDto));
            return Ok(UserDto);
        }

        [HttpGet("GetAllUserRolls")]
        public async Task<IEnumerable<AppUserRoles>> GetAllUserRolls()
        {
            return await RepositoryWrapper.AppUserRoles.GetAllUserRolls();
        }

        /// <summary>
        /// GetUsersById() - Need the parameter User Id to pass For which Data is needed
        /// </summary>
        /// <param> int Id </param>
        /// <returns>Returns Contact Details, name, email, RoleId of input id from AppUsers Table</returns>
        ///<Aurthor>Sumeet Tanaji Kemse</Aurthor>
        [HttpPost("GetUserDataById")]
        public ActionResult<LoginUserDto> GetUsersById(int Id)
        {
            var user = RepositoryWrapper.AppUsers.GetUsersById(Id);
            if (user == null) return Ok("Error: User ID Not Found Enter valid Id.");

            return new LoginUserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MobileNo = user.MobileNo,
                Email = user.Email,
                RoleId = user.RoleId
            };
        }

    }
}
