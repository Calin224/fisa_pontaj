using System;
using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class NotionContext(DbContextOptions options) : IdentityDbContext<AppUser>(options)
{
    public DbSet<UserProject> UserProjects { get; set; }
    public DbSet<TimeEntry> TimeEntries { get; set; }
    public DbSet<WorkDay> WorkDays { get; set; }
    public DbSet<WorkWeek> WorkWeeks { get; set; }
    public DbSet<TimeSheet> TimeSheets { get; set; }

    public override int SaveChanges()
    {
        ValidateworkDayHours();
        ValidateworkWeekHours();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ValidateworkDayHours();
        ValidateworkWeekHours();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void ValidateworkDayHours()
    {
        foreach (var workDay in ChangeTracker.Entries<WorkDay>()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified)
                    .Select(e => e.Entity))
        {
            if (workDay.TotalHours > 12)
            {
                throw new InvalidOperationException("Total hours for a work day cannot exceed 12 hours");
            }
        }
    }

    private void ValidateworkWeekHours()
    {
        foreach (var workWeek in ChangeTracker.Entries<WorkWeek>()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified)
                    .Select(e => e.Entity))
        {
            if (workWeek.TotalHours > 60)
            {
                throw new InvalidOperationException($"WorkWeek {workWeek.WeekNumber}/{workWeek.Year} exceeds 60 hours.");
            }
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
    base.OnModelCreating(builder);

    // Configurarea relației One-to-One între TimeEntry și UserProject
    builder.Entity<TimeEntry>()
        .HasOne(te => te.UserProject) 
        .WithOne(up => up.TimeEntry)  // UserProject are un singur TimeEntry
        .HasForeignKey<TimeEntry>(te => te.UserProjectId)  // Cheia străină în TimeEntry
        .OnDelete(DeleteBehavior.NoAction)  // Fără ștergere în cascadă
        .IsRequired();

    // Configurarea relației One-to-Many între WorkDay și TimeEntry
    builder.Entity<WorkDay>()
        .HasMany(wd => wd.TimeEntries) // WorkDay poate avea mai multe TimeEntries
        .WithOne(te => te.WorkDay) // TimeEntry are un singur WorkDay
        .HasForeignKey(te => te.WorkDayId)
        .OnDelete(DeleteBehavior.NoAction)  // Fără ștergere în cascadă
        .IsRequired();

    // Configurarea relației One-to-Many între WorkWeek și WorkDay
    builder.Entity<WorkWeek>()
        .HasMany(ww => ww.WorkDays)
        .WithOne(wd => wd.WorkWeek) // WorkDay are un singur WorkWeek
        .HasForeignKey(wd => wd.WorkWeekId)
        .OnDelete(DeleteBehavior.NoAction)  // Fără ștergere în cascadă
        .IsRequired();

    // Configurarea relației One-to-Many între TimeSheet și WorkWeek
    builder.Entity<TimeSheet>()
        .HasMany(ts => ts.WorkWeeks)
        .WithOne(ww => ww.TimeSheet)
        .HasForeignKey(ww => ww.TimeSheetId)
        .OnDelete(DeleteBehavior.NoAction)  // Fără ștergere în cascadă
        .IsRequired();

    // Configurarea relației între UserProject și AppUser
    builder.Entity<UserProject>()
        .HasOne(up => up.AppUser)  // UserProject are un singur AppUser
        .WithMany(u => u.UserProjects)
        .HasForeignKey(up => up.AppUserId)
        .OnDelete(DeleteBehavior.NoAction)  // Fără ștergere în cascadă
        .IsRequired();
    }
}
