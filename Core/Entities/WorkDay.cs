using System;

namespace Core.Entities;

public class WorkDay : BaseEntity
{
    // public int Id { get; set; }
    public string? AppUserId { get; set; }
    public DateTime Date { get; set; }

    public double TotalHours => TimeEntries.Sum(t => t.Hours);
    public double BaseHours => TimeEntries.Where(t => t.IsBaseHours).Sum(t => t.Hours);
    public double ProjectHours => TimeEntries.Where(t => !t.IsBaseHours).Sum(t => t.Hours);

    // navigation
    public AppUser AppUser { get; set; } = null!;
    public ICollection<TimeEntry> TimeEntries { get; set; } = [];

    public int WorkWeekId { get; set; }
    public WorkWeek WorkWeek { get; set; } = null!;
}
