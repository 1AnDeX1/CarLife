using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarLife.Application.Interfaces;
using CarLife.Core.Entities;
using CarLife.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CarLife.Application.Services;
public class CarService : ICarService
{
  private readonly CarLifeDbContext _context;

  public CarService(CarLifeDbContext context)
  {
    _context = context;
  }

  public bool Add(Car newCar)
  {
    _context.Cars.Add(newCar);
    return Save();
  }

  public async Task<IList<Car>> GetAll()
  {
    return await _context.Cars.Include(c => c.User).ToListAsync();
  }

  public async Task<Car?> GetById(int id)
  {
    return await _context.Cars.FirstOrDefaultAsync(c => c.Id == id);
  }

  public bool Save()
  {
    var saved = _context.SaveChanges();
    return saved > 0 ? true : false;
  }

  public bool Update(Car car)
  {
    _context.Update(car);
    return Save();
  }
}
