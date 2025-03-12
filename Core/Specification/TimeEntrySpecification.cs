using System;
using Core.Entities;

namespace Core.Specification;

public class TimeEntrySpecification : BaseSpecification<TimeEntry>
{
    public TimeEntrySpecification(int id, string userId) 
        : base(e => e.UserId == userId && e.Id == id) { }
}
