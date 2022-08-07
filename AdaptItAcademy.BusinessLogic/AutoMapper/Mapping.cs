using System;
using System.Collections.Generic;
using System.Text;
using AdaptItAcademy.Service.Entitty.Dto;
using AdaptItAcademy.Service.Entitty.model;
using AdaptItAcademy.Service.Entitty.Service;
using AutoMapper;

namespace AdaptItAcademy.BusinessLogic.AutoMapper
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<Course, CourseDto>();
            CreateMap<CourseDto, Course>();
        }

        public MapperConfiguration CourseAutoMap()
        {
          var  config = new MapperConfiguration(c => {
                c.CreateMap<Course, CourseDto>();
                c.CreateMap<CourseDto, Course>();
            });

            return config;
        }

        public MapperConfiguration TrainingAutoMapper()
        {
            var config = new MapperConfiguration( c =>
            {
                c.CreateMap<TrainingDto, Training>();
                c.CreateMap<Training, TrainingDto>().ForMember(dest => dest.AvalableSeats, options => options.MapFrom(option => option.Seats - option.RegistrationCount));
            });

            return config;
        }

        public MapperConfiguration CandidateAutoMapper()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Candidate, CandidateDto>();
                c.CreateMap<CandidateDto, Candidate>();
            });

            return config;
        }
    }
}
