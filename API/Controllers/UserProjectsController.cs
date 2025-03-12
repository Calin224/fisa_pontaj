using System;
using System.Security.Claims;
using API.DTOs;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ProjectsController(IGenericRepository<UserProject> repo) : BaseApiController
{
    [HttpPost]
    public async Task<IActionResult> CreateUserProject(UserProjectDto userProjectDto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if(userId == null) return Unauthorized();

        // var existingProject = await repo.GetEntityWithSpec(new UserProjectSpecification(userId, userProjectDto.ProjectCode));
        // if(existingProject != null) return BadRequest("You already have this project");

        var userProject = new UserProject()
        {
            ProjectName = userProjectDto.ProjectName,
            ProjectCode = userProjectDto.ProjectCode,
            AppUserId = userId
        };
        repo.Add(userProject);
        if(await repo.SaveAllAsync()) return Ok();

        return BadRequest("Failed to create user project");
    }

    [HttpGet("user-projects")]
    public async Task<IActionResult> GetUserProjects()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if(userId == null) return Unauthorized();

        var spec = new UserProjectSpecification(userId);
        var userProjects = await repo.ListAsync(spec);

        return Ok(userProjects);
    }
}
