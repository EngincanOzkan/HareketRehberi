using HareketRehberi.Domain.Models.Entities;
using System;
using System.Collections.Generic;

namespace HareketRehberi.Domain.Models.Requests
{
    public class ReportModel
    {
        public UserLessonProgressLog Progress { get; set; }
        public Lesson Lesson { get; set; }
        public string UserName { get; set; }

        public Evaluation Evaluation { get; set; }
        public List<UserLessonsEvaluationsQuestionsAnswers> EvaluationAndAnswers { get; set; }
        public List<Question> Questions { get; set; }
        public List<Answer> GivenAnswers { get; set; }
        public List<Answer> AnswerRight { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string StrStartTime { get; set; }
        public string StrEndTime { get; set; }
        public string TimeSpend { get; set; }
        public int? Empty { get; set; }
        public int? TrueAnswers { get; set; }
        public int? FalseAnswers { get; set; }
        public ReportModel()
        {
            EvaluationAndAnswers = new List<UserLessonsEvaluationsQuestionsAnswers>();
            GivenAnswers = new List<Answer>();
            AnswerRight = new List<Answer>();
            Questions = new List<Question>();
        }
    }
}
