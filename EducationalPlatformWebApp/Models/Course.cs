using System;
using System.Collections.Generic;

namespace EducationalPlatformWebApp.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string? CourseTitle { get; set; }

    public string? LearningObjective { get; set; }

    public int? CreditPoints { get; set; }

    public int? DifficultyLevel { get; set; }

    public string? PreRequisites { get; set; }

    public string? CourseDescription { get; set; }

    public virtual ICollection<CourseEnrollment> CourseEnrollments { get; set; } = new List<CourseEnrollment>();

    public virtual ICollection<Module> Modules { get; set; } = new List<Module>();

    public virtual ICollection<Ranking> Rankings { get; set; } = new List<Ranking>();

    public virtual ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();
}
