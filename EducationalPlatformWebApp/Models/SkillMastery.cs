using System;
using System.Collections.Generic;

namespace EducationalPlatformWebApp.Models;

public partial class SkillMastery
{
    public int QuestId { get; set; }

    public string SkillM { get; set; } = null!;

    public virtual Quest Quest { get; set; } = null!;
}
