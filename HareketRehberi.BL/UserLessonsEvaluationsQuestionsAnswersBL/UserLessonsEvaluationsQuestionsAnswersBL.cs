using HareketRehberi.BL.AnswerBL;
using HareketRehberi.BL.EvaluationBL;
using HareketRehberi.BL.QuestionBL;
using HareketRehberi.Data.Repos.UserLessonsEvaluationsQuestionsAnswersRepos;
using HareketRehberi.Domain.Models.Entities;
using HareketRehberi.Domain.Models.Requests;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HareketRehberi.BL.UserLessonsEvaluationsQuestionsAnswersBL
{
    public class UserLessonsEvaluationsQuestionsAnswersBL : IUserLessonsEvaluationsQuestionsAnswersBL
    {
        private readonly IUserLessonsEvaluationsQuestionsAnswersRepo _userLessonsEvaluationsQuestionsAnswersRepo;
        private readonly IEvaluationBL _evaluation;
        private readonly IQuestionBL _question;
        private readonly IAnswerBL _answer;

        public UserLessonsEvaluationsQuestionsAnswersBL(
            IUserLessonsEvaluationsQuestionsAnswersRepo userLessonsEvaluationsQuestionsAnswersRepo,
            IEvaluationBL evaluation,
            IQuestionBL question,
            IAnswerBL answer
        )
        {
            _userLessonsEvaluationsQuestionsAnswersRepo = userLessonsEvaluationsQuestionsAnswersRepo;
            _evaluation = evaluation;
            _question = question;
            _answer = answer;
        }

        public async Task<IEnumerable<UserLessonsEvaluationsQuestionsAnswers>> GetAll()
        {
            var response = await _userLessonsEvaluationsQuestionsAnswersRepo.GetAllAsync();
            return response;
        }

        public async Task<UserLessonsEvaluationsQuestionsAnswers> Get(int id)
        {
            var response = await _userLessonsEvaluationsQuestionsAnswersRepo.GetAsync(id);
            return response;
        }

        public async Task<UserLessonsEvaluationsQuestionsAnswers> Create(UserLessonsEvaluationsQuestionsAnswers userLessonsEvaluationsQuestionsAnswers)
        {
            var response = await _userLessonsEvaluationsQuestionsAnswersRepo.CreateAsync(userLessonsEvaluationsQuestionsAnswers);
            return response;
        }

        public async Task<UserLessonsEvaluationsQuestionsAnswers> Update(UserLessonsEvaluationsQuestionsAnswers userLessonsEvaluationsQuestionsAnswers)
        {
            var response = await _userLessonsEvaluationsQuestionsAnswersRepo.UpdateAsync(userLessonsEvaluationsQuestionsAnswers);
            return response;
        }

        public async Task<UserLessonsEvaluationsQuestionsAnswers> Delete(int id)
        {
            var response = await _userLessonsEvaluationsQuestionsAnswersRepo.DeleteAsync(id);
            return response;
        }

        public async Task<UserLessonsEvaluationsQuestionsAnswers> UpdateAnswer(int id, int answerId) {
            var response = await _userLessonsEvaluationsQuestionsAnswersRepo.UpdateAnswer(id, answerId);
            return response;
        }

        public async Task<IEnumerable<StartEvaluationResponse>> StartEvaluation(StartEvaluationRequest startEvaluationRequest) {
            var responseList = new List<StartEvaluationResponse>();

            var evaluation = await _evaluation.Get(startEvaluationRequest.EvaluationId);
            var questions = await _question.GetByEvaluationId(startEvaluationRequest.EvaluationId);
          
            foreach (var question in questions)
            {
                var response = new StartEvaluationResponse();

                var answers = await _answer.GetByQuestionId(question.Id);

                var userLessonsEvaluationsQuestionsAnswers = new UserLessonsEvaluationsQuestionsAnswers();
                userLessonsEvaluationsQuestionsAnswers.LessonId = startEvaluationRequest.LessonId;
                userLessonsEvaluationsQuestionsAnswers.EvaluationId = startEvaluationRequest.EvaluationId;
                userLessonsEvaluationsQuestionsAnswers.UserId = startEvaluationRequest.UserId;
                userLessonsEvaluationsQuestionsAnswers.OperationIdentifier = startEvaluationRequest.OperationIdentifier;
                userLessonsEvaluationsQuestionsAnswers.QuestionId = question.Id;
                userLessonsEvaluationsQuestionsAnswers.IsSurvey = evaluation.IsSurvey;

                userLessonsEvaluationsQuestionsAnswers = await _userLessonsEvaluationsQuestionsAnswersRepo.CreateAsync(userLessonsEvaluationsQuestionsAnswers);

                response.Id = userLessonsEvaluationsQuestionsAnswers.Id;
                response.QuestionId = question.Id;
                response.QuestionText = question.QuestionText;
                response.RightAnswers = answers.Where(q => q.IsRightAnswer == true).Select(q => q.Id).ToList();
                response.Answers = answers.ToList();
                responseList.Add(response);
            }

            return responseList;
        }
    }
}
