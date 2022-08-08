using AdaptItAcademy.BusinessLogic.AutoMapper;
using AdaptItAcademy.BusinessLogic.Data;
using AdaptItAcademy.DataAccess;
using AdaptItAcademy.Service.Entitty.Dto;
using AdaptItAcademy.Service.Entitty.model;
using AdaptItAcademy.Service.Interface;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptItAcademy.BusinessLogic.BusinessLogic
{
    public class BusinessLogicCandidate : IBusinessLogicCandidate
    {
        private DataAccessCandidate dataAccessCandidate;
        public MappingConfiguration mapping = new MappingConfiguration();
        public Validation validation = new Validation();
        Mapper mapper;
        public BusinessLogicCandidate(string connectionDb)
        {
            dataAccessCandidate = new DataAccessCandidate(connectionDb);
            mapper = new Mapper(mapping.CandidateAutoMapper());

        }

        public async Task<DelegateFeedBack> CreateCandidate(CandidateDto courseDto)
        {
            var delegateFeedBack = new DelegateFeedBack();

            
            var candidate = mapper.Map<Candidate>(courseDto);
            delegateFeedBack.IsSuccess = await dataAccessCandidate.CreateCandidate(candidate);
            delegateFeedBack.Message = delegateFeedBack.IsSuccess ? "Successful added" : "Failed";
            return delegateFeedBack;
        }

       
    }
}
