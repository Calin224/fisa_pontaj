using System;
using System.Security.Claims;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ProjectsController(IGenericRepository<UserProject> repo) : BaseApiController
{
    [HttpPost]
    public async Task<IActionResult> CreateUserProject(UserProject userProject)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if(userId == null) return Unauthorized();

        var existingProject = await repo.GetEntityWithSpec(new UserProjectSpecification(userId, userProject.Id));
        if(existingProject != null) return BadRequest("You already have this project");

        userProject.AppUserId = userId;
        repo.Add(userProject);
        if(await repo.SaveAllAsync()) return Ok();

        return BadRequest("Failed to create user project");
    }
}
