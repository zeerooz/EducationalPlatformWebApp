using System;
using System.Collections.Generic;

namespace EducationalPlatformWebApp.Models;

public partial class HealthCondition
{
    public string Condition { get; set; } = null!;

    public int LearnerId { get; set; }

    public int ProfileId { get; set; }

    public virtual PersonalizationProfile PersonalizationProfile { get; set; } = null!;
}
