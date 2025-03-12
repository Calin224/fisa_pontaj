using System;
using Microsoft.AspNetCore.Identity;

namespace Core.Entities;

public class AppUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    // public string Role { get; set; }
    // public double StandardHoursPerDay { get; set; } = 8;

    // navigation
    public ICollection<TimeEntry> TimeEntries { get; set; } = [];
    public ICollection<UserProject> UserProjects { get; set; } = [];

}
