using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using EduMaterial.Localisation;
using EduMaterial.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddJsonOptions(opt =>
{
opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
opt.JsonSerializerOptions.WriteIndented = false;
});

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
//builder.Services.AddDbContext<AppDbContext>(options =>
//{
//    var migrationsAssembly = typeof(AppDbContext).Assembly.GetName().Name;
//    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), b => b.MigrationsAssembly(migrationsAssembly).EnableStringComparisonTranslations());
//});
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.Configure<DataProtectionTokenProviderOptions>(options =>
{
    options.TokenLifespan = TimeSpan.FromSeconds(10);
});
builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    options.User.RequireUniqueEmail = true;
    options.Password.RequireUppercase = true;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
})
.AddDefaultTokenProviders()
.AddErrorDescriber<ErrorDescription>()
.AddEntityFrameworkStores<AppDbContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
          name: "default",
          pattern: "{controller=panel}/{action=Index}/{id?}");
});

app.Run();
