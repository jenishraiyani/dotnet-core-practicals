using Microsoft.EntityFrameworkCore;
using Practical_18.Models;
using Practical_20.GlobalExceptions;
using Practical_20.Interfaces;
using Practical_20.Repository;
using Practical_20.Services;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);
LoggerConfiguration loggerConfiguration = new LoggerConfiguration();
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));
Log.Logger = loggerConfiguration
          .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
          .Enrich.FromLogContext()
          .WriteTo.Console()
          .CreateLogger();

 

// Add services to the container.
builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient(typeof(IStudentService), typeof(StudentService));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSerilogRequestLogging();
app.UseMiddleware(typeof(ExceptionHandlingMiddleware));
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
 
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
