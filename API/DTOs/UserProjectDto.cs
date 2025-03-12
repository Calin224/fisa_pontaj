using System;
using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace API.DTOs;

public class UserProjectDto
{
    [Required]
    public string AppUserId { get; set; } = string.Empty;
    [Required]
    public string ProjectName { get; set; } = string.Empty;
    [Required]
    public string ProjectCode { get; set; } = string.Empty;
}
