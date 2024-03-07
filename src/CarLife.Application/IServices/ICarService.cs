using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarLife.Core.Entities;

namespace CarLife.Application.Interfaces;
public interface ICarService
{
  Task<IList<Car>> GetAll();
  Task<Car?> GetById(int id);
  bool Add(Car newCar);
  bool Update(Car car);
  bool Save();
}
