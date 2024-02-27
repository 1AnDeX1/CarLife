using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLife.Core.Entities;

public class Car
{
  public int Id { get; set; }
  public string? Mark { get; set; }
  public string? Model { get; set; }
  public int Price { get; set; }
  public string? Description { get; set; }
  public int Mileage { get; set; }
  public string? Photo { get; set; }
  public DateTime YearOfManufecture { get; set; }
  public string? City { get; set; }
  public string? Colour { get; set; } 
  public ICollection<User>? Users { get; set; }
  public ICollection<Purchase>? Purchases { get; set; }
  public ICollection<FavoriteCars>? Favorites{ get; set; }
  public ICollection<PageAttending>? PageAttendings{ get; set; }
}
