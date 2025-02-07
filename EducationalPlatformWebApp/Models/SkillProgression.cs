using System;
using System.Collections.Generic;

namespace EducationalPlatformWebApp.Models;

public partial class SkillProgression
{
    public int SkillProgressionId { get; set; }

    public string? ProficiencyLevel { get; set; }

    public string? Skill { get; set; }

    public int? LearnerId { get; set; }

    public DateTime? SkillProgressionTimestamp { get; set; }

    public virtual Skill? SkillNavigation { get; set; }
}
