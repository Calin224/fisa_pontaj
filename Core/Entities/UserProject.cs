using System;

namespace Core.Entities;

public class UserProject : BaseEntity
{
    public string? AppUserId { get; set; }
    public string ProjectName { get; set; } = "";
    public string ProjectCode { get; set; } = "";
    // public int TimeEntryId { get; set; }

    // navigation
    public AppUser AppUser { get; set; } = null!;
    public TimeEntry TimeEntry { get; set; } = null!;
}
