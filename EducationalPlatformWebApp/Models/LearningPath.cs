﻿using System;
using System.Collections.Generic;

namespace EducationalPlatformWebApp.Models;

public partial class LearningPath
{
    public int PathId { get; set; }

    public int? LearnerId { get; set; }

    public int? ProfileId { get; set; }

    public string? CompletionStatus { get; set; }

    public string? CustomContent { get; set; }

    public string? AdaptiveRules { get; set; }

    public virtual ICollection<Pathreview> Pathreviews { get; set; } = new List<Pathreview>();

    public virtual PersonalizationProfile? PersonalizationProfile { get; set; }
}
