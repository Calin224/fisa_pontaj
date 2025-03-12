using System;

namespace Core.Entities;

public class UserProject : BaseEntity
{
    public string? AppUserId { get; set; }
    public string ProjectName { get; set; } = "";
    public string ProjectCode { get; set; } = "";
    // public DateTime AssignedDate { get; set; }
    // public DateTime? UnassignedDate { get; set; }
    public int TimeEntryId { get; set; }

    // navigation
    public AppUser AppUser { get; set; } = null!;
    public TimeEntry TimeEntry { get; set; } = null!;
    // public Project Project { get; set; } = null!;
}
