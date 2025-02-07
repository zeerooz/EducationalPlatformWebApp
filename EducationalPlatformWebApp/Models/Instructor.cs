using System;
using System.Collections.Generic;

namespace EducationalPlatformWebApp.Models;

public partial class Instructor
{
    public int InstructorId { get; set; }

    public string? InstructorName { get; set; }

    public string? LatestQualification { get; set; }

    public string? ExpertiseArea { get; set; }

    public string Email { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public virtual ICollection<EmotionalfeedbackReview> EmotionalfeedbackReviews { get; set; } = new List<EmotionalfeedbackReview>();

    public virtual ICollection<Pathreview> Pathreviews { get; set; } = new List<Pathreview>();

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
