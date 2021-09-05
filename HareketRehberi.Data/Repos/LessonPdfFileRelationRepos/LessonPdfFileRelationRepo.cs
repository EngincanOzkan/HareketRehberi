using HareketRehberi.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HareketRehberi.Data.Repos.LessonPdfFileRelationRepos
{
    public class LessonPdfFileRelationRepo : ILessonPdfFileRelationRepo 
    {
        private readonly DataContext _context;

        public LessonPdfFileRelationRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LessonPdfFileRelation>> GetAllAsync()
        {
            return await _context.LessonPdfFileRelations.ToListAsync();
        }

        public async Task<LessonPdfFileRelation> GetAsync(int id)
        {
            return await _context.LessonPdfFileRelations.FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<IEnumerable<LessonPdfFileRelation>> GetByLessonIdAsync(int lessonId)
        {
            return await _context.LessonPdfFileRelations.Where(q => q.LessonId == lessonId).ToListAsync();
        }

        public async Task<LessonPdfFileRelation> CreateAsync(LessonPdfFileRelation lessonPdfFileRelation)
        {
            await _context.LessonPdfFileRelations.AddAsync(lessonPdfFileRelation);
            await _context.SaveChangesAsync();
            return lessonPdfFileRelation;
        }

        public async Task<LessonPdfFileRelation> UpdateAsync(LessonPdfFileRelation lessonPdfFileRelation)
        {
            var relationToUpdate = await this.GetAsync(lessonPdfFileRelation.Id);
            if (relationToUpdate != null)
            {
                relationToUpdate.FileGuid = lessonPdfFileRelation.FileGuid;
                relationToUpdate.FileName = lessonPdfFileRelation.FileName;
                _context.LessonPdfFileRelations.Update(relationToUpdate);
                await _context.SaveChangesAsync();
            }
            return lessonPdfFileRelation;
        }

        public async Task<LessonPdfFileRelation> DeleteAsync(int id)
        {
            var lessonToDelete = await GetAsync(id);
            if (lessonToDelete != null)
            {
                _context.LessonPdfFileRelations.Remove(lessonToDelete);
                await _context.SaveChangesAsync();
            }
            return lessonToDelete;
        }
    }
}
