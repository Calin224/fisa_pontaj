using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class WorkDayDto
{
    public DateTime Date { get; set; }
    public double TotalHours { get; set; }
    public double BaseHours { get; set; }
    public double ProjectHours { get; set; }
    public int WorkWeekId { get; set; }
    public List<TimeEntryBriefDto> TimeEntries { get; set; } = [];
}

public class TimeEntryBriefDto
{
    public int Id { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public double Hours { get; set; }
    public bool IsBaseHours { get; set; }
    public string ProjectName { get; set; } = "";
}

public class CreateWorkDayDto
{
    [Required]
    public DateTime Date { get; set; }
    [Required]
    public int WorkWeekId { get; set; }
}