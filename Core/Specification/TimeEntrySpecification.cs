using System;
using Core.Entities;

namespace Core.Specification;

public class TimeEntrySpecification : BaseSpecification<TimeEntry>
{
    public TimeEntrySpecification(string userId) 
        : base(e => e.UserId == userId) { }

    public TimeEntrySpecification(string userId, DateTime date)
        : base(e => e.UserId == userId && e.Date.Date == date.Date) { }

    public TimeEntrySpecification(string userId, DateTime startDate, DateTime endDate)
        : base(e => e.UserId == userId && e.Date >= startDate && e.Date <= endDate) { }
}
