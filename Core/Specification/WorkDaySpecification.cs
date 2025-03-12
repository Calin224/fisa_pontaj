using System;
using Core.Entities;

namespace Core.Specification;

public class WorkDaySpecification : BaseSpecification<WorkDay>
{
    public WorkDaySpecification(string userId, int id): base(wd => wd.Id == id && wd.AppUserId == userId)
    {
        
    }
}


public class WorkDayByDateSpecification : BaseSpecification<WorkDay>
{
    public WorkDayByDateSpecification(string userId, DateTime date) : base(wd => wd.Date == date && wd.AppUserId == userId)
    {
        
    }
}

public class WorkWeekByIdAndUserSpecification : BaseSpecification<WorkWeek>
{
    public WorkWeekByIdAndUserSpecification(int workWeekId, string appUserId)
        : base(x => x.Id == workWeekId && x.AppUserId == appUserId)
    {
    }
}