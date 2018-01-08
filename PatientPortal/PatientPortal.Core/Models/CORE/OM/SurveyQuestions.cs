namespace PatientPortal.Domain.Models.CORE
{
    public class SurveyQuestions
    {
        public string Id { get; set; }
        public string SurveyId { get; set; }
        public string Question { get; set; }
        public byte Type { get; set; }
        public bool IsRequireds { get; set; }
        public bool IsRandomize { get; set; }
    }
}