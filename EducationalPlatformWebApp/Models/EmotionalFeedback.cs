using System;
using System.Collections.Generic;

namespace EducationalPlatformWebApp.Models;

public partial class EmotionalFeedback
{
    public int FeedbackId { get; set; }

    public int? LearnerId { get; set; }

    public DateTime EfTimestamp { get; set; }

    public string? EmotionalState { get; set; }

    public virtual ICollection<EmotionalfeedbackReview> EmotionalfeedbackReviews { get; set; } = new List<EmotionalfeedbackReview>();

    public virtual Learner? Learner { get; set; }
}
