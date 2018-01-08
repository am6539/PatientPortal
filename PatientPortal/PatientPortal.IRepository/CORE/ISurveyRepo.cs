using System.Collections.Generic;
using System.Threading.Tasks;
using PatientPortal.Domain.Models.CORE;

namespace PatientPortal.IRepository.CORE
{
    public interface ISurveyRepo
    {
        Task<IEnumerable<Survey>> Query(Dictionary<string, dynamic> para);
        Task<Survey> SingleQuery(Dictionary<string, dynamic> para);
        Task<IEnumerable<SurveyQuestions>> QuestionsQuery(Dictionary<string, dynamic> para);
        Task<IEnumerable<SurveyAnswers>> AnswersQuery(Dictionary<string, dynamic> para);
        Task<int> Transaction(Survey data, char action);
        Task<int> QuestionTransaction(SurveyQuestions data, char action);
        Task<int> AnswerTransaction(SurveyAnswers data, char action);
    }
}
