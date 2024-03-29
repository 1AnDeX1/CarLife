﻿using CarLife.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using CarLife.Core.Entities;
using CarLife.Application;
using CarLife.Application.Interfaces;
using CarLife.Application.Services;
using CarLife.Application.IServices;


namespace CarLife.WebUI;

public class Program
{
  public static void Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddControllersWithViews();
    builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
    builder.Services.AddStorage(builder.Configuration);

    builder.Services.AddScoped<ICarService, CarService>();
    builder.Services.AddScoped<INewsService, NewsService>();
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddScoped<IFavoriteCarsService, FavoriteCarsService>();

    builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<CarLifeDbContext>()
    .AddDefaultTokenProviders(); ;
    builder.Services.AddMemoryCache();
    builder.Services.AddSession();
    builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
           .AddCookie();

    var app = builder.Build();
    //if (args.Length == 1 && args[0].ToLower() == "seeddata")
    //{
    //  await SeedingExtension.SeedRolesAsync(app);
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

    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    //SeedingExtension.SeedRolesAsync(app).Wait();
    app.Run();
  }
}
