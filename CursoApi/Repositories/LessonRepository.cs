using CursoApi.Dtos.Lessons;
using CursoApi.Entities;
using CursoApi.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoApi.Repositories
{
    public class LessonRepository : ILessonRepository
    {
        private readonly ApiDbContext _apiDbContext;
        public LessonRepository(ApiDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext;
        }

        public int Create(Lesson lesson)
        {
            try
            {
                _apiDbContext.Lessons.Add(lesson);
                _apiDbContext.SaveChanges();
                return lesson.Id;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public void Edit(Lesson lesson)
        {
            Lesson lessonDb = _apiDbContext.Lessons.Where(x => x.Id == lesson.Id).First();
            Map(lesson, lessonDb);
            try
            {
                _apiDbContext.Lessons.Update(lessonDb);
                _apiDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        private void Map(Lesson lesson, Lesson lessonDb)
        {
            lessonDb.Name = lesson.Name;
            lessonDb.Position = lesson.Position;
        }

        public Lesson Get(int courseId, int moduleId, int id)
        {
            return _apiDbContext.Lessons
                    .Include(x => x.Module)
                    .ThenInclude(x => x.Course)
                    .Where(x => x.Id == id && x.Module.Id == moduleId && x.Module.Course.Id == courseId)
                    .FirstOrDefault();
        }

        public List<Lesson> GetAllByModule(int courseId, int moduleId)
        {
            return _apiDbContext.Lessons
                    .Include(x => x.Module)
                    .ThenInclude(x => x.Course)
                    .Where(x => x.Module.Id == moduleId && x.Module.Course.Id == courseId)
                    .ToList();
        }

        public void Delete(Lesson lesson)
        {
            try
            {
                _apiDbContext.Lessons.Remove(lesson);
                _apiDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(); ;
            }
        }
    }
}
