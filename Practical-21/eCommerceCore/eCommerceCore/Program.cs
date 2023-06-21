using eCommerceCore.Interfaces;
using eCommerceCore.Models;
using eCommerceCore.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddControllersWithViews();
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = "/Account/Login";
});

builder.Services.AddMvc(options =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    options.Filters.Add(new AuthorizeFilter(policy));
}).AddXmlSerializerFormatters();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("CreateRolePolicy",
        policy => policy.RequireClaim("Create Role"));
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("CreateProductPolicy",
        policy => policy.RequireClaim("Create Product"));
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("EditProductPolicy",
        policy => policy.RequireClaim("Edit Product"));
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminAndUser",
        policy => policy.RequireRole("Admin","User"));
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath= new PathString("/Administration/AccessDenied");
});

builder.Services.AddScoped<IProductService, ProductRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
