using HareketRehberi.Domain.Models.Entities;
using HareketRehberi.Domain.Models.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HareketRehberi.BL.EvaluationBL
{
    public interface IEvaluationBL
    {
        Task<IEnumerable<Evaluation>> GetAll();
        Task<Evaluation> Get(int id);
        Task<Evaluation> Create(EvaluationRequest evaluationRequest);
        Task<Evaluation> Update(EvaluationRequest evaluationRequest);
        Task<Evaluation> Delete(int id);
    }
}
