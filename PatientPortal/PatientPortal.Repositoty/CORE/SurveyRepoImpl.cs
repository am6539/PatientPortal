using System.Collections.Generic;
using System.Threading.Tasks;
using PatientPortal.DataAccess.Repo.CORE;
using PatientPortal.Domain.Models.CORE;
using PatientPortal.IRepository.CORE;

namespace PatientPortal.Repositoty.CORE
{
    public class SurveyRepoImpl : ISurveyRepo
    {
        private readonly ISurvey _survey;

        public SurveyRepoImpl(ISurvey survey)
        {
            this._survey = survey;
        }

        public async Task<Survey> SingleQuery(Dictionary<string, dynamic> para)
        {
            return await _survey.SingleQuery(para);
        }

        public async Task<IEnumerable<SurveyQuestions>> QuestionsQuery(Dictionary<string, dynamic> para)
        {
            return await _survey.QuestionsQuery(para);
        }

        public async Task<IEnumerable<SurveyAnswers>> AnswersQuery(Dictionary<string, dynamic> para)
        {
            return await _survey.AnswersQuery(para);
        }

        public async Task<IEnumerable<Survey>> Query(Dictionary<string, dynamic> para)
        {
            return await _survey.Query(para);
        }

        public async Task<int> Transaction(Survey data, char action)
        {
            return await _survey.Transaction(data, action);
        }

        public async Task<int> QuestionTransaction(SurveyQuestions data, char action)
        {
            return await _survey.QuestionTransaction(data, action);
        }

        public async Task<int> AnswerTransaction(SurveyAnswers data, char action)
        {
            return await _survey.AnswerTransaction(data, action);
        }
    }
}
