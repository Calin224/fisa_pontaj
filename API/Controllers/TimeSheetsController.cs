using System;
using System.Security.Claims;
using API.DTOs;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class TimeSheetsController(IGenericRepository<TimeSheet> repo) : BaseApiController
{
    [HttpPost]
    public async Task<IActionResult> CreateTimeSheet(CreateTimeSheetDto createDto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if(userId == null) return Unauthorized();

        var timeSheet = new TimeSheet
        {
            AppUserId = userId,
            Month = createDto.Month,
            Year = createDto.Year,
            CreatedAt = DateTime.UtcNow
        };

        repo.Add(timeSheet);
        if(await repo.SaveAllAsync()) return Ok(new { id = timeSheet.Id });

        return BadRequest("Failed to create time sheet");
    }
}
