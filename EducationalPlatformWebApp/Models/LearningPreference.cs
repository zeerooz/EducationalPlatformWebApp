using System;
using System.Collections.Generic;

namespace EducationalPlatformWebApp.Models;

public partial class LearningPreference
{
    public string Preference { get; set; } = null!;

    public int LearnerId { get; set; }

    public virtual Learner Learner { get; set; } = null!;
}
