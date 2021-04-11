using CursoApi.Entities;
using CursoApi.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoApi.Repositories
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly ApiDbContext _apiDbContext;
        public ModuleRepository(ApiDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext;
        }

        public int Create(Module module)
        {
            _apiDbContext.Modules.Add(module);

            try
            {
                _apiDbContext.SaveChanges();

                return module.Id;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public void Edit(Module module)
        {
            Module moduleDB = _apiDbContext.Modules.Where(x => x.Id == module.Id).First();
            Map(module, moduleDB);

            try
            {
                _apiDbContext.Modules.Update(moduleDB);
                _apiDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }

        private void Map(Module module, Module moduleDB)
        {
            moduleDB.Name = module.Name;
            moduleDB.Position = module.Position;
        }

        public Module Get(int courseId, int id)
        {
            return _apiDbContext.Modules.Include(x => x.Course)
                .Where(x => x.Id == id && x.Course.Id == courseId)
                .FirstOrDefault();
        }

        public List<Module> GetAllByCourse(int courseId)
        {
            return _apiDbContext.Modules.Include(x => x.Course)
                .Where(x => x.Course.Id == courseId)
                .ToList();
        }

        public void Delete(Module module)
        {
            try
            {
                _apiDbContext.Modules.Remove(module);
                _apiDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}
