using System;
using System.Collections.Generic;

namespace EducationalPlatformWebApp.Models;

public partial class Quest
{
    public int QuestId { get; set; }

    public int? QuestDifficultyLevel { get; set; }

    public string? QuestCriteria { get; set; }

    public string? QuestDescriptions { get; set; }

    public string? QuestTitle { get; set; }

    public virtual Collaborative? Collaborative { get; set; }

    public virtual ICollection<QuestReward> QuestRewards { get; set; } = new List<QuestReward>();

    public virtual ICollection<SkillMastery> SkillMasteries { get; set; } = new List<SkillMastery>();
}
