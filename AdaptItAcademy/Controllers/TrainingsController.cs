using AdaptItAcademy.Service.Entitty.Dto;
using AdaptItAcademy.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptItAcademy.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingsController : ControllerBase
    {
        private readonly IBusinesLogicTraining ITrainingBusinessLogic;
    
        public TrainingsController(IBusinesLogicTraining ITrainingBusinessLogic )
        {
            this.ITrainingBusinessLogic = ITrainingBusinessLogic;
        }


        [HttpGet]
        public async Task<ActionResult<List<TrainingDto>>> GetTraining()
        {
            try
            {
                return await this.ITrainingBusinessLogic.GetTraining();
            }
            catch(Exception ex)
            {
                return new List<TrainingDto>(){ };
            }
           
        }
        [HttpPost]
        public async Task<DelegateFeedBack> Post([FromBody] TrainingDto delegateDto)
        {
            try 
            {
                return await this.ITrainingBusinessLogic.CreateTraining(delegateDto);
            }
            catch (Exception ex)
            {
                var delegateFeedBack = new DelegateFeedBack();
                delegateFeedBack.IsSuccess = false;
                delegateFeedBack.Message = "Something bad happened";
                return delegateFeedBack;
            }
        }

        [HttpDelete("{trainingId:int}")]
        public async Task<DelegateFeedBack> Delete(int trainingId)
        {
            try 
            {
                return await this.ITrainingBusinessLogic.DeleteTraining(trainingId);
            }
            catch (Exception ex)
            {
                var delegateFeedBack = new DelegateFeedBack();
                delegateFeedBack.IsSuccess = false;
                delegateFeedBack.Message = "Something bad happened";
                return delegateFeedBack;
            }
          
        }
    }
}
