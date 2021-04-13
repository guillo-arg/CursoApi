using AutoMapper;
using CursoApi.Dtos.Lessons;
using CursoApi.Entities;
using CursoApi.Helpers;
using CursoApi.Logic.Contracts;
using CursoApi.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoApi.Logic
{
    public class LessonLogic : ILessonLogic
    {
        private readonly ILessonRepository _lessonRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IModuleRepository _moduleRepository;
        private readonly IMapper _mapper;

        public LessonLogic(ILessonRepository lessonRepository, ICourseRepository courseRepository, IModuleRepository moduleRepository)
        {
            _mapper = AutomapperConfiguration.Instance().CreateMapper();
            _lessonRepository = lessonRepository;
            _courseRepository = courseRepository;
            _moduleRepository = moduleRepository;
        }

        public LogicResponse Create(LessonDto lessonDto)
        {
            LogicResponse response = new LogicResponse();
            Course course = _courseRepository.GetById(lessonDto.CourseId);
            Module module = _moduleRepository.Get(lessonDto.CourseId, lessonDto.ModuleId);
            if (course == null)
            {
                response.Success = false;
                response.Message = "No se encontró el curso";
                return response;
            }
            if (module == null)
            {
                response.Success = false;
                response.Message = "No se encontró el módulo";
                return response;
            }

            Lesson lesson = _mapper.Map<LessonDto, Lesson>(lessonDto);
            lesson.Module = module;

            try
            {
                int id = _lessonRepository.Create(lesson);
                response.Success = true;
                response.Message = id.ToString();
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Error al almacenar la clase";
                return response;
            }
        }

        public LogicResponse Delete(int courseId, int moduleId, int id)
        {
            LogicResponse response = new LogicResponse();
            Lesson lesson = _lessonRepository.Get(courseId, moduleId, id);
            if (lesson == null)
            {
                response.Success = false;
                response.Message = "No se encontró la clase que desea eliminar";
                return response;
            }

            try
            {
                _lessonRepository.Delete(lesson);
                response.Success = true;
                response.Message = "Se borró la clase";
                return response;

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Error al eliminar la clase";
                return response;
            }
        }

        public LogicResponse Edit(LessonDto lessonDto)
        {
            LogicResponse response = new LogicResponse();
            Course course = _courseRepository.GetById(lessonDto.CourseId);
            Module module = _moduleRepository.Get(lessonDto.CourseId, lessonDto.ModuleId);
            if (course == null)
            {
                response.Success = false;
                response.Message = "No se encontró el curso";
                return response;
            }
            if (module == null)
            {
                response.Success = false;
                response.Message = "No se encontró el módulo";
                return response;
            }
            Lesson lesson = _mapper.Map<LessonDto, Lesson>(lessonDto);
            try
            {
                _lessonRepository.Edit(lesson);
                response.Success = true;
                response.Message = lesson.Id.ToString();
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Error al almacenar la clase";
                return response;
            }
        }

        public LessonDto Get(int courseId, int moduleId, int id)
        {
            Lesson lesson = _lessonRepository.Get(courseId, moduleId, id);
            LessonDto lessonDto = _mapper.Map<Lesson, LessonDto>(lesson);
            return lessonDto;
        }

        public List<LessonDto> GetAllByModule(int courseId, int moduleId)
        {
            List<Lesson> lessons = _lessonRepository.GetAllByModule(courseId, moduleId);
            List<LessonDto> lessonDtos = _mapper.Map<List<Lesson>, List<LessonDto>>(lessons);

            return lessonDtos;

        }
    }
}
