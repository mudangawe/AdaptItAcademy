using AdaptItAcademy.Service.Entitty.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdaptItAcademy.Service.Interface
{
    public interface IBusinessLogicCandidate
    {
        public Task<DelegateFeedBack> CreateCandidate(CandidateDto courseDto);
    }
}
