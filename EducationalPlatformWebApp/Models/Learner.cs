using System;
using System.Collections.Generic;

namespace EducationalPlatformWebApp.Models;

public partial class Learner
{
    public int LearnerId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Gender { get; set; }

    public DateTime BirthDate { get; set; }

    public string? Country { get; set; }

    public string? CulturalBackground { get; set; }

    public string Email { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public virtual ICollection<Achievement> Achievements { get; set; } = new List<Achievement>();

    public virtual ICollection<CourseEnrollment> CourseEnrollments { get; set; } = new List<CourseEnrollment>();

    public virtual ICollection<EmotionalFeedback> EmotionalFeedbacks { get; set; } = new List<EmotionalFeedback>();

    public virtual ICollection<FilledSurvey> FilledSurveys { get; set; } = new List<FilledSurvey>();

    public virtual ICollection<InteractionLog> InteractionLogs { get; set; } = new List<InteractionLog>();

    public virtual ICollection<LearnerDiscussion> LearnerDiscussions { get; set; } = new List<LearnerDiscussion>();

    public virtual ICollection<LearningPreference> LearningPreferences { get; set; } = new List<LearningPreference>();

    public virtual ICollection<PersonalizationProfile> PersonalizationProfiles { get; set; } = new List<PersonalizationProfile>();

    public virtual ICollection<QuestReward> QuestRewards { get; set; } = new List<QuestReward>();

    public virtual ICollection<Ranking> Rankings { get; set; } = new List<Ranking>();

    public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();

    public virtual ICollection<LearningGoal> Lgs { get; set; } = new List<LearningGoal>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();
}
