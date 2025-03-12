using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class TimeEntry : BaseEntity
{
    public string ProjectName { get; set; } = "";
    public DateTime Date { get; set; }
    public int Hours { get; set; }

    [Required]
    public string UserId { get; set; } = "";
    public AppUser? User { get; set; }
}
