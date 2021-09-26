using HareketRehberi.Data.Repos.EvaluationRepos;
using HareketRehberi.Domain.Models.Entities;
using HareketRehberi.Domain.Models.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HareketRehberi.BL.EvaluationBL
{
    public class EvaluationBL : IEvaluationBL
    {
        private readonly IEvaluationRepo _evaluationRepo;

        public EvaluationBL(IEvaluationRepo evaluationRepo)
        {
            _evaluationRepo = evaluationRepo;
        }

        public async Task<Evaluation> Create(EvaluationRequest evaluationRequest)
        {
            if (await IsEvaluationExists(evaluationRequest.EvaluationName, null)) throw new System.Exception("Değerlendirme adı daha önceden eklenmiş!!!");

            var evaluation = new Evaluation
            {
                EvaluationName = evaluationRequest.EvaluationName,
                IsSurvey = evaluationRequest.IsSurvey
            };

            var createdEvaluation = await _evaluationRepo.CreateAsync(evaluation);
            return createdEvaluation;
        }

        public async Task<Evaluation> Delete(int id)
        {
            var evaluation = await _evaluationRepo.DeleteAsync(id);
            return evaluation;
        }

        public async Task<Evaluation> Get(int id)
        {
            var evaluation = await _evaluationRepo.GetAsync(id);
            return evaluation;
        }

        public async Task<IEnumerable<Evaluation>> GetAll()
        {
            var evaluation = await _evaluationRepo.GetAllAsync();
            return evaluation;
        }

        public async Task<Evaluation> Update(EvaluationRequest evaluationRequest)
        {
            if (await IsEvaluationExists(evaluationRequest.EvaluationName, evaluationRequest.Id) || evaluationRequest.Id == null || evaluationRequest.Id == 0) throw new System.Exception("Değerlendirme adı daha önceden eklenmiş!!!");

            var evaluation = new Evaluation
            {
                Id = (int)evaluationRequest.Id,
                EvaluationName = evaluationRequest.EvaluationName,
                IsSurvey = evaluationRequest.IsSurvey
            };

            var evaluationUpdated = await _evaluationRepo.UpdateAsync(evaluation);
            return evaluationUpdated;
        }

        private async Task<bool> IsEvaluationExists(string evaluationName, int? id)
        {
            return await _evaluationRepo.AnyAsync(evaluationName, id);
        }

        public async Task<IEnumerable<Evaluation>> GetEvaluationsByLessonId(int lessonId)
        {
            var response = await _evaluationRepo.GetEvaluationsByLessonId(lessonId);
            return response;
        }

    }
}
