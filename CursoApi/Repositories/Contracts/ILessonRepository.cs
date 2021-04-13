using CursoApi.Dtos.Lessons;
using CursoApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoApi.Repositories.Contracts
{
    public interface ILessonRepository
    {
        List<Lesson> GetAllByModule(int courseId, int moduleId);
        Lesson Get(int courseId, int moduleId, int id);
        int Create(Lesson lesson);
        void Edit(Lesson lesson);
        void Delete(Lesson lesson);
    }
}
