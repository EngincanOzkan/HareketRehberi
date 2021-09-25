using HareketRehberi.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HareketRehberi.Data.Repos.AnswerRepos
{
    public class AnswerRepo : BaseRepo<Answer>, IAnswerRepo
    {
        private readonly DataContext _context;
        public AnswerRepo(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Answer>> GetByQuestionId(int questionId)
        {
            return await _context.Answers.Where(q => q.QuestionId == questionId).ToListAsync();
        }
    }
}
