using FluentValidation.AspNetCore;
using Library.DAL.Context;
using Library.Initializer;
using Library.Models;
using Library.BLL.RepositoryPattern.Base;
using Library.BLL.RepositoryPattern.Concrete;
using Library.BLL.RepositoryPattern.Interfaces;
using Library.UnitofWork;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;
using System.Reflection;
using Library.MODEL.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
    //.AddFluentValidation(c=>c.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Mssql")));
builder.Services.AddScoped<IRepository<BookType>,Repository<BookType>>();
builder.Services.AddScoped<IRepository<AppUser>,Repository<AppUser>>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddTransient<IUnitofWork,EfUnitofWork>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => 
                                                                                     {
                                                                                         options.LoginPath = "/auth/login";
                                                                                         options.Cookie.Name = "userDetail";
                                                                                         options.AccessDeniedPath= "/auth/login";


                                                                                     }) ;
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy => policy.RequireClaim("role", "admin"));
    options.AddPolicy("userPolicy", policy => policy.RequireClaim("role", "admin","user"));

});



var app = builder.Build();
//migrationu direk ekleme
//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;

//    var context = services.GetRequiredService<MyDbContext>();
//    context.Database.Migrate();
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

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
	name: "DefaultArea",
	pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Auth}/{action=Login}/{id?}");

app.Run();
