﻿using Microsoft.AspNetCore.Mvc;
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
        public AccountController(IRepositoryWrapper repositoryWrapper, ITokenManager tokenManager)
        {
            RepositoryWrapper = repositoryWrapper;
            TokenMgr = tokenManager;
        }
        public IRepositoryWrapper RepositoryWrapper { get; }
        public ITokenManager TokenMgr { get; set; }

        [HttpPost("Register")]
        public ActionResult<UserDto> Register([FromBody]RegisterDto registerDto)
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
            RepositoryWrapper.AppUsers.Register(user);
            return new UserDto
            {
                UserName = user.UserName,
                Token = TokenMgr.GetToken(user.UserName, registerDto.Password)
            };
        }

        [HttpPost("Login")]
        public ActionResult<UserDto> Login(LoginDto loginDto)
        {
            var user = RepositoryWrapper.AppUsers.GetUsers(loginDto);
            if (user == null) return Unauthorized("Invalid User Name provided.");

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));
            for (int i = 0; i < computHash.Length; i++)
            {
               if (computHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid Password provided.");
            }

            return new UserDto
            {
                UserName = loginDto.UserName,
                Token = TokenMgr.GetToken(loginDto.UserName, loginDto.Password)
            };
        }

        [HttpGet("GetAllUserRolls")]
        public async Task<IEnumerable<AppUserRoles>> GetAllUserRolls()
        {
            return await RepositoryWrapper.AppUserRoles.GetAllUserRolls();
        }

        [HttpPost("GetUserDataById")]
        public ActionResult<LoginUserDto> GetUsersById(int Id)
        {
            var user = RepositoryWrapper.AppUsers.GetUsersById(Id);
            if (user == null) return Unauthorized("User ID Not Found.");

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
