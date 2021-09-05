using HareketRehberi.Data.Repos.LessonSoundFileRelationRepos;
using HareketRehberi.Domain.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HareketRehberi.BL.LessonSoundFileRelationBL
{
    public class LessonSoundFileRelationBL : ILessonSoundFileRelationBL
    {
        private readonly ILessonSoundFileRelationRepo _lessonSoundFileRelationRepo;

        public LessonSoundFileRelationBL(ILessonSoundFileRelationRepo lessonSoundFileRelationRepo)
        {
            _lessonSoundFileRelationRepo = lessonSoundFileRelationRepo;
        }

        public async Task<IEnumerable<LessonSoundFileRelation>> GetAll()
        {
            var relations = await _lessonSoundFileRelationRepo.GetAllAsync();
            return relations;
        }

        public async Task<LessonSoundFileRelation> Get(int id)
        {
            var relation = await _lessonSoundFileRelationRepo.GetAsync(id);
            return relation;
        }
        public async Task<IEnumerable<LessonSoundFileRelation>> GetByLessonId(int lessonId)
        {
            var relation = await _lessonSoundFileRelationRepo.GetByLessonIdAsync(lessonId);
            return relation;
        }

        public async Task<IEnumerable<LessonSoundFileRelation>> GetByPageNumber(int pageNumber, int lessonId)
        {
            var relation = await _lessonSoundFileRelationRepo.GetByPageNumberAsync(pageNumber, lessonId);
            return relation;
        }

        public async Task<LessonSoundFileRelation> Create(LessonSoundFileRelation relation)
        {
            var createdRelation = await _lessonSoundFileRelationRepo.CreateAsync(relation);
            return createdRelation;
        }

        public async Task<LessonSoundFileRelation> Update(LessonSoundFileRelation relation)
        {
            var updatedRelation = await _lessonSoundFileRelationRepo.UpdateAsync(relation);
            return updatedRelation;
        }

        public async Task<LessonSoundFileRelation> Delete(int id)
        {
            var deletedRelation = await _lessonSoundFileRelationRepo.DeleteAsync(id);
            return deletedRelation;
        }
    }
}
