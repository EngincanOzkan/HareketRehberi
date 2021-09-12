using HareketRehberi.Domain.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HareketRehberi.Data.Repos.EvaluationRepos
{
    public interface IEvaluationRepo
    {
        Task<IEnumerable<Evaluation>> GetAllAsync();
        Task<Evaluation> GetAsync(int id);
        Task<Evaluation> CreateAsync(Evaluation evaluation);
        Task<Evaluation> UpdateAsync(Evaluation evaluation);
        Task<Evaluation> DeleteAsync(int id);
        Task<bool> AnyAsync(string evaluationName, int? id);
    }
}
