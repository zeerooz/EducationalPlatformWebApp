using System;
using System.Collections.Generic;

namespace EducationalPlatformWebApp.Models;

public partial class Surveyquestion
{
    public int SurveyId { get; set; }

    public string Questions { get; set; } = null!;

    public virtual ICollection<FilledSurvey> FilledSurveys { get; set; } = new List<FilledSurvey>();

    public virtual Survey Survey { get; set; } = null!;
}
