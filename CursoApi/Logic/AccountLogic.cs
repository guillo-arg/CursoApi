using CursoApi.Dtos.Account;
using CursoApi.Entities;
using CursoApi.Helpers;
using CursoApi.Logic.Contracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoApi.Logic
{
    public class AccountLogic : IAccountLogic
    {
        private readonly ApiDbContext _apiDbContext;
        private UserManager<User> _userManager;
        private RoleManager<Role> _roleManager;

        public AccountLogic(ApiDbContext apiDbContext, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _apiDbContext = apiDbContext;
            _userManager = userManager;
            _roleManager = roleManager;
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
