using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarLife.Application.IServices;
using CarLife.Core.Entities;
using CarLife.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CarLife.Application.Services;
public class FavoriteCarsService : IFavoriteCarsService
{
  private readonly CarLifeDbContext _context;
  private readonly IHttpContextAccessor _httpContextAccessor;

  public FavoriteCarsService(CarLifeDbContext context, IHttpContextAccessor httpContextAccessor)
  {
    _context = context;
    _httpContextAccessor = httpContextAccessor;
  }

  public bool AddToFavorite(FavoriteCars car)
  {
    _context.FavoriteCars.Add(car);
    return Save();
  }
  public FavoriteCars? GetFavoriteCar(int id)
  {
    var currentUser = _httpContextAccessor.HttpContext.User.GetUserId();
    var favoriteCar = _context.FavoriteCars.FirstOrDefault(fc => fc.UserId == currentUser && fc.CarId == id);

    return favoriteCar;
  }

  public bool Delete(FavoriteCars car)
  {
    _context.FavoriteCars.Remove(car);
    return Save();
  }

  public bool Save()
  {
    var saved = _context.SaveChanges();
    return saved > 0 ? true : false;
  }
}
