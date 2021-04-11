using CursoApi.Dtos.Modules;
using CursoApi.Helpers;
using CursoApi.Logic.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoApi.Controllers
{
    [ApiController]
    [Route("Courses/{courseId}/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class    ModulesController : ControllerBase
    {
        private readonly IModuleLogic _moduleLogic;

        public ModulesController(IModuleLogic moduleLogic)
        {
            _moduleLogic = moduleLogic;
        }

        [HttpGet]
    //    [Route("Courses/{courseId}/[controller]")]
        public async Task<IActionResult> GetAllByCourse(int courseId)
        {
            List<ModuleDto> moduleDtos = _moduleLogic.GetAllByCourse(courseId);

            return Ok(moduleDtos);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int courseId, int id) 
        {
            ModuleDto moduleDto = _moduleLogic.Get(courseId, id);
            if (moduleDto != null)
            {
                return Ok(moduleDto);
            }
            else
            {
                return BadRequest("El módulo no fue encontrado");
            }
        }

        [HttpPost]
        //[Route("[controller]")]
        public async Task<IActionResult> Create([FromBody] ModuleDto moduleDto)
        {
            if (ModelState.IsValid)
            {
                LogicResponse response = _moduleLogic.Create(moduleDto);
                if (response.Success)
                {
                    moduleDto.Id = Convert.ToInt32(response.Message);
                    return Created($"/Courses/{moduleDto.CourseId}/Modules/{response.Message}", moduleDto);

                }
                else
                {
                    return BadRequest(response.Message);
                }
            }
            else
            {
                return BadRequest(ModelState.Values.FirstOrDefault().Errors.FirstOrDefault().ErrorMessage);
            }
        }

        [HttpPut]
        //[Route("[controller]")]
        public async Task<IActionResult> Put([FromBody] ModuleDto moduleDto)
        {
            if (ModelState.IsValid)
            {
                LogicResponse response = new LogicResponse();
                response = _moduleLogic.Edit(moduleDto);

                if (response.Success)
                {
                    return Ok(response.Message);
                }
                else
                {
                    return BadRequest(response.Message);
                }
            }
            else
            {
                return BadRequest(ModelState.Values.FirstOrDefault().Errors.FirstOrDefault().ErrorMessage);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int courseId, int id)
        {
            LogicResponse response = new LogicResponse();
            response = _moduleLogic.Delete(courseId, id);
            if (response.Success)
            {
                return Ok(id);
            }
            else
            {
                return BadRequest(response.Message);
            }

        }
    }
}
