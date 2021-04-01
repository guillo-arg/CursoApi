using CursoApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoApi.Logic.Contracts
{
    public interface ICourseLogic
    {
        List<Course> GetAll();
    }
}
