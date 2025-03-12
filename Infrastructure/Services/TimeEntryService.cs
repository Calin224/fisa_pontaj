using System;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class TimeEntryService(IGenericRepository<TimeEntry> repo) : ITimeEntryService
{
    public async Task<bool> ValidateTimeEntryAsync(TimeEntry entry)
    {
        // var dailySpec = new TimeEntrySpecification(entry.UserId, entry.Date);
        // var weeklySpec = new TimeEntrySpecification(entry.UserId, entry.Date.AddDays(-((int)entry.Date.DayOfWeek)), entry.Date);

        // var userEntries = await repo.ListAsync(dailySpec);
        // var totalHoursPerDay = userEntries.Sum(e => e.Hours);
        // var projectHoursPerDay = userEntries.Where(e => e.ProjectName == entry.ProjectName).Sum(e => e.Hours);
        // var totalHoursPerWeek = (await repo.ListAsync(weeklySpec)).Sum(e => e.Hours);

        // if (totalHoursPerDay + entry.Hours > 12)
        //     throw new Exception("Nu poți adăuga mai mult de 12 ore într-o zi.");

        // if (projectHoursPerDay + entry.Hours > 4)
        //     throw new Exception("Nu poți aloca mai mult de 4 ore unui proiect într-o zi.");

        // if (totalHoursPerWeek + entry.Hours > 60)
        //     throw new Exception("Nu poți depăși 60 de ore pe săptămână.");

        // return true;

        throw new NotImplementedException();
    }
}
