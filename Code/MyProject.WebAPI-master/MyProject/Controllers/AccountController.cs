using Microsoft.AspNetCore.Mvc;
using MyProject.Contracts;
using MyProject.Entities.DataTransferObjects;
using MyProject.Entities.Models;
using MyProject.Security.Auth;
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
        public override void InitializeController()
        {

        }
        public AccountController(IRepositoryWrapper repositoryWrapper, ITokenManager tokenManager)
        {
            RepositoryWrapper = repositoryWrapper;
            TokenMgr = tokenManager;
        }
        public IRepositoryWrapper RepositoryWrapper { get; }
        public ITokenManager TokenMgr { get; set; }

        [HttpPost("Register")]
        public async Task<JsonResult> Register([FromBody]RegisterDto registerDto)
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
            return await base.FinalizStatusCodeeMessage("User register successfully", 200);
        }

        [HttpPost("Login")]
        public async Task<JsonResult> Login(LoginDto loginDto)
        {
            AppUsers appUsers = RepositoryWrapper.AppUsers.GetUsers(loginDto);
            if (appUsers == null) return await base.FinalizStatusCodeeMessage("Error: Invalid User Name provided.", 500);

            using var hmac = new HMACSHA512(appUsers.PasswordSalt);
            var computHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));
            for (int i = 0; i < computHash.Length; i++)
            {
                if (computHash[i] != appUsers.PasswordHash[i]) return await base.FinalizStatusCodeeMessage("Error: Invalid Password provided.", 500);
            }

            var UserDto = new UserDto
            {
                Id = appUsers.Id,
                FirstName = appUsers.FirstName,
                LastName = appUsers.LastName,
                MobileNo = appUsers.MobileNo,
                Email = appUsers.Email,
                RoleId = appUsers.RoleId,
                Role = ((Roles)appUsers.RoleId).ToString(),
                UserName = appUsers.UserName,
                Token = TokenMgr.GetToken(loginDto.UserName, loginDto.Password, ((Roles)appUsers.RoleId).ToString())
            };
            return await base.FinalizeSingle<UserDto>(UserDto);
        }

        [HttpGet("GetAllUserRolls")]
        public async Task<JsonResult> GetAllUserRolls()
        {
             return await base.FinalizeMultiple<IEnumerable<AppUserRoles>>(await RepositoryWrapper.AppUserRoles.GetAllUserRolls());
        }

        /// <summary>
        /// GetUsersById() - Need the parameter User Id to pass For which Data is needed
        /// </summary>
        /// <param> int Id </param>
        /// <returns>Returns Contact Details, name, email, RoleId of input id from AppUsers Table</returns>
        ///<Aurthor>Sumeet Tanaji Kemse</Aurthor>
        [HttpGet("GetUserDataById")]
        public async Task<JsonResult> GetUsersById(int Id)
        {
            var user = RepositoryWrapper.AppUsers.GetUsersById(Id);
            if (user == null) return await base.FinalizStatusCodeeMessage("Error: User ID Not Found Enter valid Id.", 500);

            var loginUserDto= new LoginUserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MobileNo = user.MobileNo,
                Email = user.Email,
                RoleId = user.RoleId

            };
           return await base.FinalizeSingle<LoginUserDto>(loginUserDto);
        }

    }
}
