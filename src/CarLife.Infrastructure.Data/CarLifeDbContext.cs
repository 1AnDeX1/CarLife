using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarLife.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarLife.Infrastructure.Data;
public class CarLifeDbContext : IdentityDbContext<User>
{
  public CarLifeDbContext(DbContextOptions options) : base(options){ }

  public DbSet<Car> Cars { get; set; }
  public DbSet<FavoriteCars> FavoriteCars { get; set; }
  public DbSet<News> News { get; set; }
  public DbSet<PageAttending> PageAttending { get; set; }
  public DbSet<Purchase> Purchases { get; set; }
  public DbSet<ServiceStation> ServiceStations { get; set; }
  public DbSet<NewsThemes> NewsThemes  { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarLifeDbContext).Assembly);

    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<Car>()
      .HasOne(x => x.User)
      .WithMany(x => x.Cars)
      .HasForeignKey(x => x.UserId);

    modelBuilder.Entity<News>()
      .HasOne(x => x.NewsTheme)
      .WithMany(x => x.News)
      .HasForeignKey(x => x.ThemeId);

    modelBuilder.Entity<FavoriteCars>()
      .HasOne(x => x.Car)
      .WithMany(x => x.Favorites)
      .HasForeignKey(x => x.CarId);

    modelBuilder.Entity<FavoriteCars>()
      .HasOne(x => x.User)
      .WithMany(x => x.FavoriteCars)
      .HasForeignKey(x => x.UserId);

    modelBuilder.Entity<PageAttending>()
      .HasOne(x => x.Car)
      .WithMany(x => x.PageAttendings)
      .HasForeignKey(x =>x.CarId);

    modelBuilder.Entity<Purchase>()
      .HasOne(x => x.Car)
      .WithMany(x => x.Purchases)
      .HasForeignKey(x => x.CarId);

    modelBuilder.Entity<Purchase>()
      .HasOne(x => x.User)
      .WithMany(x => x.Purchases)
      .HasForeignKey(x => x.UserId);

    modelBuilder.Entity<ServiceStation>()
      .HasOne(x => x.User)
      .WithMany(x => x.ServiceStations)
      .HasForeignKey(x => x.UserId);
  }

}
