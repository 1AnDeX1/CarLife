using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarLife.Core.Entities;

namespace CarLife.Application.IServices;
public interface IUserService
{
  List<Car> GetAllUserCars();
}
