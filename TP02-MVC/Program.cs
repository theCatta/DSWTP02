using Microsoft.EntityFrameworkCore;
using TP02_MVC.Data;

var builder = WebApplication.CreateBuilder(args);

//Guilherme Ferreira Santos
//Diogo Santos Teixeira

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Context>
    (options => options.UseMySql("server=localhost;port=3306;initial catalog=TP02;uid=root;pwd=123456", ServerVersion.Parse("8.0.25-mysql")));

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
