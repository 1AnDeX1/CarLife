using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLife.Core.Entities;
public class NewsThemes
{
  public int Id { get; set; }
  public string? Name { get; set; }

  public ICollection<News>? News { get; set; }
}
