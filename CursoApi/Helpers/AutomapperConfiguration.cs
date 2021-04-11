using AutoMapper;
using CursoApi.Dtos.Courses;
using CursoApi.Dtos.Modules;
using CursoApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoApi.Helpers
{
    public class AutomapperConfiguration
    {
        private static MapperConfiguration instance;

        private AutomapperConfiguration()
        {

        }

        public static MapperConfiguration Instance() 
        {
            if (instance == null)
            {
                instance = new MapperConfiguration(conf => { 
                    conf.CreateMap<Course, CourseDto>().ReverseMap();
                    conf.CreateMap<Module, ModuleDto>().ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.Course.Id)).ReverseMap();
                }); 
            }

            return instance;
        }


    }
}
