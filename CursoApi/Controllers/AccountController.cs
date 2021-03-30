using CursoApi.Dtos.Account;
using CursoApi.Entities;
using CursoApi.Helpers;
using CursoApi.Logic.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IAccountLogic _accountLogic;

        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager, RoleManager<Role> roleManager, IConfiguration configuration, IAccountLogic accountLogic)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _accountLogic = accountLogic;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    LogicResponse response = _accountLogic.Register(registerDto);
                    if (response.Success)
                    {
                        return Ok(response.Message);
                    }
                    else
                    {
                        return BadRequest(response.Message);
                    }
                }
                catch (Exception ex)
                {

                    return BadRequest("Error al registrar la solicitud");
                }
            }

            return BadRequest(ModelState.Values.FirstOrDefault().Errors.FirstOrDefault().ErrorMessage);
        }

    }
}
