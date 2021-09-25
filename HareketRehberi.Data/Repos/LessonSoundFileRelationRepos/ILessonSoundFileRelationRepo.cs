using HareketRehberi.Domain.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HareketRehberi.Data.Repos.LessonSoundFileRelationRepos
{
    public interface ILessonSoundFileRelationRepo : IBaseRepo<LessonSoundFileRelation>
    {
        Task<LessonSoundFileRelation> GetAsync(int lessonId, int pageNumber);
        Task<IEnumerable<LessonSoundFileRelation>> GetByLessonIdAsync(int lessonId);
        Task<IEnumerable<LessonSoundFileRelation>> GetByPageNumberAsync(int pageNumber, int lessonId);
    }
}
