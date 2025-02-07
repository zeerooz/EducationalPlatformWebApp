﻿using System;
using System.Collections.Generic;

namespace EducationalPlatformWebApp.Models;

public partial class CourseEnrollment
{
    public int EnrollmentId { get; set; }

    public int? CourseId { get; set; }

    public int? LearnerId { get; set; }

    public DateOnly? CompletionDate { get; set; }

    public DateOnly? EnrollmentDate { get; set; }

    public string? CeStatus { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Learner? Learner { get; set; }
}
