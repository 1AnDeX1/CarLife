using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLife.Application.Classes;
public class CarSortItems
{
  public string? Sort { get; set; }
  public string? Mark { get; set; }
  public string? Model { get; set; }
  public int? PriceFrom { get; set; }
  public int? PriceTo { get; set; }
  public int? MileageFrom { get; set; }
  public int? MileageTo { get; set; }
  public int? YearOfManufectureFrom { get; set; }
  public int? YearOfManufectureTo { get; set; }
  public string? City { get; set; }
}
