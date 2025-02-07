using System;
using System.Collections.Generic;

namespace EducationalPlatformWebApp.Models;

public partial class ModuleContent
{
    public int CourseId { get; set; }

    public int ModuleId { get; set; }

    public string ModulecontentType { get; set; } = null!;

    public virtual Module Module { get; set; } = null!;
}
