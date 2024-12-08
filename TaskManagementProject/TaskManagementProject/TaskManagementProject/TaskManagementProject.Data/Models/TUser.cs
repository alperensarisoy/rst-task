using System;
using System.Collections.Generic;

namespace TaskManagementProject.Data.Models;

public partial class TUser
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
}
