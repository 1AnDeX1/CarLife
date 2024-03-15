using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarLife.Core.Entities;

namespace CarLife.Application.IServices;
public interface INewsService
{
  IList<News> GetAll();
  IList<News> GetAllWithThemes();
  IList<News> GetFilteredNews(int filter);
  List<NewsThemes> GetAllThemes();
  News? GetById(int id);
  News? GetByIdWithTheme(int id); 
  bool Add(News newCar);
  bool Delete(News news);
  bool Update(News car);
  bool Save();
}
