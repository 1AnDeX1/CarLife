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
  public string? Password { get; set; }
  public double? Rating { get; set; }
  public ICollection<Purchase>? PurchasesId { get; set;}
  public ICollection<FavoriteCars>? FavoriteCarsId{ get; set; }
  public ICollection<ServiceStation>? ServiceStationsId { get; set; }
}
