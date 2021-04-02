using AutoMapper;
using CursoApi.Dtos.Courses;
using CursoApi.Entities;
using CursoApi.Helpers;
using CursoApi.Logic.Contracts;
using CursoApi.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoApi.Logic
{
    public class CourseLogic : ICourseLogic
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CourseLogic(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
            _mapper = AutomapperConfiguration.Instance().CreateMapper();
        }

        public LogicResponse Create(CourseDto courseDto)
        {
            LogicResponse response = new LogicResponse();
            Course course = _mapper.Map<CourseDto, Course>(courseDto);

            try
            {
                int id = _courseRepository.Create(course);
                response.Message = id.ToString(); ;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"No se pudo almancenar en la base de datos el curso {course.Name}";
            }

            return response;
        }

        public List<Course> GetAll()
        {
            return _courseRepository.GetAll();
        }
    }
}
