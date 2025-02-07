using System;
using System.Collections.Generic;

namespace EducationalPlatformWebApp.Models;

public partial class Assessment
{
    public int AssessmentsId { get; set; }

    public int? CourseId { get; set; }

    public int? ModuleId { get; set; }

    public string? AssessmentsType { get; set; }

    public int TotalMarks { get; set; }

    public int? PassingMarks { get; set; }

    public string? AssessmentsCriteria { get; set; }

    public int Weightage { get; set; }

    public string? AssessmentsDescriptioin { get; set; }

    public string? AssessmentsTitle { get; set; }

    public virtual Module? Module { get; set; }
}
