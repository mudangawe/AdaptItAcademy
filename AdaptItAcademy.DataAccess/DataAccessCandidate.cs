using AdaptItAcademy.Service.Entitty.Dto;
using AdaptItAcademy.Service.Entitty.model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace AdaptItAcademy.DataAccess
{
    public class DataAccessCandidate
    {
        private string connectiondb;
        public DataAccessCandidate(string connectiondb)
        {
            this.connectiondb = connectiondb;
        }
        public async Task<Boolean> CreateCandidate(Candidate candidate)
        {

            var CompanyId = await InsertCompany(candidate.CompanyName);
            var HomeAddressId = await InsertAddress(candidate.PostalAddress,false );
            var PostalAddressId = await InsertAddress(candidate.PhysicalAddress,true );
      
            using (var connection = CreateConnection())
            {
                string insertQuery = @"INSERT INTO [dbo].[tblCandidate]
                                    ([FirstName]
                                    ,[LastName]
                                    ,[PhoneNumber]
                                    ,[Email]
                                    ,[CompanyId]
                                    ,[DietaryId])
                                VALUES
                                    (@FirstName
                                    ,@LastName
                                    ,@PhoneNumber
                                    ,@Email
                                    ,@CompanyId
                                    ,@DietaryId)
                                select CAST(SCOPE_IDENTITY() as int)";
                var DietaryId = (int)(object)candidate.Dietary;
                var result = await connection.QuerySingleAsync<int>(insertQuery, new
                {
                    candidate.FirstName,
                    candidate.LastName,
                    candidate.PhoneNumber,
                    candidate.Email,
                    CompanyId,
                    DietaryId
                });


                await InsertCandidateAddress(result, HomeAddressId);
                await InsertCandidateAddress(result, PostalAddressId);
                return result > 0;
            }
        }

        public async Task<int> InsertAddress(Address address, Boolean IsPhysicalAddress)
        {
            using (var connection = CreateConnection())
            {
                string insertQuery = @"INSERT INTO [dbo].[tblAddess]
                                        ([StreetNo]
                                        ,[Suburb]
                                        ,[City]
                                        ,[Code]
                                        ,[IsPhysicalAddress])
                                    VALUES
                                        (
                                        @StreetNo
                                        ,@Suburb
                                        ,@City
                                        ,@Code
                                        ,@IsPhysicalAddress)
                                        select CAST(SCOPE_IDENTITY() as int)
                                        ";

                var result = await connection.QuerySingleAsync<int>(insertQuery, new
                {
                    address.StreetNo,
                    address.Suburb,
                    address.City,
                    address.Code,
                    IsPhysicalAddress
                });
                return result;
            }
        }

        public async Task<int> InsertCompany(string company)
        {
            using (var connection = CreateConnection())
            {
                string insertQuery = @"INSERT INTO [dbo].[tblCompany]
                                        ([Name])
                                    VALUES
                                        (@company)
                                        select CAST(SCOPE_IDENTITY() as int)
                                        ";

                var result = await connection.QuerySingleAsync<int>(insertQuery, new
                {
                    company
                });
                return result;
            }
        }
        public async Task InsertCandidateAddress(int candidateId, int addressid)
        {
            using (var connection = CreateConnection())
            {
                string insertQuery = @"INSERT INTO [dbo].[CandidateAddress]
                                       (CandidateId,
                                        [AddressId])
                                 VALUES
                                       (@candidateId, @addressid)";
                var result = await connection.ExecuteAsync(insertQuery, new
                {
                    candidateId,
                    addressid
                });
            }
        }

      
        public IDbConnection CreateConnection()
         => new SqlConnection(connectiondb);
    }
}
