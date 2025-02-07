using System;
using System.Collections.Generic;

namespace EducationalPlatformWebApp.Models;

public partial class Admin
{
    public int AdminId { get; set; }

    public string? FirstName { get; set; }

    public string Email { get; set; } = null!;

    public string UserPassword { get; set; } = null!;
}
