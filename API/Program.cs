using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Google;
using Core.Interfaces;
using Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();


builder.Services.AddDbContext<NotionContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ITimeEntryService, TimeEntryService>();

builder.Services.AddAuthorization();

builder.Services.AddCors();

builder.Services.AddIdentityApiEndpoints<AppUser>()
    .AddEntityFrameworkStores<NotionContext>();

var app = builder.Build();

app.UseCors(policy =>
    policy.WithOrigins("http://localhost:4200", "https://localhost:4200", "http://localhost:5173")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapGroup("api").MapIdentityApi<AppUser>();

app.Run();
