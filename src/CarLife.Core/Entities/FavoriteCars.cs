using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLife.Core.Entities;
public class FavoriteCars
{
  public int Id { get; set; }
  public string? UserId { get; set; }
  public int CarId { get; set; }
  public User? User { get; set; }
  public Car? Car { get; set; }
}
