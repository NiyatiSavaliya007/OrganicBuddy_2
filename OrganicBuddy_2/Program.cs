using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OrganicBuddy_2.Data;
using OrganicBuddy_2.Models;
using System.Linq;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register the database context.
builder.Services.AddDbContext<OBAppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("con")));

var app = builder.Build();

// Configure the HTTP request pipeline.
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

//// Login endpoint
//app.MapPost("/Home/Login", async (OBAppDbContext dbContext, string email, string password) =>
//{
//    var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

//    if (user != null)
//    {
//        // Authentication successful, redirect to home page
//        return Results.Redirect("/Home/Index");
//    }
//    else
//    {
//        // Authentication failed, redirect back to login page with error message
//        return Results.Redirect("/Home/Login?error=Invalid credentials");
//    }
//});

app.Run();
