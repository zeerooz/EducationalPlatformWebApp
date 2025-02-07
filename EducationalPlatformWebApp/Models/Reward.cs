using System;
using System.Collections.Generic;

namespace EducationalPlatformWebApp.Models;

public partial class Reward
{
    public int RewardId { get; set; }

    public string? RewardValue { get; set; }

    public string? RewardDescription { get; set; }

    public string? RewardType { get; set; }

    public virtual ICollection<QuestReward> QuestRewards { get; set; } = new List<QuestReward>();
}
