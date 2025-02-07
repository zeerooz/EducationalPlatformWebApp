using System;
using System.Collections.Generic;

namespace EducationalPlatformWebApp.Models;

public partial class Survey
{
    public int SurveyId { get; set; }

    public string? SurveyTitle { get; set; }

    public virtual ICollection<Surveyquestion> Surveyquestions { get; set; } = new List<Surveyquestion>();
}
