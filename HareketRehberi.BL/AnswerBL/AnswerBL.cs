using HareketRehberi.BL.EvaluationBL;
using HareketRehberi.BL.QuestionBL;
using HareketRehberi.Data.Repos.AnswerRepos;
using HareketRehberi.Domain.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HareketRehberi.BL.AnswerBL
{
    public class AnswerBL : IAnswerBL
    {
        private readonly IEvaluationBL _evaluationBL;
        private readonly IQuestionBL _questionBL;
        private readonly IAnswerRepo _answerRepo;

        public AnswerBL(IAnswerRepo answerRepo, IQuestionBL questionBL, IEvaluationBL evaluationBL)
        {
            _answerRepo = answerRepo;
            _questionBL = questionBL;
            _evaluationBL = evaluationBL;
        }

        public async Task<IEnumerable<Answer>> GetAll()
        {
            var response = await _answerRepo.GetAllAsync();
            return response;
        }

        public async Task<Answer> Get(int id)
        {
            var response = await _answerRepo.GetAsync(id);
            return response;
        }
        public async Task<IEnumerable<Answer>> GetByQuestionId(int questionId)
        {
            var response = await _answerRepo.GetByQuestionId(questionId);
            return response;
        }

        public async Task<Answer> Create(Answer answer)
        {
            answer.IsSurvey = (await _evaluationBL.Get((await _questionBL.Get(answer.QuestionId)).EvaluationId)).IsSurvey;
            var response = await _answerRepo.CreateAsync(answer);
            return response;
        }

        public async Task<Answer> Update(Answer answer)
        {
            var response = await _answerRepo.UpdateAsync(answer);
            return response;
        }

        public async Task<Answer> Delete(int id)
        {
            var response = await _answerRepo.DeleteAsync(id);
            return response;
        }
    }
}
