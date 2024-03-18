using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CarLife.Application.IServices;
using CarLife.Core.Entities;
using CarLife.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CarLife.Application.Services;
public class UserService : IUserService
{
  private readonly CarLifeDbContext _context;
  private readonly IHttpContextAccessor _httpContextAccessor;

  public UserService(CarLifeDbContext context, IHttpContextAccessor httpContextAccessor)
  {
    _context = context;
    _httpContextAccessor = httpContextAccessor;
  }
  public List<Car> GetAllUserCars()
  {
    var currentUser = _httpContextAccessor.HttpContext.User.GetUserId();
    var userCars = _context.Cars.Where(c => c.UserId == currentUser);

    return userCars.ToList();
  }
  public List<Car?> GetAllUserFavoriteCars()
  {
    var currentUser = _httpContextAccessor.HttpContext.User.GetUserId();
    var userFavoriteCars = _context.FavoriteCars.Where(c => c.UserId == currentUser)
      .Include(fc => fc.Car)
      .Select(fc => fc.Car)
      .ToList();

    return userFavoriteCars;
  }
}



