using System;
using Core.Entities;

namespace Core.Specification;

public class TimeSheetSpecification
{

}

public class TimeSheetByIdAndUserSpecification : BaseSpecification<TimeSheet>
{
    public TimeSheetByIdAndUserSpecification(string userId, int timeSheetId) : base(x => x.AppUserId == userId && x.Id == timeSheetId)
    {
        
    }
}