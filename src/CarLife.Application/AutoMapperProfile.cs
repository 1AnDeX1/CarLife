using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarLife.Application.Dto;
using CarLife.Core.Entities;

namespace CarLife.Application;
public class AutoMapperProfile : Profile
{
  public AutoMapperProfile()
  {
    CreateMap<Car, CarMainDto>();
    CreateMap<CarMainDto, Car>();
    CreateMap<Car, CarCreateDto>();
    CreateMap<CarCreateDto, Car>();
    CreateMap<Car, CarDetailDto>();
    CreateMap<Car, CarEditDto>();
    CreateMap<CarEditDto, Car>();
  }
}
