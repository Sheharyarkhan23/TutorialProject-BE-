using Microsoft.EntityFrameworkCore;
using TutorialProject.Controllers;
using TutorialProject.Data;
using TutorialProject.Interfaces;
using TutorialProject.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ApplicationDbContext>();
builder.Services.AddTransient<IProfileRepository, GenericRepository>();
builder.Services.AddTransient<IBlogRepository, GenericRepository>();



builder.Services.AddMemoryCache();
builder.Services.AddMvc();
//MSSQL DB Conn:
//string connString = builder.Configuration.GetConnectionString("DefaultConnectionMSSQLNoCred");
//builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connString));


//MySQL DB Conn
string _GetConnStringName = builder.Configuration.GetConnectionString("DefaultConnectionMySQL");
builder.Services.AddDbContextPool<ApplicationDbContext>(options => options.UseMySql(_GetConnStringName, ServerVersion.AutoDetect(_GetConnStringName)));




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
app.UseCors(c => c.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
