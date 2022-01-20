using HareketRehberi.Domain.Models.Entities;
using HareketRehberi.Domain.Models.Requests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HareketRehberi.Data.Repos.UserLessonProgressLogRepos
{
    public class UserLessonProgressLogRepo : BaseRepo<UserLessonProgressLog>, IUserLessonProgressLogRepo
    {
        private readonly DataContext _context;
        public UserLessonProgressLogRepo(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<UserLessonProgressLog> CreateStartLog(UserLessonProgressLog userLessonProgressLog)
        {
            userLessonProgressLog.OperationIdentifier = Guid.NewGuid();
            userLessonProgressLog.OperationTime = DateTime.Now;
            userLessonProgressLog.IsStart = true;
            await _context.UserLessonProgressLogs.AddAsync(userLessonProgressLog);
            await _context.SaveChangesAsync();
            return userLessonProgressLog;
        }

        public async Task<UserLessonProgressLog> CreateEndLog(UserLessonProgressLog userLessonProgressLog)
        {
            userLessonProgressLog.OperationTime = DateTime.Now;
            userLessonProgressLog.IsStart = false;
            await _context.UserLessonProgressLogs.AddAsync(userLessonProgressLog);
            await _context.SaveChangesAsync();
            return userLessonProgressLog;
        }

        public async Task<UserLessonProgressLog> GetUserLessonLastStartLog(int userId, int lessonId) 
        {
            return await _context.UserLessonProgressLogs.Where(q => q.UserId == userId && q.LessonId == lessonId && q.IsStart == true).OrderByDescending(q => q.Id).FirstOrDefaultAsync();
        }

        public async Task<UserLessonProgressLog> GetUserLessonLastEndLog(int userId, int lessonId)
        {
            return await _context.UserLessonProgressLogs.Where(q => q.UserId == userId && q.LessonId == lessonId && q.IsStart == false).OrderByDescending(q => q.Id).FirstOrDefaultAsync();
        }

        public async Task<UserLessonProgressLog> GetUserLessonEndLogByGuid(Guid operationIdentifier)
        {
            return await _context.UserLessonProgressLogs.Where(q => q.OperationIdentifier == operationIdentifier && q.IsStart == false).FirstOrDefaultAsync();
        }

        public async Task<UserLessonProgressLog> GetUserLessonStartLogByGuid(Guid operationIdentifier)
        {
            return await _context.UserLessonProgressLogs.Where(q => q.OperationIdentifier == operationIdentifier && q.IsStart == true).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<UserLessonProgressLog>> GetUserLessonStartLogs(int userId, int lessonId)
        {
            return await _context.UserLessonProgressLogs.Where(q => q.UserId == userId && q.LessonId == lessonId && q.IsStart == true).ToListAsync();
        }

        public async Task<IEnumerable<UserLessonProgressLog>> GetUserLessonEndLogs(int userId, int lessonId)
        {
            return await _context.UserLessonProgressLogs.Where(q => q.UserId == userId && q.LessonId == lessonId && q.IsStart == false).ToListAsync();
        }

        public async Task<IEnumerable<UserLessonProgressLog>> GetUserLessonLogsGeneral(int userId)
        {
            return await _context.UserLessonProgressLogs.Where(q => q.UserId == userId && q.IsStart == false).ToListAsync();
        }

        public async Task<IEnumerable<UserLessonProgressLog>> GetUserLessonLogsToday(int userId)
        {
            return await _context.UserLessonProgressLogs.Where(q => q.UserId == userId && q.IsStart == false && q.OperationTime.Date == DateTime.Today).ToListAsync();
        }

        public async Task<IEnumerable<object>> GetUserLessonLogsGeneralPre(int userId)
        {
            var result = await _context.UserLessonProgressLogs.Join(_context.Lessons, p => p.LessonId, l => l.Id, (p, l) => new
            {
                p.Id,
                p.UserId,
                p.IsStart,
                p.OperationTime,
                l.ProgressiveRelaxationExercise
            }).ToListAsync();
            return result.Where(q => q.ProgressiveRelaxationExercise == true && q.UserId == userId && q.IsStart == false);
        }

        public async Task<IEnumerable<ReportModel>> GetAllLogs() {
            var userProgresses = await _context.UserLessonProgressLogs.Join(_context.Lessons, p => p.LessonId, l => l.Id, (p, l) => new ReportModel
            {
                Progress = p,
                Lesson = l
            }).Join(_context.SystemUsers, q => q.Progress.UserId, u => u.Id, (q, u) => new ReportModel
            {
                Progress = q.Progress,
                Lesson = q.Lesson,
                UserName = u.UserName
            }).Where(q => q.Progress.IsStart == true).OrderBy(q => q.Progress.UserId).ToListAsync();

            foreach (var progress in userProgresses)
            {
                var evaluationAndAnswers = await _context.UserLessonsEvaluationsQuestionsAnswersTable.Where(q => q.OperationIdentifier == progress.Progress.OperationIdentifier).ToListAsync();

                var firstQuestionData = evaluationAndAnswers.FirstOrDefault();
                Evaluation evaluation = null;

                if (firstQuestionData != null)
                {
                    evaluation = await _context.Evaluations.Where(q => q.Id == firstQuestionData.EvaluationId).FirstOrDefaultAsync();
                }
                if (evaluation != null)
                {
                    progress.EvaluationAndAnswers = evaluationAndAnswers;
                    progress.Evaluation = evaluation;

                    var emptyAnswers = 0;
                    var trueAnswers = 0;
                    var falseAnswers = 0;

                    foreach (var answerInfo in evaluationAndAnswers)
                    {
                        Answer answerRight = null;
                        if (evaluation.IsSurvey == false)
                            answerRight = _context.Answers.Where(q => q.Id == answerInfo.RightAnswerId).FirstOrDefault();
                        var answerGiven = _context.Answers.Where(q => q.Id == answerInfo.AnswerId).FirstOrDefault();

                        progress.AnswerRight.Add(answerRight);
                        progress.GivenAnswers.Add(answerGiven);

                        if (answerGiven == null) emptyAnswers++;
                        else if (answerGiven?.Id == answerRight?.Id) trueAnswers++;
                        else if (answerGiven?.Id != answerRight?.Id) falseAnswers++;

                        var question = _context.Questions.Where(q => q.Id == answerInfo.QuestionId).FirstOrDefault();
                        progress.Questions.Add(question);
                    }

                    progress.Empty = emptyAnswers;
                    if (progress.Evaluation.IsSurvey == false) {
                        progress.TrueAnswers = trueAnswers;
                        progress.FalseAnswers = falseAnswers;
                    }
                }

                progress.StartTime = progress.Progress.OperationTime;
                progress.StrStartTime = ((DateTime)progress.StartTime).ToString("dd/MM/yyyy HH:mm");
                var endProcess = await _context.UserLessonProgressLogs.Where(q => q.OperationIdentifier == progress.Progress.OperationIdentifier && q.IsStart == false).FirstOrDefaultAsync();
                if (endProcess != null) {
                    progress.EndTime = endProcess.OperationTime;
                    progress.StrEndTime = ((DateTime)progress.EndTime).ToString("dd/MM/yyyy HH:mm");
                    TimeSpan span = ((DateTime)progress.EndTime - (DateTime)progress.StartTime);
                    progress.TimeSpend = String.Format("{0} saat, {1} dakika, {2} saniye", span.Hours, span.Minutes, span.Seconds);
                }
            }
            return userProgresses;
        }
    }
}
