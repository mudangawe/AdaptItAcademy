using AdaptItAcademy.DataAccess;
using AdaptItAcademy.Service.Entitty.Dto;
using AdaptItAcademy.Service.Entitty;
using AdaptItAcademy.Service.Entitty.Service;
using AdaptItAcademy.Service;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptItAcademy.DataAccess
{
  
    public class DataAccessCourse : IDataAccessCourse
    {
        private readonly string connectiondb;

       
        public DataAccessCourse(string connectiondb)
        {
            this.connectiondb = connectiondb;
        }

        public async Task<List<Course>> GetCourse()
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                var query = "select CourseCode,Name,Description,CourseCode from tblCourse";

                var companies = await connection.QueryAsync<Course>(query);
                return companies.ToList();
            }
           
        }

        public async Task<Boolean> CreateCourse(Course course)
        {
            using (var connection = CreateConnection())
            {
                string insertQuery = @"INSERT INTO [dbo].[tblCourse]
                                       (
                                       [Name]
                                       ,[Description]
                                       ,[DateAdded]
                                        ,CourseCode)
                                 VALUES
                                       (@Name
                                       ,@Description
                                       ,@DateAdded
                                       ,@CourseCode)";

                var result = await connection.ExecuteAsync(insertQuery, new
                {
                    course.Name,
                    course.Description,
                    DateAdded = DateTime.Now,
                    course.CourseCode
                });
                return result > 0;
            }
        }

        public async Task<Boolean> DeleteCourse(string courseCode)
        {
            using (var connection = CreateConnection())
            {
                try
                {
                    var insertQuery = "DELETE tblCourse WHERE CourseCode = @coursecode";
                    var result = await connection.ExecuteAsync(insertQuery, new { courseCode });
                    return result > 0;
                }
                catch(Exception ex)
                {
                    return false;
                }
               

               
            }
        }
        public IDbConnection CreateConnection()
         => new SqlConnection(connectiondb);
    }
}
