using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarLife.Application.IServices;
using CarLife.Core.Entities;
using CarLife.Infrastructure.Data;
using Microsoft.AspNetCore.Http;

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
    var currentUser = _httpContextAccessor.HttpContext.User;
    var userCars = _context.Cars.Where(c => c.User != null && c.User.Id == currentUser.ToString());

    return userCars.ToList();
  }
}
