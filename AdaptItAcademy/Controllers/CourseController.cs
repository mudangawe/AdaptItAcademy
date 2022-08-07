using AdaptItAcademy.BusinessLogic;
using AdaptItAcademy.DataAccess;
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
    public class CourseController : ControllerBase
    {
        private readonly ICouserBusinessLogic couserBusinessLogic;

        public CourseController(ICouserBusinessLogic couserBusinessLogic)
        {
            this.couserBusinessLogic = couserBusinessLogic;
        }


        [HttpGet]
        public async Task<ActionResult<List<CourseDto>>> GetCourse()
        { 
            return await this.couserBusinessLogic.GetCourse();
        }
        [HttpPost]
        public async Task<DelegateFeedBack> Post([FromBody] CourseDto delegateDto)
        {
            try 
            {
                return await this.couserBusinessLogic.CreateCourse(delegateDto);
            }
            catch(Exception ex)
            {
                var delegateFeedBack = new DelegateFeedBack();
                delegateFeedBack.IsSuccess = false;
                delegateFeedBack.Message = "Something bad happened";
                return delegateFeedBack;
            }
            
        }

        [HttpDelete("{courseCode}")]
        public async Task<DelegateFeedBack> Delete(string courseCode)
        {
            try
            {
                return await this.couserBusinessLogic.DeleteCourse(courseCode);
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
