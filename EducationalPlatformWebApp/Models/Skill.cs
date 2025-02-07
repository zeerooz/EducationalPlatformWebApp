using System;
using System.Collections.Generic;

namespace EducationalPlatformWebApp.Models;

public partial class Skill
{
    public string Skill1 { get; set; } = null!;

    public int LearnerId { get; set; }

    public virtual Learner Learner { get; set; } = null!;

    public virtual ICollection<SkillProgression> SkillProgressions { get; set; } = new List<SkillProgression>();
}
