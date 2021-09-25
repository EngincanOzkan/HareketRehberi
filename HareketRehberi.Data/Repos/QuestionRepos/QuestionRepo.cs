using HareketRehberi.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HareketRehberi.Data.Repos.QuestionRepos
{
    public class QuestionRepo : BaseRepo<Question>, IQuestionRepo
    {
        private readonly DataContext _context;
        public QuestionRepo(DataContext context) : base(context){
            _context = context;
        }

        public async Task<IEnumerable<Question>> GetByEvaluationId(int evaluationId) {
            return await _context.Questions.Where(q => q.EvaluationId == evaluationId).ToListAsync();
        }
    }
}
