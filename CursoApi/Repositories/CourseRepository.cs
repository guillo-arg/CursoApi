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

        public void Edit(Course course)
        {
            Course courseDb = GetById(course.Id);
            Map(courseDb, course);

            try
            {
                _apiDbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(); ;
            }
        }

        private void Map(Course courseDb, Course course)
        {
            courseDb.Description = course.Description;
            courseDb.Name = course.Name;
            course.Price = course.Price;
        }

        public List<Course> GetAll()
        {
            return _apiDbContext.Courses.ToList();
        }

        public Course GetById(int id)
        {
            return _apiDbContext.Courses.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Delete(Course course)
        {
            try
            {
                _apiDbContext.Courses.Remove(course);
                _apiDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(); ;
            }
        }
    }
}
