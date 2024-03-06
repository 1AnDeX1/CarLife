﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarLife.Core.Entities;

namespace CarLife.Application.Dto;
public class CarMainDto
{
  public int Id { get; set; }
  public string? Mark { get; set; }
  public string? Model { get; set; }
  public int Price { get; set; }
  public int Mileage { get; set; }
  public string? Photo { get; set; }
  public DateOnly YearOfManufecture { get; set; }
  public string? City { get; set; }
}
