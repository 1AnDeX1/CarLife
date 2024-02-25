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
  public Car? CarId { get; set; }
  public User? UserId { get; set; }
  public DateTime? TimeOfPurchase { get; set; }
}
