using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CarLife.Core.Entities;
public class User : IdentityUser
{
  public string? Name { get; set; }
  public double Rating { get; set; }

  public ICollection<Purchase>? Purchases { get; set;}
  public ICollection<FavoriteCars>? FavoriteCars{ get; set; }
  public ICollection<ServiceStation>? ServiceStations { get; set; }
}
