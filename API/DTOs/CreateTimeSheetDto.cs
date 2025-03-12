using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class CreateTimeSheetDto
{
    [Required]
    public int Month { get; set; }

    [Required]
    public int Year { get; set; }
}
