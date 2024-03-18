using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarLife.Core.Entities;

namespace CarLife.Application.Dto.News;
public class NewsFilterIndexDto
{
  public List<NewsIndexDto>? News { get; set; }
  public List<NewsThemes>? Themes { get; set; }
}
