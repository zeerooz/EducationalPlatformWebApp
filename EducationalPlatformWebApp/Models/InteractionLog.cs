using System;
using System.Collections.Generic;

namespace EducationalPlatformWebApp.Models;

public partial class InteractionLog
{
    public int LogId { get; set; }

    public int? LearnerId { get; set; }

    public int? ActivityId { get; set; }

    public TimeOnly? InteractionLogDuration { get; set; }

    public DateTime LogTimestamp { get; set; }

    public string? ActionType { get; set; }

    public virtual LearningActivity? Activity { get; set; }

    public virtual Learner? Learner { get; set; }
}
