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
    public class CandidateController : ControllerBase
    {

        private readonly IBusinessLogicCandidate candidateBusinessLogic;

        public CandidateController(IBusinessLogicCandidate candidateBusinessLogic)
        {
            this.candidateBusinessLogic = candidateBusinessLogic;
        }

        [HttpPost]
        public async Task<DelegateFeedBack> Post([FromBody] CandidateDto delegateDto)
        {
            try
            {
                return await this.candidateBusinessLogic.CreateCandidate(delegateDto);
            }
            catch(Exception ex)
            {
                var delegateFeedBack = new DelegateFeedBack();
                delegateFeedBack.IsSuccess = false;
                delegateFeedBack.Message = "Something bad happened";
                return delegateFeedBack;
            }
        }
    }
}
