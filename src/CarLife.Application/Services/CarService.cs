using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarLife.Application.Classes;
using CarLife.Application.Dto;
using CarLife.Application.Interfaces;
using CarLife.Core.Entities;
using CarLife.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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


  public IList<Car> GetAll()
  {
    return _context.Cars.ToList();
  }
  public IList<Car> GetAllwithUser()
  {
    return _context.Cars.Include(c => c.User).ToList();
  }
  

  public IList<Car> GetSortedCars(string sort)
  {
    var cars = GetSortedCarsWithoutToList(sort);
    return cars.ToList();
  }
  public IQueryable<Car> GetSortedCarsWithoutToList(string sort)
  {
    IQueryable<Car> cars = _context.Cars;

    switch (sort)
    {
      case "priceAsc": 
        cars = cars.OrderBy(c => c.Price);
        break;
      case "priceDesc":
        cars = cars.OrderByDescending(c => c.Price);
        break;
      case "dateAsc":
        cars = cars.OrderBy(c => c.YearOfManufecture);
        break;
      case "dateDesc":
        cars = cars.OrderByDescending(c => c.YearOfManufecture);
        break;
    }

    return cars;
  }
  public IList<Car> GetFilteredCars(CarSortItems carSortItems)
  {
    if (carSortItems.Sort == null)
      carSortItems.Sort = "default";

    //IQueryable<Car> cars = _context.Cars;
    var cars = GetSortedCarsWithoutToList(carSortItems.Sort);
    //mark
    if (carSortItems.Mark != null)
    {
      cars = cars.Where(c => 
        c.Mark != null && 
        c.Mark.ToLower()
          .StartsWith(carSortItems.Mark.ToLower()));
    }
    //model
    if (carSortItems.Model != null)
    {
      cars = cars.Where(c =>
        c.Model != null &&
        c.Model.ToLower()
          .StartsWith(carSortItems.Model.ToLower()));
    }
    //price
    if (carSortItems.PriceFrom.HasValue && carSortItems.PriceTo.HasValue)
    {
      cars = cars.Where(p => p.Price >= carSortItems.PriceFrom && p.Price <= carSortItems.PriceTo);  
    }
    else if (carSortItems.PriceFrom.HasValue)
    {
      cars = cars.Where(p => p.Price >= carSortItems.PriceFrom);
    }
    else if (carSortItems.PriceTo.HasValue)
    {
      cars = cars.Where(p => p.Price <= carSortItems.PriceTo);
    }

    //mileage
    if (carSortItems.MileageFrom.HasValue && carSortItems.MileageTo.HasValue)
    {
      cars = cars.Where(p => p.Mileage >= carSortItems.MileageFrom && p.Mileage <= carSortItems.MileageTo);
    }
    else if (carSortItems.MileageFrom.HasValue)
    {
      cars = cars.Where(p => p.Mileage >= carSortItems.MileageFrom);
    }
    else if (carSortItems.MileageTo.HasValue)
    {
      cars = cars.Where(p => p.Mileage <= carSortItems.MileageTo);
    }
    //date
    if (carSortItems.YearOfManufectureFrom.HasValue && carSortItems.YearOfManufectureTo.HasValue)
    {
      cars = cars.Where(p => p.YearOfManufecture >= carSortItems.YearOfManufectureFrom && p.YearOfManufecture <= carSortItems.YearOfManufectureTo);
    }
    else if (carSortItems.YearOfManufectureFrom.HasValue)
    {
      cars = cars.Where(p => p.YearOfManufecture >= carSortItems.YearOfManufectureFrom);
    }
    else if (carSortItems.YearOfManufectureTo.HasValue)
    {
      cars = cars.Where(p => p.YearOfManufecture <= carSortItems.YearOfManufectureTo);
    }
    //city
    if (carSortItems.City != null)
    {
      cars = cars.Where(c =>
        c.City != null &&
        c.City.ToLower()
          .StartsWith(carSortItems.City.ToLower()));
    }

    return cars.ToList();
  }

  public Car? GetById(int id)
  {
    return _context.Cars.FirstOrDefault(c => c.Id == id);
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


  public bool Delete(Car car)
  {
    _context.Cars.Remove(car);
    return Save();
  }
}
