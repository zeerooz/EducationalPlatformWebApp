namespace EducationalPlatformWebApp.Models
{
    public class AssessmentWithCreditPointsModel
    {
        public int CourseID { get; set; }
        public string CourseTitle { get; set; }
        public int AssessmentID { get; set; }
        public string AssessmentTitle { get; set; }
        public int TotalMarks { get; set; }
        public int CreditPoints { get; set; }
    }
}
