using API.Data;
using API.DTOs;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Interface;
namespace API.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class AccountController : BasicApiController
    {
        private readonly DataContext _ent;
        private readonly ITokenService _tokenService;

        public AccountController(DataContext ent, ITokenService tokenService)
        {
            _ent = ent;
            _tokenService = tokenService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDto _register)
        {
            if (await UserExists(_register.UserName))
            {
                return BadRequest("Username is token");
            }
            using var hmac = new HMACSHA512();
            var user = new AppUser
            {
                UserName = _register.UserName,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(_register.Password)),
                PasswordSalt = hmac.Key
            };
            _ent.AppUser.Add(user);
            await _ent.SaveChangesAsync();
            return new UserDTO
            {
                UserName = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>>Login(LoginDto _login)
        {
            var user = await _ent.AppUser.SingleOrDefaultAsync(o => o.UserName == _login.username);
            if (user == null)
            {
                return Unauthorized("Invalid Username");
            }
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var comoutedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(_login.password));
            for (int i = 0; i < comoutedHash.Length; i++)
            {
                if (comoutedHash[i] != user.PasswordHash[i])
                {
                    return Unauthorized("Invalid Password");
                }
            }
            return new UserDTO
            {
                UserName = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }

        private async Task<bool> UserExists(string _username)
        {
            return await _ent.AppUser.AnyAsync(o => o.UserName.ToLower() == _username.ToLower());
        }
    }
}
