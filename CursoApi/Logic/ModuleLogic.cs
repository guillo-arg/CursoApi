using AutoMapper;
using CursoApi.Dtos.Modules;
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
    public class ModuleLogic : IModuleLogic
    {
        private readonly IModuleRepository _moduleRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public ModuleLogic(IModuleRepository moduleRepository, ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
            _mapper = AutomapperConfiguration.Instance().CreateMapper();
            _moduleRepository = moduleRepository;
        }

        public LogicResponse Create(ModuleDto moduleDto)
        {
            Course course = _courseRepository.GetById(moduleDto.CourseId);
            LogicResponse response = new LogicResponse();
            if (course == null)
            {
                response.Message = $"No se encontró el curso con id {moduleDto.CourseId}";
                response.Success = false;

                return response;
            }

            Module module = _mapper.Map<ModuleDto, Module>(moduleDto);
            module.Course = course;
            try
            {
                int id = _moduleRepository.Create(module);
                response.Message = id.ToString();
                response.Success = true;

                return response;


            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Error al almacenar el módulo";
                return response;
            }

        }

        public LogicResponse Delete(int courseId, int id)
        {
            LogicResponse response = new LogicResponse();
            Module module = _moduleRepository.Get(courseId, id);
            if (module == null)
            {
                response.Success = false;
                response.Message = "No se encontró el módulo";

                return response;
            }
            try
            {
                _moduleRepository.Delete(module);
                response.Success = true;
                response.Message = "Se borró el módulo";

                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "No se pudo borrar el módulo";

                return response;
            }
        }

        public LogicResponse Edit(ModuleDto moduleDto)
        {
            LogicResponse response = new LogicResponse();
            Course course = _courseRepository.GetById(moduleDto.CourseId);
            if (course == null)
            {
                response.Success = false;
                response.Message = "No se encontró el curso del módulo a modificar";

                return response;
            }
            
            Module module = _moduleRepository.Get(moduleDto.CourseId, moduleDto.Id);
            if (module == null)
            {
                response.Success = false;
                response.Message = "No se encontró el módulo";

                return response;
            }

            module = _mapper.Map<ModuleDto, Module>(moduleDto);

            try
            {
                _moduleRepository.Edit(module);
                response.Success = true;
                response.Message = module.Id.ToString();

                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Error al almacenar el módulo";

                return response;
            }

        }

        public ModuleDto Get(int courseId, int id)
        {
            Module module = _moduleRepository.Get(courseId, id);
            ModuleDto moduleDto = _mapper.Map<Module, ModuleDto>(module);

            return moduleDto;
        }

        public List<ModuleDto> GetAllByCourse(int courseId)
        {
            List<Module> modules = _moduleRepository.GetAllByCourse(courseId);
            List<ModuleDto> moduleDtos = _mapper.Map<List<Module>, List<ModuleDto>>(modules);

            return moduleDtos;
        }
    }
}
