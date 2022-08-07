using AdaptItAcademy.Service.Entitty.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdaptItAcademy.DataAccess
{
    public interface IDataAccessCourse
    {
        Task<List<Course>> GetCourse();
        Task<Boolean> CreateCourse(Course course);
        Task<Boolean> DeleteCourse(string courseId);
    }
}
