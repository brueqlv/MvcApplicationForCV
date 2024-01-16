using Microsoft.EntityFrameworkCore;
using MvcApplicationForCV.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MvcApplicationForCvDbContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("WeatherDatabase");

    options.UseSqlServer(connectionString);
}, ServiceLifetime.Scoped);

var app = builder.Build();

DataBaseFiller.FillData(app.Services);

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
