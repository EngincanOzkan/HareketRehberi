using HareketRehberi.Domain.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HareketRehberi.Data.Repos.LessonSoundFileRelationRepos
{
    public interface ILessonSoundFileRelationRepo
    {
        Task<IEnumerable<LessonSoundFileRelation>> GetAllAsync();
        Task<LessonSoundFileRelation> GetAsync(int id);
        Task<LessonSoundFileRelation> GetAsync(int lessonId, int pageNumber);
        Task<IEnumerable<LessonSoundFileRelation>> GetByLessonIdAsync(int lessonId);
        Task<IEnumerable<LessonSoundFileRelation>> GetByPageNumberAsync(int pageNumber, int lessonId);
        Task<LessonSoundFileRelation> CreateAsync(LessonSoundFileRelation lessonSoundFileRelation);
        Task<LessonSoundFileRelation> UpdateAsync(LessonSoundFileRelation lessonSoundFileRelation);
        Task<LessonSoundFileRelation> DeleteAsync(int id);
    }
}
