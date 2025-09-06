
using IsPlanlamaAPI.Business.Abstract;
using IsPlanlamaAPI.Business.Interface;
using IsPlanlamaAPI.Business.Mapping;
using IsPlanlamaAPI.Business.Service;
using IsPlanlamaAPI.Data.Context;
using IsPlanlamaAPI.Data.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IPlan, PlanServices>();
builder.Services.AddScoped<TeamServices>();
builder.Services.AddScoped<UserServices>();
builder.Services.AddScoped<IUser, UserServices>();
builder.Services.AddScoped<ITeam, TeamServices>();
builder.Services.AddScoped<IUser, UserServices>();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ProjeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepoistory<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
