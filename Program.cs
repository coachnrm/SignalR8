using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SignalR8.Data;
using SignalR8.Hubs;
using SignalR8.MiddlewareExtensions;
using SignalR8.Models;
using SignalR8.SubscribeTableDependencies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Singleton);
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddControllersWithViews();

// DI
builder.Services.AddSingleton<DashboardHub>();
builder.Services.AddSingleton<NurseRequestHub>();
builder.Services.AddSingleton<SubscribeProductTableDependency>();

builder.Services.AddRazorPages();

builder.Services.AddIdentity<AppUser, IdentityRole>(
    options =>
    {
        options.Password.RequiredUniqueChars = 0;
        options.Password.RequireUppercase = false;
        options.Password.RequiredLength = 8;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireLowercase = false;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

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
app.MapHub<DashboardHub>("/dashboardHub");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseSqlTableDependency<SubscribeProductTableDependency>(connectionString);
app.Run();
