using HareketRehberi.Data.Repos.LessonEvaluationMatchRepos;
using HareketRehberi.Domain.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HareketRehberi.BL.LessonEvaluationMatchBL
{
    public class LessonEvaluationMatchBL : ILessonEvaluationMatchBL
    {
        private readonly ILessonEvaluationMatchRepo _lessonEvaluationMatchRepo;

        public LessonEvaluationMatchBL(ILessonEvaluationMatchRepo lessonEvaluationMatchRepo)
        {
            _lessonEvaluationMatchRepo = lessonEvaluationMatchRepo;
        }

        public async Task<IEnumerable<LessonEvaluationMatch>> GetAll()
        {
            var response = await _lessonEvaluationMatchRepo.GetAllAsync();
            return response;
        }

        public async Task<LessonEvaluationMatch> Get(int id)
        {
            var response = await _lessonEvaluationMatchRepo.GetAsync(id);
            return response;
        }

        public async Task<LessonEvaluationMatch> Create(LessonEvaluationMatch lessonEvaluationMatch)
        {
            var response = await _lessonEvaluationMatchRepo.CreateAsync(lessonEvaluationMatch);
            return response;
        }

        public async Task<LessonEvaluationMatch> Update(LessonEvaluationMatch lessonEvaluationMatch)
        {
            var response = await _lessonEvaluationMatchRepo.UpdateAsync(lessonEvaluationMatch);
            return response;
        }

        public async Task<LessonEvaluationMatch> Delete(int id)
        {
            var response = await _lessonEvaluationMatchRepo.DeleteAsync(id);
            return response;
        }

        public async Task<LessonEvaluationMatch> DeleteByLessonId(int lessonId) {
            var response = await _lessonEvaluationMatchRepo.DeleteByLessonIdAsync(lessonId);
            return response;
        }
    }
}
