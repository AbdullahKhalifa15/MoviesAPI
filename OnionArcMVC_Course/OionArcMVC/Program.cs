using DomainLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.RepositoryPattern;
using RepositryLayer;
using ServiceLayer.AssignmentService;
using ServiceLayer.AttendenceService;
using ServiceLayer.CourseService;
using ServiceLayer.SessionService;
using ServiceLayer.UserServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//add services for ounion arc
builder.Services.AddMvc();
builder.Services.AddDbContext<ApplicationContext>(options => options
.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IRepositoryUser<>), typeof(RepositoryUser<>));


builder.Services.AddTransient<IApplicationUserService, ApplicationUserService>();
builder.Services.AddTransient<IAssignmentService, AssignmentService>();
builder.Services.AddTransient<ICourseService, CourseService>();
builder.Services.AddTransient<IAttendenceService, AttendenceService>();
builder.Services.AddTransient<ISessionService, SessionService>();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
.AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();
//builder.Services.AddIdentityCore<ApplicationContext>();
// Add services to the container.
builder.Services.AddControllersWithViews();


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
app.UseAuthentication();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=index}/{id?}");

app.Run();
