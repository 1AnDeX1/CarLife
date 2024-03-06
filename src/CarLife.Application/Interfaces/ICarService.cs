using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarLife.Core.Entities;

namespace CarLife.Application.Interfaces;
internal interface ICarService
{
  Task<IEnumerable<Car>> GetAll();
}
