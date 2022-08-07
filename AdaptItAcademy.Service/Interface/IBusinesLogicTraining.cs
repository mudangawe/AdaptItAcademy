using AdaptItAcademy.Service.Entitty.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdaptItAcademy.Service.Interface
{
    public interface IBusinesLogicTraining
    {
        Task<List<TrainingDto>> GetTraining();
        Task<DelegateFeedBack> CreateTraining(TrainingDto course);
        Task<DelegateFeedBack> DeleteTraining(int courseCode);
    }
}
