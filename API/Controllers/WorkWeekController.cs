using System;
using System.Security.Claims;
using API.DTOs;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class WorkWeekController(IGenericRepository<WorkWeek> repo, IGenericRepository<TimeSheet> timeSheetRepo) : BaseApiController
{
    [HttpPost]
    public async Task<IActionResult> CreateWorkWeek(CreateWorkWeekDto createDto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if(userId == null) return Unauthorized();

        var timeSheetSpec = new TimeSheetByIdAndUserSpecification(userId, createDto.TimeSheetId);
        var timeSheet = await timeSheetRepo.GetEntityWithSpec(timeSheetSpec);
        if(timeSheet == null) return NotFound("Time sheet not found");

        var workWeek = new WorkWeek
        {
            WeekNumber = createDto.WeekNumber,
            Year = createDto.Year,
            StartDate = createDto.StartDate,
            EndDate = createDto.EndDate,
            AppUserId = userId,
            TimeSheetId = createDto.TimeSheetId
        };

        repo.Add(workWeek);
        if(await repo.SaveAllAsync()) return Ok(new { id = workWeek.Id });

        return BadRequest("Failed to create work week");
    }
}
