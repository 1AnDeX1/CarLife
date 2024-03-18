using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarLife.Core.Entities;

namespace CarLife.Application.IServices;
public interface IFavoriteCarsService
{
  FavoriteCars? GetFavoriteCar(int id);
  bool AddToFavorite(FavoriteCars car);
  bool Delete(FavoriteCars car);
  bool Save();
}
