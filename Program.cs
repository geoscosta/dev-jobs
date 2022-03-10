using DevJobs.API.Persistence;
using DevJobs.API.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionStrings = builder.Configuration.GetConnectionString("DevJobsCs");

// Use Data Base SQL Server
builder.Services.AddDbContext<DevJobsContext>(options =>
    options.UseSqlServer(connectionStrings));
    
// Use Data Base to memory
//builder.Services.AddDbContext<DevJobsContext>(options =>
//    options.UseInMemoryDatabase("DevJobs"));

builder.Services.AddScoped<IJobVacancyRepository, JobVacancyRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
