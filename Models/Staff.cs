using System;
using System.Collections.Generic;

namespace ProjectPRN212Group4.Models;

public partial class Staff
{
    public int StaffId { get; set; }

    public string StaffName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }

    public DateOnly? DateOfBirth { get; set; }
}
