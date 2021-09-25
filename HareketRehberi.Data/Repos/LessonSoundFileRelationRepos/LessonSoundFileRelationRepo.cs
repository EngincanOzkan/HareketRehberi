using HareketRehberi.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HareketRehberi.Data.Repos.LessonSoundFileRelationRepos
{
    public class LessonSoundFileRelationRepo : BaseRepo<LessonSoundFileRelation>, ILessonSoundFileRelationRepo
    {
        private readonly DataContext _context;

        public LessonSoundFileRelationRepo(DataContext context): base(context)
        {
            _context = context;
        }

        public async Task<LessonSoundFileRelation> GetAsync(int lessonId, int pageNumber)
        {
            return await _context.LessonSoundFileRelations.FirstOrDefaultAsync(q => q.LessonId == lessonId && q.PageNumber == pageNumber);
        }

        public async Task<IEnumerable<LessonSoundFileRelation>> GetByLessonIdAsync(int lessonId)
        {
            return await _context.LessonSoundFileRelations.Where(q => q.LessonId == lessonId).ToListAsync();
        }

        public async Task<IEnumerable<LessonSoundFileRelation>> GetByPageNumberAsync(int PageNumber, int lessonId)
        {
            return await _context.LessonSoundFileRelations.Where(q => q.PageNumber == PageNumber && q.LessonId == lessonId).ToListAsync();
        }
    }
}
