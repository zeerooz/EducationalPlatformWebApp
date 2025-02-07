using System;
using System.Collections.Generic;

namespace EducationalPlatformWebApp.Models;

public partial class LearningGoal
{
    public int LgId { get; set; }

    public string? LgStatus { get; set; }

    public DateTime? LgDeadline { get; set; }

    public string? LgDescription { get; set; }

    public virtual ICollection<Learner> Learners { get; set; } = new List<Learner>();
}
