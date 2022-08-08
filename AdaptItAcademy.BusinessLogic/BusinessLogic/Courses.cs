using AdaptItAcademy.BusinessLogic.AutoMapper;
using AdaptItAcademy.BusinessLogic.Data;
using AdaptItAcademy.DataAccess;
using AdaptItAcademy.Service.Entitty.Dto;
using AdaptItAcademy.Service.Entitty.Service;
using AdaptItAcademy.Service.Interface;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptItAcademy.BusinessLogic
{
    public class CouserBusinessLogic: ICouserBusinessLogic
    {
        private  readonly string connectionDb;
        private DataAccessCourse dataAccessCourse;
        public MappingConfiguration mapping = new MappingConfiguration();
        public Validation validation = new Validation();
        Mapper mapper;
        public CouserBusinessLogic() { }
        public CouserBusinessLogic(string connectionDb)
        {
            this.connectionDb = connectionDb;

            dataAccessCourse = new DataAccessCourse(connectionDb);
            mapper = new Mapper(mapping.CourseAutoMap());


        }

        public async Task<List<CourseDto>> GetCourse()
        {
           var course =  await dataAccessCourse.GetCourse();

           return mapper.Map<List<CourseDto>>(course);
        }

        public async Task<DelegateFeedBack> CreateCourse(CourseDto courseDto)
        {
            var delegateFeedBack = new DelegateFeedBack();
         
            var result = new List<ValidationResult>();
            var course = mapper.Map<Course>(courseDto);
            delegateFeedBack.IsSuccess = await dataAccessCourse.CreateCourse(course);
            delegateFeedBack.Message = delegateFeedBack.IsSuccess ? "Successful added" : "Failed";
            return delegateFeedBack;
        }

        public async Task<DelegateFeedBack> DeleteCourse(string courseCode)
        {
            var delegateFeedBack = new DelegateFeedBack();
            delegateFeedBack.IsSuccess = await dataAccessCourse.DeleteCourse(courseCode);
            delegateFeedBack.Message = delegateFeedBack.IsSuccess ? "Successful Removed" : "Kindly remove Training first";
            return delegateFeedBack;
        }
    }
}
