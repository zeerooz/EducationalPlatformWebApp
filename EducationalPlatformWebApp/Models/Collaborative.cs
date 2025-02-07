using System;
using System.Collections.Generic;

namespace EducationalPlatformWebApp.Models;

public partial class Collaborative
{
    public int QuestId { get; set; }

    public DateTime? CollaborativeDeadline { get; set; }

    public int? MaxNumParticipants { get; set; }

    public virtual Quest Quest { get; set; } = null!;
}
