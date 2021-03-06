using AutoMapper;
using HareketRehberi.Domain.Models.Entities;
using HareketRehberi.Domain.Models.Requests;

namespace HareketRehberi.Domain
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<SystemUserRequest, SystemUser>();
            CreateMap<QuestionRequest, Question>();
            CreateMap<AnswerRequest, Answer>();
            CreateMap<LessonEvaluationMatchRequest, LessonEvaluationMatch>();
            CreateMap<LessonUserMatchRequest, LessonUserMatch>();
            CreateMap<UserLessonProgressLogRequest, UserLessonProgressLog>();
            CreateMap<UserLessonsEvaluationsQuestionsAnswers, UserLessonsEvaluationsQuestionsAnswersRequest>();
        }
    }
}
