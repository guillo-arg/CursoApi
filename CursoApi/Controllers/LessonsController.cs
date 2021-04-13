using CursoApi.Dtos.Lessons;
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
    [Route("Courses/{courseId}/Modules/{moduleId}/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class LessonsController : ControllerBase
    {
        private readonly ILessonLogic _lessonLogic;
        public LessonsController(ILessonLogic lessonLogic)
        {
            _lessonLogic = lessonLogic;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int courseId, int moduleId)
        {
            List<LessonDto> lessonDtos = _lessonLogic.GetAllByModule(courseId, moduleId);
            return Ok(lessonDtos);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int courseId, int moduleId, int id)
        {
            LessonDto lessonDto = _lessonLogic.Get(courseId, moduleId, id);
            return Ok(lessonDto);

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LessonDto lessonDto)
        {
            if (ModelState.IsValid)
            {
                LogicResponse response = new LogicResponse();
                response = _lessonLogic.Create(lessonDto);

                if (response.Success)
                {
                    lessonDto.Id = Convert.ToInt32(response.Message);
                    return Created($"/Courses/{lessonDto.CourseId}/Modules/{lessonDto.ModuleId}/Lessons/{lessonDto.Id}", lessonDto);
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
        public async Task<IActionResult> Put([FromBody] LessonDto lessonDto)
        {
            if (ModelState.IsValid)
            {
                LogicResponse response = new LogicResponse();
                response = _lessonLogic.Edit(lessonDto);
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
        public async Task<IActionResult> Delete(int courseId, int moduleId, int id)
        {
            LogicResponse response = new LogicResponse();
            response = _lessonLogic.Delete(courseId, moduleId, id);

            if (response.Success)
            {
                return Ok(response.Message);
            }
            else
            {
                return BadRequest(response.Message);
            }

        }
    }
}
