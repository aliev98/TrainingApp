using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TrainingApp.Data;
using Microsoft.AspNetCore.Hosting;
using TrainingApp.Models;
using TrainingApp.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddMvc();

builder.Services.AddDbContext<AppDbContext>(options =>  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//builder.Services.AddTransient<AppDbContext>();


builder.Services.AddIdentity<AppUser, IdentityRole>(op =>
{
    op.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";
    op.Password.RequireDigit = false;
    op.Password.RequireLowercase = false;
    op.Password.RequireUppercase = false;
    op.Password.RequireNonAlphanumeric = false;

}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

builder.Services.AddScoped<UserManager<AppUser>, UserManager<AppUser>>();
builder.Services.AddScoped<SignInManager<AppUser>, SignInManager<AppUser>>();
builder.Services.AddScoped<IWorkoutPlanService, WorkoutPlanService>();
builder.Services.AddScoped<CreateWorkoutPlanVM>();


var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;

//    try
//    {
//        var dbContext = services.GetRequiredService<AppDbContext>();

//        // Apply entity configurations
//        dbContext.Database.Migrate(); // Ensure the database is created and up-to-date

//        // Other database-related configurations...
//    }
//    catch (Exception ex)
//    {
//        // Handle exceptions related to database initialization
//        Console.WriteLine($"An error occurred while initializing the database: {ex.Message}");
//    }
//}


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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();