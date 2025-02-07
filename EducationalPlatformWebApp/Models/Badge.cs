using System;
using System.Collections.Generic;

namespace EducationalPlatformWebApp.Models;

public partial class Badge
{
    public int BadgeId { get; set; }

    public string? BadgeTitle { get; set; }

    public string? BadgeDescription { get; set; }

    public string? BadgeCriteria { get; set; }

    public int? BadgePoints { get; set; }

    public virtual ICollection<Achievement> Achievements { get; set; } = new List<Achievement>();
}
