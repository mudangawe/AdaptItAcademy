using AdaptItAcademy.Service.Entitty.model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptItAcademy.DataAccess
{
    public class DataAccessTraining
    {
        private readonly string connectiondb = "";

        public DataAccessTraining(string connectiondb)
        {
            this.connectiondb = connectiondb;
        }
        public async Task<List<Training>> GetTraining()
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                var query = @"SELECT 
                              ClosingDate
                              ,[StartingDate]
                              ,[EndingDate]
                              ,[Amount]
                              ,[IsTrainingPaidFor]
                              ,[VenueId]
                              ,[CourseCode]
                              ,[DateAdded]
	                          ,(select v.Seats from tblVenue v where v.VenueId = t.VenueId ) as Seats
	                          ,(select count(*) from tblRegistration r where r.TrainingId = t.TrainingId) as RegistrationCount
                          FROM[AdaptITDb].[dbo].[tblTraining] t";

                var trainings = await connection.QueryAsync<Training>(query);
                return trainings.ToList();
            }

        }

        public async Task<Boolean> CreateTraining(Training training)
        {
            using (var connection = CreateConnection())
            {
                string insertQuery = @"INSERT INTO [dbo].[tblTraining]
                                       (
                                        ClosingDate
                                    ,[StartingDate]
                                    ,[EndingDate]
                                    ,[Amount]
                                    ,[IsTrainingPaidFor]
                                    ,[VenueId]
                                    ,[CourseCode]
                                    ,[DateAdded])
                                 VALUES
                                       (@ClosingDate
                                       ,@StartingDate
                                       ,@EndDate
                                       ,@Amount
                                       ,@IsTrainingPaidFor
                                       ,@VenueId,
                                        @CourseCode,
                                        @DateAdded)";

                var result = await connection.ExecuteAsync(insertQuery, new
                {
                    training.ClosingDate,
                    training.StartingDate,
                    training.EndDate,
                    training.Amount,
                    training.IsTrainingPaidFor,
                    training.VenueId,
                    training.CourseCode,
                    DateAdded = DateTime.Now
                });
                return result > 0;
            }
        }

        public async Task<Boolean> DeleteTraining(int traingId)
        {
            using (var connection = CreateConnection())
            {
                var insertQuery = "DELETE tblTraining WHERE TrainingId = @traingId";
                var result = await connection.ExecuteAsync(insertQuery, new { traingId });
                return result > 0;
            }
        }
        public IDbConnection CreateConnection()
         => new SqlConnection(connectiondb);
    }
}
