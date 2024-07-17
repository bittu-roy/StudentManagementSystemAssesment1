using Microsoft.EntityFrameworkCore;
using StudentManagementSystemAssesment1.Data;
using StudentManagementSystemAssesment1.Mappings;
using StudentManagementSystemAssesment1.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//injecting DbContext class
builder.Services.AddDbContext<SMSDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("SMSConnectionString")));

//injecting repository
builder.Services.AddScoped<IStudentRepository, SQLStudentRepository>();

//Adding AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

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
