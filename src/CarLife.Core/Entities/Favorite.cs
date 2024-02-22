using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLife.Core.Entities;
public class Favorite
{
    public int Id { get; set; }
    public Car? CarID { get; set; }
    public User? UserId { get; set; }
}
