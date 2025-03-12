using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class CreateWorkWeekDto
{
    [Required]
    public int WeekNumber { get; set; }

    [Required]
    public int Year { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }
    
    [Required]
    public int TimeSheetId { get; set; }
}

public class WorkWeekDto
{
    public int Id { get; set; }
    public int WeekNumber { get; set; }
    public int Year { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public double TotalHours { get; set; }
    public List<WorkDayBriefDto> WorkDays { get; set; } = [];
}

public class WorkDayBriefDto
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public double TotalHours { get; set; }
    public double BaseHours { get; set; }
    public double ProjectHours { get; set; }
}