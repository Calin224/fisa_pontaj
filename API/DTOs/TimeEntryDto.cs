using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class TimeEntryDto
{
    public DateTime Date { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public bool IsBaseHours { get; set; }
    public double Hours { get; set; }
    public string ProjectName { get; set; } = "";
    public string ProjectCode { get; set; } = "";
    public int WorkDayId { get; set; }
}

public class CreateTimeEntryDto
{
    [Required]
    public DateTime Date { get; set; }
    
    [Required]
    public TimeSpan StartTime { get; set; }
    
    [Required]
    public TimeSpan EndTime { get; set; }
    
    public bool IsBaseHours { get; set; }
    
    [Required]
    public int UserProjectId { get; set; }
    
    [Required]
    public int WorkDayId { get; set; }
}