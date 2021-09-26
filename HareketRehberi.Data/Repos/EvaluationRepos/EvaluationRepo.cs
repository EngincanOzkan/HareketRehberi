using HareketRehberi.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HareketRehberi.Data.Repos.EvaluationRepos
{
    public class EvaluationRepo : BaseRepo<Evaluation>, IEvaluationRepo
    {
        private readonly DataContext _context;

        public EvaluationRepo(DataContext context) : base(context)
        {
            _context = context;
        }
        public async Task<bool> AnyAsync(string evaluationName, int? id)
        {
            if (id != null)
                return await _context.Evaluations.AnyAsync(q => q.EvaluationName == evaluationName && q.Id != id);
            else
                return await _context.Evaluations.AnyAsync(q => q.EvaluationName == evaluationName);
        }

        public async Task<IEnumerable<Evaluation>> GetEvaluationsByLessonId(int lessonId) {
            var matches = await _context.LessonEvaluationMatches.Where(q => q.LessonId == lessonId).Select(q => q.EvaluationId).ToListAsync();
            return await _context.Evaluations.Where(q => matches.Contains(q.Id)).ToListAsync();
        }
    }
}
