using System;
using System.Security.Claims;
using API.DTOs;
using API.Extensions;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class TimeEntriesController(IGenericRepository<TimeEntry> repo, IGenericRepository<UserProject> projectRepo, IGenericRepository<WorkDay> workDayRepo, ITimeEntryService service) : BaseApiController
{
    [HttpPost]
    public async Task<IActionResult> CreateTimeEntry(CreateTimeEntryDto createDto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if(userId == null) return Unauthorized();

        var project = await projectRepo.GetEntityWithSpec(new UserProjectSpecification(userId, createDto.UserProjectId));
        if(project == null) return BadRequest("Project not found");

        var workDay = await workDayRepo.GetEntityWithSpec(new WorkDaySpecification(userId, createDto.WorkDayId));
        if(workDay == null) return BadRequest("Work day not found");

        if (createDto.StartTime >= createDto.EndTime)
        {
            return BadRequest("Start time must be earlier than end time.");
        }

        var timeEntry = new TimeEntry()
        {
            UserId = userId,
            Date = createDto.Date,
            StartTime = createDto.StartTime,
            EndTime = createDto.EndTime,
            IsBaseHours = createDto.IsBaseHours,
            UserProjectId = createDto.UserProjectId,
            WorkDayId = createDto.WorkDayId
        };
        repo.Add(timeEntry);
        if(await repo.SaveAllAsync()) return Ok();

        return BadRequest("Failed to create time entry");
    }
}
