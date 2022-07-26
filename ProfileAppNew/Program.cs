using Microsoft.EntityFrameworkCore;
using ProfileAppNew.Data;
using ProfileAppNew.Repository;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IinfoRepo, infoRepo>();
builder.Services.AddScoped<IAboutRepo, AboutRepo>();
builder.Services.AddScoped<IServicesRepo, ServicesRepo>();
builder.Services.AddScoped<IWorkRepo, WorkRepo>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    
    );
endpoints.MapControllerRoute(
  name: "default",
pattern: "{controller=Home}/{action=Index}/{id?}");

  
});
app.Run();
