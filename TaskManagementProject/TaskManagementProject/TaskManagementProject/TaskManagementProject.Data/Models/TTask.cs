using System;
using System.Collections.Generic;

namespace TaskManagementProject.Data.Models;

public partial class TTask
{
    public long Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }
}
