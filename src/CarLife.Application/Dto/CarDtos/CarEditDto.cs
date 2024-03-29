﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLife.Application.Dto.Car;
public class CarEditDto
{
  public int Id { get; set; }
  [Required(ErrorMessage = "The mark is required.")]
  public string? Mark { get; set; }
  [Required(ErrorMessage = "The model is required.")]
  public string? Model { get; set; }
  [Required(ErrorMessage = "The price is required.")]
  public int Price { get; set; }
  public string? Description { get; set; }
  [Required(ErrorMessage = "The mileage is required.")]
  public int Mileage { get; set; }
  [Required(ErrorMessage = "The photo is required.")]
  public string? Photo { get; set; }
  [Required(ErrorMessage = "The year of manufecture is required.")]
  public int YearOfManufecture { get; set; }
  [Required(ErrorMessage = "The city is required.")]
  public string? City { get; set; }
  [Required(ErrorMessage = "The colour is required.")]
  public string? Colour { get; set; }
}
