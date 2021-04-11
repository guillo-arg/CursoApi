using CursoApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoApi.Repositories.Contracts
{
    public interface IModuleRepository
    {
        List<Module> GetAllByCourse(int courseId);
        Module Get(int courseId, int id);
        int Create(Module module);
        void Edit(Module module);
        void Delete(Module module);
    }
}
