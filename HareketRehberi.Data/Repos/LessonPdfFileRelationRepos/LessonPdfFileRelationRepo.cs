using HareketRehberi.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HareketRehberi.Data.Repos.LessonPdfFileRelationRepos
{
    public class LessonPdfFileRelationRepo : BaseRepo<LessonPdfFileRelation>, ILessonPdfFileRelationRepo 
    {
        private readonly DataContext _context;

        public LessonPdfFileRelationRepo(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LessonPdfFileRelation>> GetByLessonIdAsync(int lessonId)
        {
            return await _context.LessonPdfFileRelations.Where(q => q.LessonId == lessonId).ToListAsync();
        }
    }
}
