using HareketRehberi.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HareketRehberi.Data.Repos.EvaluationRepos
{
    public class EvaluationRepo : IEvaluationRepo
    {
        private readonly DataContext _context;

        public EvaluationRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Evaluation>> GetAllAsync()
        {
            return await _context.Evaluations.ToListAsync();
        }

        public async Task<Evaluation> GetAsync(int id)
        {
            return await _context.Evaluations.FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<Evaluation> CreateAsync(Evaluation evaluation)
        {
            await _context.Evaluations.AddAsync(evaluation);
            await _context.SaveChangesAsync();
            return evaluation;
        }

        public async Task<Evaluation> UpdateAsync(Evaluation evaluation)
        {
            var evaluationToUpdate = await this.GetAsync(evaluation.Id);
            if (evaluationToUpdate != null)
            {
                evaluationToUpdate.EvaluationName = evaluation.EvaluationName;
                evaluationToUpdate.IsSurvey = evaluation.IsSurvey;
                _context.Evaluations.Update(evaluationToUpdate);
                await _context.SaveChangesAsync();
            }
            return evaluation;
        }

        public async Task<Evaluation> DeleteAsync(int id)
        {
            var evaluationToDelete = await GetAsync(id);
            if (evaluationToDelete != null)
            {
                _context.Evaluations.Remove(evaluationToDelete);
                await _context.SaveChangesAsync();
            }
            return evaluationToDelete;
        }

        public async Task<bool> AnyAsync(string evaluationName, int? id)
        {
            if (id != null)
                return await _context.Evaluations.AnyAsync(q => q.EvaluationName == evaluationName && q.Id != id);
            else
                return await _context.Evaluations.AnyAsync(q => q.EvaluationName == evaluationName);
        }
    }
}
