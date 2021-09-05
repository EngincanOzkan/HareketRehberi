using HareketRehberi.Domain.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HareketRehberi.BL.LessonSoundFileRelationBL
{
    public interface ILessonSoundFileRelationBL
    {
        Task<IEnumerable<LessonSoundFileRelation>> GetAll();
        Task<LessonSoundFileRelation> Get(int id);
        Task<LessonSoundFileRelation> Get(int lessonId, int pageNumber);
        Task<IEnumerable<LessonSoundFileRelation>> GetByLessonId(int lessonId);
        Task<IEnumerable<LessonSoundFileRelation>> GetByPageNumber(int pageNumber, int lessonId);
        Task<LessonSoundFileRelation> Create(LessonSoundFileRelation relation);
        Task<LessonSoundFileRelation> Update(LessonSoundFileRelation relation);
        Task<LessonSoundFileRelation> Delete(int id);
    }
}
