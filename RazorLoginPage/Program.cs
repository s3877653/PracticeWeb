using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using RazorLoginPage.Data;
using RazorLoginPage.Pages;
using Microsoft.AspNetCore.Authentication.Cookies;
using RazorLoginPage.Services;
using RazorLoginPage.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
//Connect DB
builder.Services.AddDbContext<ApplicationDBContext>(options=>options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));
//Config services
builder.Services.AddSingleton<IRegisterService, RegisterService>();
builder.Services.AddSingleton<ILoginService, LoginService>();
builder.Services.AddSingleton<ISearchService, SearchService>();
//Config landing page
builder.Services.AddMvc().AddRazorPagesOptions(options =>
{
	options.Conventions.Add(new HomePageRouteModelConvention());
}).SetCompatibilityVersion(CompatibilityVersion.Latest);
//Config cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
        options =>
        {
            options.LoginPath = "/LoginVModel/Index.cshtml";
            options.ExpireTimeSpan = TimeSpan.FromMinutes(1);
            options.AccessDeniedPath = "/Users/AccessDeniedPage";

        }
    );
//Config Authorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("IsAdmin", policy => policy.RequireClaim("Role", "admin"));
	options.AddPolicy("IsUser", policy => policy.RequireClaim("Role", "user"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
