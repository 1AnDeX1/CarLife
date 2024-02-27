using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLife.Core.Entities;
public class User
{
  public int Id { get; set; }
  public string? Name { get; set; }
  public string? Email { get; set; }
  public string? Password { get; set; } // will redo to hash
  public double Rating { get; set; }

  public string? IdentityUser { get; set; }

  public ICollection<Purchase>? Purchases { get; set;}
  public ICollection<FavoriteCars>? FavoriteCars{ get; set; }
  public ICollection<ServiceStation>? ServiceStations { get; set; }
}
