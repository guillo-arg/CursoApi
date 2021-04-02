using CursoApi.Entities;
using CursoApi.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoApi.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApiDbContext _apiDbContext;

        public CourseRepository(ApiDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext;
        }

        public int Create(Course course)
        {
            _apiDbContext.Courses.Add(course);

            try
            {
                _apiDbContext.SaveChanges();
                
                return course.Id;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }

        public List<Course> GetAll()
        {
            return _apiDbContext.Courses.ToList();
        }
    }
}
