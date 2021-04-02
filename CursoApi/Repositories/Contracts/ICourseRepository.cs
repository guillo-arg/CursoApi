using CursoApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoApi.Repositories.Contracts
{
    public interface ICourseRepository
    {
        List<Course> GetAll();
        int Create(Course course);
        Course GetById(int id);
        void Edit(Course course);
        void Delete(Course course);
    }
}
