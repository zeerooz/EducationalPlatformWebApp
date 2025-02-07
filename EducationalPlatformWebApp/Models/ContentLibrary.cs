using System;
using System.Collections.Generic;

namespace EducationalPlatformWebApp.Models;

public partial class ContentLibrary
{
    public int ContentLibraryId { get; set; }

    public int? CourseId { get; set; }

    public int? ModuleId { get; set; }

    public string? ContentLibraryTitle { get; set; }

    public string? ContentLibraryDescreption { get; set; }

    public string? Metadata { get; set; }

    public string? ContentLibraryType { get; set; }

    public string? ContentLibraryContentUrl { get; set; }

    public virtual Module? Module { get; set; }
}
