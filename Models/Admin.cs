using System;
using System.Collections.Generic;

namespace ProjectPRN212Group4.Models;

public partial class Admin
{
    public int AdminId { get; set; }

    public string AdminName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? FullName { get; set; }
}
