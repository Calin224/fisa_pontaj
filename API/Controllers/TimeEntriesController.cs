using System;
using System.Security.Claims;
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

public class TimeEntriesController(IGenericRepository<TimeEntry> repo, ITimeEntryService service, SignInManager<AppUser> signInManager) : BaseApiController
{
    [HttpPost]
    public async Task<IActionResult> AddTimeEntry([FromBody] TimeEntry entry)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if(userId == null) return Unauthorized();

        entry.UserId = userId;

        try
        {
            await service.ValidateTimeEntryAsync(entry);
            repo.Add(entry);
            if(await repo.SaveAllAsync()) return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        return BadRequest("Failed to add time entry.");
    }

    [HttpGet]
    public async Task<IActionResult> GetUserTimeEntries()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if(userId == null) return Unauthorized();

        var spec = new TimeEntrySpecification(userId);
        var entries = await repo.ListAsync(spec);

        return Ok(entries);
    }
}
