using System;
using Core.Entities;

namespace Core.Specification;

public class UserProjectSpecification : BaseSpecification<UserProject>
{
    public UserProjectSpecification(string userId, int projectId) : base(x =>
        x.AppUserId == userId && x.Id == projectId)
    {
    }

    public UserProjectSpecification(string userId) : base(x => x.AppUserId == userId)
    {
    }
}
