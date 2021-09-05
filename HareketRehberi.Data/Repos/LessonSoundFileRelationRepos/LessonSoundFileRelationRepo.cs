using HareketRehberi.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HareketRehberi.Data.Repos.LessonSoundFileRelationRepos
{
    public class LessonSoundFileRelationRepo : ILessonSoundFileRelationRepo
    {
        private readonly DataContext _context;

        public LessonSoundFileRelationRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LessonSoundFileRelation>> GetAllAsync()
        {
            return await _context.LessonSoundFileRelations.ToListAsync();
        }

        public async Task<LessonSoundFileRelation> GetAsync(int id)
        {
            return await _context.LessonSoundFileRelations.FirstOrDefaultAsync(q => q.Id == id);
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

        public async Task<LessonSoundFileRelation> CreateAsync(LessonSoundFileRelation lessonSoundFileRelation)
        {
            var response = await _context.LessonSoundFileRelations.AddAsync(lessonSoundFileRelation);
            await _context.SaveChangesAsync();
            return lessonSoundFileRelation;
        }

        public async Task<LessonSoundFileRelation> UpdateAsync(LessonSoundFileRelation lessonSoundFileRelation)
        {
            var relationToUpdate = await this.GetAsync(lessonSoundFileRelation.Id);
            if (relationToUpdate != null)
            {
                relationToUpdate.FileGuid = lessonSoundFileRelation.FileGuid;
                relationToUpdate.FileName = lessonSoundFileRelation.FileName;
                relationToUpdate.PageNumber = lessonSoundFileRelation.PageNumber;
                _context.LessonSoundFileRelations.Update(relationToUpdate);
                await _context.SaveChangesAsync();
            }
            return lessonSoundFileRelation;
        }

        public async Task<LessonSoundFileRelation> DeleteAsync(int id)
        {
            var soundToDelete = await GetAsync(id);
            if (soundToDelete != null)
            {
                _context.LessonSoundFileRelations.Remove(soundToDelete);
                await _context.SaveChangesAsync();
            }
            return soundToDelete;
        }
    }
}
