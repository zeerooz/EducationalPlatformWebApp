namespace EducationalPlatformWebApp.Models
{
    public class AssessmentScoreBreakdownModel
    {
        public int AssessmentID { get; set; }    // ID of the assessment
        public string Title { get; set; }        // Title of the assessment
        public string Type { get; set; }         // Type of the assessment
        public int TotalMarks { get; set; }      // Total marks for the assessment
        public int Score { get; set; }           // Score achieved by the learner
    }
}
