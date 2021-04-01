using CursoApi.Dtos.Account;
using CursoApi.Entities;
using CursoApi.Helpers;
using CursoApi.Logic.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CursoApi.Logic
{
    public class AccountLogic : IAccountLogic
    {
        private readonly ApiDbContext _apiDbContext;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IConfiguration _configuration;

        public AccountLogic(ApiDbContext apiDbContext, UserManager<User> userManager, RoleManager<Role> roleManager, IConfiguration configuration)
        {
            _apiDbContext = apiDbContext;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task<LogicResponse> Login(LoginDto loginDto)
        {
            LogicResponse response = new LogicResponse();

            if (_userManager.Users.All(x => x.UserName != loginDto.Username))
            {
                response.Success = false;
                response.Message = "No se encontró el usuario";

                return response;
            }

            if (_userManager.Users.Any(x => x.UserName.ToUpper() == loginDto.Username.ToUpper() && !x.Enabled))
            {
                response.Success = false;
                response.Message = "Usuario inactivo";

                return response;
            }


            User user = await _userManager.FindByNameAsync(loginDto.Username);
            var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            if (result)
            {
                //generar token
                string token = GenerateJSONWebToken(user);

                response.Success = true;
                response.Message = token;

                return response;
            }
            else
            {
                response.Success = false;
                response.Message = "Credenciales incorrectas";

                return response;
            }

        }

        private string GenerateJSONWebToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("secretKey")));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>{
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("id", user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
            
        }

        public LogicResponse Register(RegisterDto registerDto)
        {
            LogicResponse response = new LogicResponse();
            User user = new User()
            {
                UserName = registerDto.Username,
                Email = registerDto.Email,
                Id = Guid.NewGuid().ToString()
            };

            IdentityResult registerResult = _userManager.CreateAsync(user, registerDto.Password).Result;

            if (registerResult.Succeeded)
            {
                response.Success = true;
                response.Message = user.Id;
            }
            else
            {
                response.Success = false;
                response.Message = "No se pudo registrar el usuario";
            }

            return response;
        }
    }
}
