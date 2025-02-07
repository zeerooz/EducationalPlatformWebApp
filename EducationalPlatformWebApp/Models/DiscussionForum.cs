using System;
using System.Collections.Generic;

namespace EducationalPlatformWebApp.Models;

public partial class DiscussionForum
{
    public int ForumId { get; set; }

    public int? ModuleId { get; set; }

    public int? CourseId { get; set; }

    public string? FroumTitles { get; set; }

    public DateTime? LastActive { get; set; }

    public DateTime? ForumTimestamp { get; set; }

    public string? ForumDescription { get; set; }

    public virtual ICollection<LearnerDiscussion> LearnerDiscussions { get; set; } = new List<LearnerDiscussion>();

    public virtual Module? Module { get; set; }
}
