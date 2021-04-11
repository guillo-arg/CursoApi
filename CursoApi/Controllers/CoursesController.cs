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

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            CourseDto courseDto = _courseLogic.GetById(id);

            if (courseDto != null)
            {
                return Ok(courseDto);
            }
            else
            {
                return NotFound("No se encontró el curso");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CourseDto courseDto) {

            if (ModelState.IsValid)
            {
                LogicResponse response = new LogicResponse();

                response = _courseLogic.Create(courseDto);

                if (response.Success)
                {
                    courseDto.Id = Convert.ToInt32(response.Message);
                    return Created($"/Courses/{response.Message}", courseDto);
                }
                else
                {
                    return BadRequest(response.Message);
                }
            }

            return BadRequest(ModelState.Values.FirstOrDefault().Errors.FirstOrDefault().ErrorMessage);
            
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] CourseDto courseDto) {

            if (ModelState.IsValid)
            {
                LogicResponse response = new LogicResponse();
                response = _courseLogic.Edit(courseDto);

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

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id) {
            LogicResponse response = new LogicResponse();
            response = _courseLogic.Delete(id);
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
