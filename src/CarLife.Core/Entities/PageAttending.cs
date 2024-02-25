using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLife.Core.Entities;
public class PageAttending
{
    public int Id { get; set; }
    public Car? Car { get; set; }
    public int Count { get; set; }
    public DateTime DateOfAttending { get; set; }
}
