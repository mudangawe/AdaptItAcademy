using AdaptItAcademy.Service.Entitty.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdaptItAcademy.Service.Interface
{
    public interface ICouserBusinessLogic
    {
        Task<List<CourseDto>> GetCourse();
        Task<DelegateFeedBack> CreateCourse(CourseDto course);
        Task<DelegateFeedBack> DeleteCourse(string courseID);
    }
}
