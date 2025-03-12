using System;
using Core.Entities;

namespace Core.Interfaces;

public interface ITimeEntryService
{
    Task<bool> ValidateTimeEntryAsync(TimeEntry entry);
}
