using System;
using System.Security.Claims;
using API.DTOs;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace API.Controllers;

public class WorkDayController(IGenericRepository<WorkDay> repo, IGenericRepository<WorkWeek> workWeekRepo) : BaseApiController
{
    [HttpPost]
    public async Task<IActionResult> CreateWorkDay(CreateWorkDayDto createDto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if(userId == null) return Unauthorized();

        var existingWorkDaySpec = new WorkDayByDateSpecification(userId, createDto.Date);
        var existingWorkDay = await repo.GetEntityWithSpec(existingWorkDaySpec);
        if(existingWorkDay != null) return BadRequest("Work day already exists");

        var workWeekSpec = new WorkWeekByIdAndUserSpecification(createDto.WorkWeekId, userId);
        var workWeek = await workWeekRepo.GetEntityWithSpec(workWeekSpec);
        if (workWeek == null)
        {
            return BadRequest("Invalid WorkWeekId or it does not belong to the user.");
        }

        var workDay = new WorkDay
        {
            AppUserId = userId,
            Date = createDto.Date,
            WorkWeekId = workWeek.Id
        };

        repo.Add(workDay);
        if(await repo.SaveAllAsync()) return Ok();

        return BadRequest("Failed to create work day");
    }
}
