using System;

namespace Core.Entities;

public class WorkWeek : BaseEntity
{
    public string? AppUserId { get; set; }
    public int WeekNumber { get; set; }
    public int Year { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public double TotalHours => WorkDays.Sum(wd => wd.TotalHours);

    public int TimeSheetId { get; set; }

    // navigation
    public AppUser AppUser { get; set; } = null!;
    public ICollection<WorkDay> WorkDays { get; set; } = [];
    
    public TimeSheet TimeSheet { get; set; } = null!;
}
