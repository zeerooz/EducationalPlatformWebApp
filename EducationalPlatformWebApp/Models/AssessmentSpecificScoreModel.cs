namespace EducationalPlatformWebApp.Models
{
    public class AssessmentSpecificScoreModel
    {
        public int AssessmentID { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public int TotalMarks { get; set; }
        public int Score { get; set; }
        public int LearnerID { get; set; }
    }
}
