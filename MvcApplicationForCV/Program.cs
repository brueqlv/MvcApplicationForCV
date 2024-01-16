using Microsoft.EntityFrameworkCore;
using MvcApplicationForCV.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<CvDataService>();


builder.Services.AddDbContext<MvcApplicationForCvDbContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("WeatherDatabase");

    options.UseSqlServer(connectionString);
}, ServiceLifetime.Scoped);

var app = builder.Build();

DataBaseFiller.FillData(app.Services); // Should delete 

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
