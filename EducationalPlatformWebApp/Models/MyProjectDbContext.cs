using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EducationalPlatformWebApp.Models;

public partial class MyProjectDbContext : DbContext
{
    public MyProjectDbContext()
    {
    }

    public MyProjectDbContext(DbContextOptions<MyProjectDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Achievement> Achievements { get; set; }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Assessment> Assessments { get; set; }

    public virtual DbSet<Badge> Badges { get; set; }

    public virtual DbSet<Collaborative> Collaboratives { get; set; }

    public virtual DbSet<ContentLibrary> ContentLibraries { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CourseEnrollment> CourseEnrollments { get; set; }

    public virtual DbSet<DiscussionForum> DiscussionForums { get; set; }

    public virtual DbSet<EmotionalFeedback> EmotionalFeedbacks { get; set; }

    public virtual DbSet<EmotionalfeedbackReview> EmotionalfeedbackReviews { get; set; }

    public virtual DbSet<FilledSurvey> FilledSurveys { get; set; }

    public virtual DbSet<HealthCondition> HealthConditions { get; set; }

    public virtual DbSet<Instructor> Instructors { get; set; }

    public virtual DbSet<InteractionLog> InteractionLogs { get; set; }

    public virtual DbSet<Leaderboard> Leaderboards { get; set; }

    public virtual DbSet<Learner> Learners { get; set; }

    public virtual DbSet<LearnerDiscussion> LearnerDiscussions { get; set; }

    public virtual DbSet<LearningActivity> LearningActivities { get; set; }

    public virtual DbSet<LearningGoal> LearningGoals { get; set; }

    public virtual DbSet<LearningPath> LearningPaths { get; set; }

    public virtual DbSet<LearningPreference> LearningPreferences { get; set; }

    public virtual DbSet<Module> Modules { get; set; }

    public virtual DbSet<ModuleContent> ModuleContents { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Pathreview> Pathreviews { get; set; }

    public virtual DbSet<PersonalizationProfile> PersonalizationProfiles { get; set; }

    public virtual DbSet<Quest> Quests { get; set; }

    public virtual DbSet<QuestReward> QuestRewards { get; set; }

    public virtual DbSet<Ranking> Rankings { get; set; }

    public virtual DbSet<Reward> Rewards { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<SkillMastery> SkillMasteries { get; set; }

    public virtual DbSet<SkillProgression> SkillProgressions { get; set; }

    public virtual DbSet<Survey> Surveys { get; set; }

    public virtual DbSet<Surveyquestion> Surveyquestions { get; set; }

    public virtual DbSet<TargetTrait> TargetTraits { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MyProjectDB;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Achievement>(entity =>
        {
            entity.HasKey(e => e.AchievementId).HasName("PK__Achievem__276330E0411DD8B2");

            entity.ToTable("Achievement");

            entity.Property(e => e.AchievementId).HasColumnName("AchievementID");
            entity.Property(e => e.AchievementDescription)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("achievement_description");
            entity.Property(e => e.AchievementType)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("achievement_type");
            entity.Property(e => e.AchievemrnDateEarned).HasColumnName("achievemrn_date_earned");
            entity.Property(e => e.BadgeId).HasColumnName("BadgeID");
            entity.Property(e => e.LearnerId).HasColumnName("LearnerID");

            entity.HasOne(d => d.Badge).WithMany(p => p.Achievements)
                .HasForeignKey(d => d.BadgeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Achieveme__Badge__52793849");

            entity.HasOne(d => d.Learner).WithMany(p => p.Achievements)
                .HasForeignKey(d => d.LearnerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Achieveme__Learn__536D5C82");
        });

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__Admins__719FE4E890C9E025");

            entity.HasIndex(e => e.Email, "UQ__Admins__AB6E6164F572A44C").IsUnique();

            entity.Property(e => e.AdminId).HasColumnName("AdminID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("Admin")
                .HasColumnName("first_name");
            entity.Property(e => e.UserPassword)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("user_password");
        });

        modelBuilder.Entity<Assessment>(entity =>
        {
            entity.HasKey(e => e.AssessmentsId).HasName("PK__Assessme__7C21BF96DA2FAD05");

            entity.Property(e => e.AssessmentsId).HasColumnName("AssessmentsID");
            entity.Property(e => e.AssessmentsCriteria)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Assessments_criteria");
            entity.Property(e => e.AssessmentsDescriptioin)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Assessments_descriptioin");
            entity.Property(e => e.AssessmentsTitle)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Assessments_title");
            entity.Property(e => e.AssessmentsType)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Assessments_type");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.ModuleId).HasColumnName("ModuleID");
            entity.Property(e => e.PassingMarks).HasColumnName("passing_marks");
            entity.Property(e => e.TotalMarks).HasColumnName("total_marks");
            entity.Property(e => e.Weightage).HasColumnName("weightage");

            entity.HasOne(d => d.Module).WithMany(p => p.Assessments)
                .HasForeignKey(d => new { d.ModuleId, d.CourseId })
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Assessments__119F9925");
        });

        modelBuilder.Entity<Badge>(entity =>
        {
            entity.HasKey(e => e.BadgeId).HasName("PK__Badge__1918237C7412EE4D");

            entity.ToTable("Badge");

            entity.Property(e => e.BadgeId).HasColumnName("BadgeID");
            entity.Property(e => e.BadgeCriteria)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Badge_criteria");
            entity.Property(e => e.BadgeDescription)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Badge_description");
            entity.Property(e => e.BadgePoints).HasColumnName("Badge_points");
            entity.Property(e => e.BadgeTitle)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Badge_title");
        });

        modelBuilder.Entity<Collaborative>(entity =>
        {
            entity.HasKey(e => e.QuestId).HasName("PK__Collabor__B6619ACB5B263D35");

            entity.ToTable("Collaborative");

            entity.Property(e => e.QuestId)
                .ValueGeneratedNever()
                .HasColumnName("QuestID");
            entity.Property(e => e.CollaborativeDeadline)
                .HasColumnType("datetime")
                .HasColumnName("Collaborative_deadline");
            entity.Property(e => e.MaxNumParticipants).HasColumnName("max_num_participants");

            entity.HasOne(d => d.Quest).WithOne(p => p.Collaborative)
                .HasForeignKey<Collaborative>(d => d.QuestId)
                .HasConstraintName("FK__Collabora__Quest__5CF6C6BC");
        });

        modelBuilder.Entity<ContentLibrary>(entity =>
        {
            entity.HasKey(e => e.ContentLibraryId).HasName("PK__ContentL__2EC578EDF4A8EBD1");

            entity.ToTable("ContentLibrary");

            entity.Property(e => e.ContentLibraryId).HasColumnName("ContentLibraryID");
            entity.Property(e => e.ContentLibraryContentUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ContentLibrary_ContentUrl");
            entity.Property(e => e.ContentLibraryDescreption)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ContentLibrary_Descreption");
            entity.Property(e => e.ContentLibraryTitle)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ContentLibrary_Title");
            entity.Property(e => e.ContentLibraryType)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ContentLibrary_type");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.Metadata)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("metadata");
            entity.Property(e => e.ModuleId).HasColumnName("ModuleID");

            entity.HasOne(d => d.Module).WithMany(p => p.ContentLibraries)
                .HasForeignKey(d => new { d.ModuleId, d.CourseId })
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__ContentLibrary__0EC32C7A");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__Courses__C92D7187D9469483");

            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.CourseDescription)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("course_description");
            entity.Property(e => e.CourseTitle)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Course_Title");
            entity.Property(e => e.CreditPoints).HasColumnName("credit_points");
            entity.Property(e => e.DifficultyLevel).HasColumnName("difficulty_level");
            entity.Property(e => e.LearningObjective)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("learning_objective");
            entity.Property(e => e.PreRequisites)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("pre_requisites");
        });

        modelBuilder.Entity<CourseEnrollment>(entity =>
        {
            entity.HasKey(e => e.EnrollmentId).HasName("PK__Course_e__7F6877FB3C341A54");

            entity.ToTable("Course_enrollment");

            entity.Property(e => e.EnrollmentId).HasColumnName("EnrollmentID");
            entity.Property(e => e.CeStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CE_STATUS");
            entity.Property(e => e.CompletionDate).HasColumnName("completion_date");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.EnrollmentDate).HasColumnName("enrollment_date");
            entity.Property(e => e.LearnerId).HasColumnName("LearnerID");

            entity.HasOne(d => d.Course).WithMany(p => p.CourseEnrollments)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Course_en__Cours__2B5F6B28");

            entity.HasOne(d => d.Learner).WithMany(p => p.CourseEnrollments)
                .HasForeignKey(d => d.LearnerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Course_en__Learn__2C538F61");
        });

        modelBuilder.Entity<DiscussionForum>(entity =>
        {
            entity.HasKey(e => e.ForumId).HasName("PK__Discussi__E210AC4F94E6A1D0");

            entity.ToTable("DiscussionForum");

            entity.Property(e => e.ForumId).HasColumnName("ForumID");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.ForumDescription)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("forum_description");
            entity.Property(e => e.ForumTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("forum_timestamp");
            entity.Property(e => e.FroumTitles)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("froum_titles");
            entity.Property(e => e.LastActive)
                .HasColumnType("datetime")
                .HasColumnName("last_active");
            entity.Property(e => e.ModuleId).HasColumnName("ModuleID");

            entity.HasOne(d => d.Module).WithMany(p => p.DiscussionForums)
                .HasForeignKey(d => new { d.ModuleId, d.CourseId })
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__DiscussionForum__5FD33367");
        });

        modelBuilder.Entity<EmotionalFeedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__Emotiona__6A4BEDF6158BF850");

            entity.ToTable("Emotional_feedback");

            entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID");
            entity.Property(e => e.EfTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("EF_Timestamp");
            entity.Property(e => e.EmotionalState)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("emotional_state");
            entity.Property(e => e.LearnerId).HasColumnName("LearnerID");

            entity.HasOne(d => d.Learner).WithMany(p => p.EmotionalFeedbacks)
                .HasForeignKey(d => d.LearnerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Emotional__Learn__1B29035F");
        });

        modelBuilder.Entity<EmotionalfeedbackReview>(entity =>
        {
            entity.HasKey(e => new { e.FeedbackId, e.InstructorId }).HasName("PK__Emotiona__C39BFD417681C813");

            entity.ToTable("Emotionalfeedback_review");

            entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID");
            entity.Property(e => e.InstructorId).HasColumnName("InstructorID");
            entity.Property(e => e.EfFeedback)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EF_feedback");

            entity.HasOne(d => d.Feedback).WithMany(p => p.EmotionalfeedbackReviews)
                .HasForeignKey(d => d.FeedbackId)
                .HasConstraintName("FK__Emotional__Feedb__278EDA44");

            entity.HasOne(d => d.Instructor).WithMany(p => p.EmotionalfeedbackReviews)
                .HasForeignKey(d => d.InstructorId)
                .HasConstraintName("FK__Emotional__Instr__2882FE7D");
        });

        modelBuilder.Entity<FilledSurvey>(entity =>
        {
            entity.HasKey(e => new { e.SurveyId, e.Questions, e.LearnerId }).HasName("PK__FilledSu__0CC739071F07634F");

            entity.ToTable("FilledSurvey");

            entity.Property(e => e.SurveyId).HasColumnName("SurveyID");
            entity.Property(e => e.Questions)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LearnerId).HasColumnName("LearnerID");
            entity.Property(e => e.Answer)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Learner).WithMany(p => p.FilledSurveys)
                .HasForeignKey(d => d.LearnerId)
                .HasConstraintName("FK__FilledSur__Learn__451F3D2B");

            entity.HasOne(d => d.Surveyquestion).WithMany(p => p.FilledSurveys)
                .HasForeignKey(d => new { d.SurveyId, d.Questions })
                .HasConstraintName("FK__FilledSurvey__442B18F2");
        });

        modelBuilder.Entity<HealthCondition>(entity =>
        {
            entity.HasKey(e => new { e.Condition, e.LearnerId, e.ProfileId }).HasName("PK__HealthCo__A1919FFEDCC5BF0D");

            entity.Property(e => e.Condition)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LearnerId).HasColumnName("LearnerID");
            entity.Property(e => e.ProfileId).HasColumnName("Profile_ID");

            entity.HasOne(d => d.PersonalizationProfile).WithMany(p => p.HealthConditions)
                .HasForeignKey(d => new { d.ProfileId, d.LearnerId })
                .HasConstraintName("FK__HealthConditions__0169315C");
        });

        modelBuilder.Entity<Instructor>(entity =>
        {
            entity.HasKey(e => e.InstructorId).HasName("PK__Instruct__9D010B7BEB38CCB3");

            entity.ToTable("Instructor");

            entity.HasIndex(e => e.Email, "UQ__Instruct__AB6E6164B04C299A").IsUnique();

            entity.Property(e => e.InstructorId).HasColumnName("InstructorID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.ExpertiseArea)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("expertise_area");
            entity.Property(e => e.InstructorName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Instructor_name");
            entity.Property(e => e.LatestQualification)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("latest_qualification");
            entity.Property(e => e.UserPassword)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("user_password");

            entity.HasMany(d => d.Courses).WithMany(p => p.Instructors)
                .UsingEntity<Dictionary<string, object>>(
                    "Teach",
                    r => r.HasOne<Course>().WithMany()
                        .HasForeignKey("CourseId")
                        .HasConstraintName("FK__Teaches__CourseI__30242045"),
                    l => l.HasOne<Instructor>().WithMany()
                        .HasForeignKey("InstructorId")
                        .HasConstraintName("FK__Teaches__Instruc__2F2FFC0C"),
                    j =>
                    {
                        j.HasKey("InstructorId", "CourseId").HasName("PK__Teaches__F193DC63109F81F5");
                        j.ToTable("Teaches");
                        j.IndexerProperty<int>("InstructorId").HasColumnName("InstructorID");
                        j.IndexerProperty<int>("CourseId").HasColumnName("CourseID");
                    });
        });

        modelBuilder.Entity<InteractionLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__Interact__5E5499A85EF5AC0B");

            entity.ToTable("Interaction_log");

            entity.Property(e => e.LogId).HasColumnName("LogID");
            entity.Property(e => e.ActionType)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("action_type");
            entity.Property(e => e.ActivityId).HasColumnName("ActivityID");
            entity.Property(e => e.InteractionLogDuration).HasColumnName("Interaction_log_Duration");
            entity.Property(e => e.LearnerId).HasColumnName("LearnerID");
            entity.Property(e => e.LogTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("Log_Timestamp");

            entity.HasOne(d => d.Activity).WithMany(p => p.InteractionLogs)
                .HasForeignKey(d => d.ActivityId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Interacti__Activ__184C96B4");

            entity.HasOne(d => d.Learner).WithMany(p => p.InteractionLogs)
                .HasForeignKey(d => d.LearnerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Interacti__Learn__1758727B");
        });

        modelBuilder.Entity<Leaderboard>(entity =>
        {
            entity.HasKey(e => e.BoardId).HasName("PK__Leaderbo__F9646BD2AB651F76");

            entity.ToTable("Leaderboard");

            entity.Property(e => e.BoardId).HasColumnName("BoardID");
            entity.Property(e => e.Season)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Learner>(entity =>
        {
            entity.HasKey(e => e.LearnerId).HasName("PK__Learner__67ABFCFAF4916CCD");

            entity.ToTable("Learner");

            entity.HasIndex(e => e.Email, "UQ__Learner__AB6E6164BC08DAFF").IsUnique();

            entity.Property(e => e.LearnerId).HasColumnName("LearnerID");
            entity.Property(e => e.BirthDate).HasColumnName("birth_date");
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.CulturalBackground)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cultural_background");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("Learner")
                .HasColumnName("first_name");
            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.UserPassword)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("user_password");

            entity.HasMany(d => d.Lgs).WithMany(p => p.Learners)
                .UsingEntity<Dictionary<string, object>>(
                    "LearnersGoal",
                    r => r.HasOne<LearningGoal>().WithMany()
                        .HasForeignKey("LgId")
                        .HasConstraintName("FK__LearnersG__LG_ID__3B95D2F1"),
                    l => l.HasOne<Learner>().WithMany()
                        .HasForeignKey("LearnerId")
                        .HasConstraintName("FK__LearnersG__Learn__3C89F72A"),
                    j =>
                    {
                        j.HasKey("LearnerId", "LgId").HasName("PK__Learners__3B841DE14B4D559E");
                        j.ToTable("LearnersGoals");
                        j.IndexerProperty<int>("LearnerId").HasColumnName("LearnerID");
                        j.IndexerProperty<int>("LgId").HasColumnName("LG_ID");
                    });
        });

        modelBuilder.Entity<LearnerDiscussion>(entity =>
        {
            entity.HasKey(e => new { e.ForumId, e.LearnerId, e.Post }).HasName("PK__LearnerD__FBCECC4A5BF3A873");

            entity.ToTable("LearnerDiscussion");

            entity.Property(e => e.ForumId).HasColumnName("ForumID");
            entity.Property(e => e.LearnerId).HasColumnName("LearnerID");
            entity.Property(e => e.Post)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DiscussionTime).HasColumnName("discussion_time");

            entity.HasOne(d => d.Forum).WithMany(p => p.LearnerDiscussions)
                .HasForeignKey(d => d.ForumId)
                .HasConstraintName("FK__LearnerDi__Forum__62AFA012");

            entity.HasOne(d => d.Learner).WithMany(p => p.LearnerDiscussions)
                .HasForeignKey(d => d.LearnerId)
                .HasConstraintName("FK__LearnerDi__Learn__63A3C44B");
        });

        modelBuilder.Entity<LearningActivity>(entity =>
        {
            entity.HasKey(e => e.ActivityId).HasName("PK__Learning__45F4A7F1DF488D47");

            entity.ToTable("Learning_activities");

            entity.Property(e => e.ActivityId).HasColumnName("ActivityID");
            entity.Property(e => e.ActivityType)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("activity_type");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.InstructionDetails)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("instruction_details");
            entity.Property(e => e.MaxPoints).HasColumnName("Max_points");
            entity.Property(e => e.ModuleId).HasColumnName("ModuleID");

            entity.HasOne(d => d.Module).WithMany(p => p.LearningActivities)
                .HasForeignKey(d => new { d.ModuleId, d.CourseId })
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Learning_activit__147C05D0");
        });

        modelBuilder.Entity<LearningGoal>(entity =>
        {
            entity.HasKey(e => e.LgId).HasName("PK__Learning__C2FE11B4F13A4A6D");

            entity.ToTable("Learning_goal");

            entity.Property(e => e.LgId).HasColumnName("LG_ID");
            entity.Property(e => e.LgDeadline)
                .HasColumnType("datetime")
                .HasColumnName("LG_deadline");
            entity.Property(e => e.LgDescription)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LG_description");
            entity.Property(e => e.LgStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LG_status");
        });

        modelBuilder.Entity<LearningPath>(entity =>
        {
            entity.HasKey(e => e.PathId).HasName("PK__Learning__CD67DC3953203579");

            entity.ToTable("LearningPath");

            entity.Property(e => e.PathId).HasColumnName("PathID");
            entity.Property(e => e.AdaptiveRules)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("adaptive_rules");
            entity.Property(e => e.CompletionStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("completion_status");
            entity.Property(e => e.CustomContent)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("custom_content");
            entity.Property(e => e.LearnerId).HasColumnName("LearnerID");
            entity.Property(e => e.ProfileId).HasColumnName("Profile_ID");

            entity.HasOne(d => d.PersonalizationProfile).WithMany(p => p.LearningPaths)
                .HasForeignKey(d => new { d.ProfileId, d.LearnerId })
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__LearningPath__1E05700A");
        });

        modelBuilder.Entity<LearningPreference>(entity =>
        {
            entity.HasKey(e => new { e.LearnerId, e.Preference }).HasName("PK__Learning__BD13C947956352C5");

            entity.ToTable("LearningPreference");

            entity.Property(e => e.LearnerId).HasColumnName("LearnerID");
            entity.Property(e => e.Preference)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Learner).WithMany(p => p.LearningPreferences)
                .HasForeignKey(d => d.LearnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LearningP__Learn__7BB05806");
        });

        modelBuilder.Entity<Module>(entity =>
        {
            entity.HasKey(e => new { e.ModuleId, e.CourseId }).HasName("PK__Modules__47E6A09F8BD80EAD");

            entity.Property(e => e.ModuleId).HasColumnName("ModuleID");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.ModuleContentUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Module_contentURL");
            entity.Property(e => e.ModuleDifficulty)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Module_difficulty");
            entity.Property(e => e.ModuleTitle)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Module_Title");

            entity.HasOne(d => d.Course).WithMany(p => p.Modules)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Modules__CourseI__062DE679");
        });

        modelBuilder.Entity<ModuleContent>(entity =>
        {
            entity.HasKey(e => new { e.CourseId, e.ModuleId, e.ModulecontentType }).HasName("PK__ModuleCo__E1C0997036653CFF");

            entity.ToTable("ModuleContent");

            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.ModuleId).HasColumnName("ModuleID");
            entity.Property(e => e.ModulecontentType)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Modulecontent_type");

            entity.HasOne(d => d.Module).WithMany(p => p.ModuleContents)
                .HasForeignKey(d => new { d.ModuleId, d.CourseId })
                .HasConstraintName("FK__ModuleContent__0BE6BFCF");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK__Notifica__20CF2E320C8EE133");

            entity.Property(e => e.NotificationId).HasColumnName("NotificationID");
            entity.Property(e => e.NotficationMessage)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Notfication_message");
            entity.Property(e => e.NotificationTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("Notification_timestamp");
            entity.Property(e => e.UrgencyLevel)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("urgency_level");

            entity.HasMany(d => d.Learners).WithMany(p => p.Notifications)
                .UsingEntity<Dictionary<string, object>>(
                    "ReceivedNotification",
                    r => r.HasOne<Learner>().WithMany()
                        .HasForeignKey("LearnerId")
                        .HasConstraintName("FK__ReceivedN__Learn__4AD81681"),
                    l => l.HasOne<Notification>().WithMany()
                        .HasForeignKey("NotificationId")
                        .HasConstraintName("FK__ReceivedN__Notif__49E3F248"),
                    j =>
                    {
                        j.HasKey("NotificationId", "LearnerId").HasName("PK__Received__96B591FD64ACA698");
                        j.ToTable("ReceivedNotification");
                        j.IndexerProperty<int>("NotificationId").HasColumnName("NotificationID");
                        j.IndexerProperty<int>("LearnerId").HasColumnName("LearnerID");
                    });
        });

        modelBuilder.Entity<Pathreview>(entity =>
        {
            entity.HasKey(e => new { e.InstructorId, e.PathId }).HasName("PK__Pathrevi__11D776B802EC28C3");

            entity.ToTable("Pathreview");

            entity.Property(e => e.InstructorId).HasColumnName("InstructorID");
            entity.Property(e => e.PathId).HasColumnName("PathID");
            entity.Property(e => e.PathreviewFeedback)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pathreview_feedback");

            entity.HasOne(d => d.Instructor).WithMany(p => p.Pathreviews)
                .HasForeignKey(d => d.InstructorId)
                .HasConstraintName("FK__Pathrevie__Instr__23BE4960");

            entity.HasOne(d => d.Path).WithMany(p => p.Pathreviews)
                .HasForeignKey(d => d.PathId)
                .HasConstraintName("FK__Pathrevie__PathI__24B26D99");
        });

        modelBuilder.Entity<PersonalizationProfile>(entity =>
        {
            entity.HasKey(e => new { e.ProfileId, e.LearnerId }).HasName("PK__Personal__1074756D3605F152");

            entity.Property(e => e.ProfileId).HasColumnName("Profile_ID");
            entity.Property(e => e.LearnerId).HasColumnName("LearnerID");
            entity.Property(e => e.EmotionalState)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("emotional_state");
            entity.Property(e => e.PersonalityType)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("personality_type");
            entity.Property(e => e.PreferedContentType)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Prefered_content_type");

            entity.HasOne(d => d.Learner).WithMany(p => p.PersonalizationProfiles)
                .HasForeignKey(d => d.LearnerId)
                .HasConstraintName("FK__Personali__Learn__7E8CC4B1");
        });

        modelBuilder.Entity<Quest>(entity =>
        {
            entity.HasKey(e => e.QuestId).HasName("PK__Quest__B6619ACB775979F7");

            entity.ToTable("Quest");

            entity.Property(e => e.QuestId).HasColumnName("QuestID");
            entity.Property(e => e.QuestCriteria)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("quest_criteria");
            entity.Property(e => e.QuestDescriptions)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("quest_descriptions");
            entity.Property(e => e.QuestDifficultyLevel).HasColumnName("quest_difficulty_level");
            entity.Property(e => e.QuestTitle)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("quest_title");
        });

        modelBuilder.Entity<QuestReward>(entity =>
        {
            entity.HasKey(e => new { e.RewardId, e.QuestId, e.LearnerId }).HasName("PK__QuestRew__D251A7C9A5AA890B");

            entity.ToTable("QuestReward");

            entity.Property(e => e.RewardId).HasColumnName("RewardID");
            entity.Property(e => e.QuestId).HasColumnName("QuestID");
            entity.Property(e => e.LearnerId).HasColumnName("LearnerID");
            entity.Property(e => e.TimeEarned).HasColumnName("Time_earned");

            entity.HasOne(d => d.Learner).WithMany(p => p.QuestRewards)
                .HasForeignKey(d => d.LearnerId)
                .HasConstraintName("FK__QuestRewa__Learn__68687968");

            entity.HasOne(d => d.Quest).WithMany(p => p.QuestRewards)
                .HasForeignKey(d => d.QuestId)
                .HasConstraintName("FK__QuestRewa__Quest__6774552F");

            entity.HasOne(d => d.Reward).WithMany(p => p.QuestRewards)
                .HasForeignKey(d => d.RewardId)
                .HasConstraintName("FK__QuestRewa__Rewar__668030F6");
        });

        modelBuilder.Entity<Ranking>(entity =>
        {
            entity.HasKey(e => new { e.BoardId, e.LearnerId }).HasName("PK__Ranking__4F1ED41DECFD2435");

            entity.ToTable("Ranking");

            entity.Property(e => e.BoardId).HasColumnName("BoardID");
            entity.Property(e => e.LearnerId).HasColumnName("LearnerID");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.Rank).HasColumnName("rank");
            entity.Property(e => e.TotalPoints).HasColumnName("total_points");

            entity.HasOne(d => d.Board).WithMany(p => p.Rankings)
                .HasForeignKey(d => d.BoardId)
                .HasConstraintName("FK__Ranking__BoardID__34E8D562");

            entity.HasOne(d => d.Course).WithMany(p => p.Rankings)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Ranking__CourseI__36D11DD4");

            entity.HasOne(d => d.Learner).WithMany(p => p.Rankings)
                .HasForeignKey(d => d.LearnerId)
                .HasConstraintName("FK__Ranking__Learner__35DCF99B");
        });

        modelBuilder.Entity<Reward>(entity =>
        {
            entity.HasKey(e => e.RewardId).HasName("PK__Reward__8250159985592545");

            entity.ToTable("Reward");

            entity.Property(e => e.RewardId).HasColumnName("RewardID");
            entity.Property(e => e.RewardDescription)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Reward_description");
            entity.Property(e => e.RewardType)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Reward_type");
            entity.Property(e => e.RewardValue)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Reward_value");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => new { e.Skill1, e.LearnerId }).HasName("PK__Skills__89789A349CE0E347");

            entity.Property(e => e.Skill1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("skill");
            entity.Property(e => e.LearnerId).HasColumnName("LearnerID");

            entity.HasOne(d => d.Learner).WithMany(p => p.Skills)
                .HasForeignKey(d => d.LearnerId)
                .HasConstraintName("FK__Skills__LearnerI__78D3EB5B");
        });

        modelBuilder.Entity<SkillMastery>(entity =>
        {
            entity.HasKey(e => new { e.QuestId, e.SkillM }).HasName("PK__Skill_Ma__6B9BE69EAB4895D6");

            entity.ToTable("Skill_Mastery");

            entity.Property(e => e.QuestId).HasColumnName("QuestID");
            entity.Property(e => e.SkillM)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Skill_m");

            entity.HasOne(d => d.Quest).WithMany(p => p.SkillMasteries)
                .HasForeignKey(d => d.QuestId)
                .HasConstraintName("FK__Skill_Mas__Quest__5A1A5A11");
        });

        modelBuilder.Entity<SkillProgression>(entity =>
        {
            entity.HasKey(e => e.SkillProgressionId).HasName("PK__SkillPro__68299D28FB7C275F");

            entity.ToTable("SkillProgression");

            entity.Property(e => e.SkillProgressionId).HasColumnName("SkillProgressionID");
            entity.Property(e => e.LearnerId).HasColumnName("LearnerID");
            entity.Property(e => e.ProficiencyLevel)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("proficiency_level");
            entity.Property(e => e.Skill)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("skill");
            entity.Property(e => e.SkillProgressionTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("Skill_progression_timestamp");

            entity.HasOne(d => d.SkillNavigation).WithMany(p => p.SkillProgressions)
                .HasForeignKey(d => new { d.Skill, d.LearnerId })
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__SkillProgression__4F9CCB9E");
        });

        modelBuilder.Entity<Survey>(entity =>
        {
            entity.HasKey(e => e.SurveyId).HasName("PK__Survey__A5481F9D86844AF1");

            entity.ToTable("Survey");

            entity.Property(e => e.SurveyId).HasColumnName("SurveyID");
            entity.Property(e => e.SurveyTitle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Survey_Title");
        });

        modelBuilder.Entity<Surveyquestion>(entity =>
        {
            entity.HasKey(e => new { e.SurveyId, e.Questions }).HasName("PK__surveyqu__F7A092FB07CD2B12");

            entity.ToTable("surveyquestions");

            entity.Property(e => e.SurveyId).HasColumnName("SurveyID");
            entity.Property(e => e.Questions)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Survey).WithMany(p => p.Surveyquestions)
                .HasForeignKey(d => d.SurveyId)
                .HasConstraintName("FK__surveyque__Surve__414EAC47");
        });

        modelBuilder.Entity<TargetTrait>(entity =>
        {
            entity.HasKey(e => new { e.ModuleId, e.CourseId, e.Trait }).HasName("PK__Target_t__4E005E4C651253D3");

            entity.ToTable("Target_traits");

            entity.Property(e => e.ModuleId).HasColumnName("ModuleID");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.Trait)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Module).WithMany(p => p.TargetTraits)
                .HasForeignKey(d => new { d.ModuleId, d.CourseId })
                .HasConstraintName("FK__Target_traits__090A5324");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
