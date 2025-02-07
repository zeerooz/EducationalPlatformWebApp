using System;
using System.Collections.Generic;

namespace EducationalPlatformWebApp.Models;

public partial class Achievement
{
    public int AchievementId { get; set; }

    public int? BadgeId { get; set; }

    public int? LearnerId { get; set; }

    public string? AchievementDescription { get; set; }

    public DateOnly? AchievemrnDateEarned { get; set; }

    public string? AchievementType { get; set; }

    public virtual Badge? Badge { get; set; }

    public virtual Learner? Learner { get; set; }
}
