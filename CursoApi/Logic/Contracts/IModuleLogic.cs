using CursoApi.Dtos.Modules;
using CursoApi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoApi.Logic.Contracts
{
    public interface IModuleLogic
    {
        List<ModuleDto> GetAllByCourse(int courseId);
        ModuleDto Get(int courseId, int id);
        LogicResponse Create(ModuleDto moduleDto);
        LogicResponse Edit(ModuleDto moduleDto);
        LogicResponse Delete(int courseid, int id);
    }
}
