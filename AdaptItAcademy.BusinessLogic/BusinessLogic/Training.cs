using AdaptItAcademy.BusinessLogic.AutoMapper;
using AdaptItAcademy.BusinessLogic.Data;
using AdaptItAcademy.DataAccess;
using AdaptItAcademy.Service.Entitty.Dto;
using AdaptItAcademy.Service.Entitty.model;
using AdaptItAcademy.Service.Interface;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdaptItAcademy.BusinessLogic.BusinessLogic
{
    public class BusinesLogicTraining : IBusinesLogicTraining
    {
        MappingConfiguration mapping = new MappingConfiguration();
        Validation validation = new Validation();
        Mapper mapper;
        DataAccessTraining trainingDataAccess;

        public BusinesLogicTraining() { }
        public BusinesLogicTraining(string connectionDb)
        {
            this.trainingDataAccess = new DataAccessTraining(connectionDb);
            mapper = new Mapper(mapping.TrainingAutoMapper());
        }
        public async Task<List<TrainingDto>> GetTraining()
        {
            return mapper.Map<List<TrainingDto>>(await trainingDataAccess.GetTraining());
        }
        public async Task<DelegateFeedBack> CreateTraining(TrainingDto course)
        {
            var delegateFeedBack = new DelegateFeedBack();
            var tempTraining =  mapper.Map<Training>(course);
            delegateFeedBack.IsSuccess = await trainingDataAccess.CreateTraining(tempTraining);
            return delegateFeedBack;
        }
        public async Task<DelegateFeedBack> DeleteTraining(int trainingId)
        {
            var delegateFeedBack = new DelegateFeedBack();
            delegateFeedBack.IsSuccess = await trainingDataAccess.DeleteTraining(trainingId);
            return delegateFeedBack;

        }
    }
}
