using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLife.Core.Entities;
public class Purchase
{
  public int Id { get; set; }
  public int UserId { get; set; }
  public int CarId { get; set; }
  public DateTime TimeOfPurchase { get; set; }
  public Car? Car { get; set; }
  public User? User { get; set; }
  
}
