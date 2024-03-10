using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarLife.Application.Classes;
using CarLife.Application.Dto;
using CarLife.Core.Entities;

namespace CarLife.Application.Interfaces;
public interface ICarService
{
  IList<Car> GetAll();
  IList<Car> GetAllwithUser();
  IList<Car> GetSortedCars(string sort);
  IList<Car> GetFilteredCars(CarSortItems carSortItems);
  Car? GetById(int id);
  bool Add(Car newCar);
  bool Update(Car car);
  bool Save();
}
