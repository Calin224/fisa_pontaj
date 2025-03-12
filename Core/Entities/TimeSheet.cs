using System;

namespace Core.Entities;

public class TimeSheet: BaseEntity
{
    public string AppUserId { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public double TotalHours => WorkWeeks.Sum(w => w.TotalHours);
    public double TotalBaseHours => WorkWeeks.SelectMany(ww => ww.WorkDays).Sum(wd => wd.BaseHours);
    public double TotalProjectHours => WorkWeeks.SelectMany(ww => ww.WorkDays).Sum(wd => wd.ProjectHours);

    // navigation
    public AppUser AppUser { get; set; } = null!;
    public ICollection<WorkWeek> WorkWeeks { get; set; } = [];
}
