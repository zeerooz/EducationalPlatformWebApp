using System;
using System.Collections.Generic;

namespace EducationalPlatformWebApp.Models;

public partial class FilledSurvey
{
    public int SurveyId { get; set; }

    public string Questions { get; set; } = null!;

    public int LearnerId { get; set; }

    public string? Answer { get; set; }

    public virtual Learner Learner { get; set; } = null!;

    public virtual Surveyquestion Surveyquestion { get; set; } = null!;
}
