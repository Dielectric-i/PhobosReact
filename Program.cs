using Microsoft.EntityFrameworkCore;
using PhobosReact.API.Data;
using PhobosReact.API.Data.Interfaces;
using PhobosReact.API.Data.Repositories;
using PhobosReact.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<ISpaceRepository, SpaceRepository>();
builder.Services.AddScoped<ISpaceService, SpaceService>();
builder.Services.AddScoped<IBoxRepository, BoxRepository>();
builder.Services.AddScoped<IBoxService, BoxService>();
builder.Services.AddScoped<IMappingService, MappingService>();
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<AppDbContext>(options => options.UseMySQL(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseExceptionHandler("/error");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
