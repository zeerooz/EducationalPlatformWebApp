using System;
using System.Collections.Generic;

namespace EducationalPlatformWebApp.Models;

public partial class Notification
{
    public int NotificationId { get; set; }

    public DateTime? NotificationTimestamp { get; set; }

    public string? NotficationMessage { get; set; }

    public string? UrgencyLevel { get; set; }

    public virtual ICollection<Learner> Learners { get; set; } = new List<Learner>();
}
