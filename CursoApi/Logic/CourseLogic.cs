using CursoApi.Entities;
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

        public CourseLogic(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public List<Course> GetAll()
        {
            return _courseRepository.GetAll();
        }
    }
}
