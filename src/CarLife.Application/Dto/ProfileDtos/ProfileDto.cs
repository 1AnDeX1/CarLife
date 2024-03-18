using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarLife.Core.Entities;

namespace CarLife.Application.Dto.Profile;
public class ProfileDto
{
  public List<Core.Entities.Car>? Cars { get; set; }
  public List<Core.Entities.Car?>? FavoriteCars { get; set; }
}
