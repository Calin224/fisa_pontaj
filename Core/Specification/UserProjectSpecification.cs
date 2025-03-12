using System;
using Core.Entities;

namespace Core.Specification;

public class UserPeojectSpecification : BaseSpecification<UserProject>
{
    public UserPeojectSpecification(string userId, int projectId) : base(x =>
        x.AppUserId == userId && x.Id == projectId)
    {
    }
}
