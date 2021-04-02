using CursoApi.Dtos.Courses;
using CursoApi.Entities;
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
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseLogic _courseLogic;

        public CoursesController(ICourseLogic courseLogic)
        {
            _courseLogic = courseLogic;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            List<Course> courses = _courseLogic.GetAll();

            return Ok(courses);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CourseDto courseDto) {

            if (ModelState.IsValid)
            {
                LogicResponse response = new LogicResponse();

                response = _courseLogic.Create(courseDto);

                if (response.Success)
                {
                    return Ok(response.Message);
                }
                else
                {
                    return BadRequest(response.Message);
                }
            }

            return BadRequest(ModelState.Values.FirstOrDefault().Errors.FirstOrDefault().ErrorMessage);
            
        }
    }
}
