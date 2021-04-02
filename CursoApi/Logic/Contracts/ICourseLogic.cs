using CursoApi.Dtos.Courses;
using CursoApi.Entities;
using CursoApi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoApi.Logic.Contracts
{
    public interface ICourseLogic
    {
        List<Course> GetAll();
        LogicResponse Create(CourseDto courseDto);
        LogicResponse Edit(CourseDto courseDto);
    }
}
