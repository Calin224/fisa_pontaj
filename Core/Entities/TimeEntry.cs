using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class TimeEntry : BaseEntity
{
    public string? UserId { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public bool IsBaseHours { get; set; }

    public double Hours => (EndTime - StartTime).TotalHours;

    // navigation
    public AppUser AppUser { get; set; } = null!;
    public int UserProjectId { get; set; }
    public UserProject UserProject { get; set; } = null!;
    public int WorkDayId { get; set; }
    public WorkDay WorkDay { get; set; } = null!;
}
