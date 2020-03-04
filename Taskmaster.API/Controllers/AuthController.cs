using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Taskmaster.API.DataContract.Auth;
using Taskmaster.Business.DataContract.Auth.DTOs;
using Taskmaster.Business.DataContract.Auth.Interfaces;
using Taskmaster.Data.Entities;

namespace Taskmaster.API.Controllers
{
    public class AuthController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly IAuthManager _authManager;
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly UserManager<UserEntity> _userManager;

        public AuthController(IConfiguration config, IMapper mapper, IAuthManager authManager,
            UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager)
        {
            _config = config;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _authManager = authManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequest userForRegister)
        {
            var userDTO = _mapper.Map<RegisterUserDTO>(userForRegister);

            var returnedUser = await _authManager.RegisterUser(userDTO);

            var appUser = await _userManager.Users.FirstOrDefaultAsync(u => u.NormalizedUserName == userDTO.UserName.ToUpper());

            var userResponse = _mapper.Map<ReceivedExistingUserResponse>(appUser);

            if (userResponse != null)
            {
                return Ok(new
                {
                    token = GenerateTokenString(appUser).Result,
                    user = userResponse
                });
            }

            return BadRequest("Bad Request");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserRequest loginUserRequest)
        {
            var userDTO = _mapper.Map<QueryForExistingUserDTO>(loginUserRequest);

            var returnedUser = await _authManager.LoginUser(userDTO);

            var appUser = await _userManager.Users.FirstOrDefaultAsync(u => u.NormalizedUserName == userDTO.UserName.ToUpper());

            var userResponse = _mapper.Map<ReceivedExistingUserResponse>(appUser);

            if(userResponse != null)
            {
                return Ok(new
                {
                    token = GenerateTokenString(appUser).Result,
                    user = userResponse
                });
            }

            return Unauthorized();
        }

        private async Task<string> GenerateTokenString(UserEntity userEntity)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userEntity.Id.ToString()),
                new Claim(ClaimTypes.Name, userEntity.UserName)
            };

            var roles = await _userManager.GetRolesAsync(userEntity);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}