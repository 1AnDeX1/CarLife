using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarLife.Core.Entities;

namespace CarLife.Application.Dto;
public class NewsIndexDto
{
  public int Id { get; set; }
  public string? Title { get; set; }
  public string? Description { get; set; }
  public string? Photo { get; set; }
  public int? ThemeId { get; set; }
  public DateOnly DateOfPost { get; set; }

  public NewsThemes? NewsTheme { get; set; }
}
