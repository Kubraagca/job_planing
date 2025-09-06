
using AutoMapper;
using IsPlanlamaAPI.Business.Abstract;
using IsPlanlamaAPI.Business.Interface;
using IsPlanlamaAPI.Business.Mapping;
using IsPlanlamaAPI.Business.Service;
using IsPlanlamaAPI.Data.Context;
using IsPlanlamaAPI.Data.Repository;
using IsPlanlamaAPI.Service;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ProjeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepoistory<>));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<IPlan, PlanServices>();
builder.Services.AddScoped<ITeam, TeamServices>();
builder.Services.AddScoped<IUser, UserServices>();
//builder.Services.AddScoped<ITeamMember, TeamMemberServices>();
var app = builder.Build();

//builder.Services.AddScoped<IUser, UserService>();
//builder.Services.AddScoped<ITeam, TeamService>();
//builder.Services.AddScoped<TeamMemberService>();
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
