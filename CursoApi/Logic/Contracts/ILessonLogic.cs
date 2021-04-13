using CursoApi.Dtos.Lessons;
using CursoApi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoApi.Logic.Contracts
{
    public interface ILessonLogic
    {
        List<LessonDto> GetAllByModule(int courseId, int moduleId);
        LessonDto Get(int courseId, int moduleId, int id);
        LogicResponse Create(LessonDto lessonDto);
        LogicResponse Edit(LessonDto lessonDto);
        LogicResponse Delete(int courseId, int moduleId, int id);
    }
}
