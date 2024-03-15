using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarLife.Application.IServices;
using CarLife.Core.Entities;
using CarLife.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CarLife.Application.Services;
public class NewsService : INewsService
{
  private readonly CarLifeDbContext _context;

  public NewsService(CarLifeDbContext context)
  {
    _context = context;
  }
  public bool Add(News news)
  {
    _context.News.Add(news);
    return Save();
  }

  public bool Delete(News news)
  {
    _context.News.Remove(news);
    return Save();
  }

  public IList<News> GetAll()
  {
    return _context.News.ToList();
  }

  public List<NewsThemes> GetAllThemes()
  {
    return _context.NewsThemes.ToList();
  }

  public IList<News> GetAllWithThemes()
  {
    return _context.News.Include(x => x.NewsTheme).ToList();
  }

  public News? GetById(int id)
  {
    return _context.News.Include(x => x.NewsTheme).FirstOrDefault(n => n.Id == id);
  }

  public News? GetByIdWithTheme(int id)
  {
    return _context.News.Include(x => x.NewsTheme).FirstOrDefault(n => n.Id == id);
  }

  public bool Save()
  {
    var saved = _context.SaveChanges();
    return saved > 0 ? true : false;
  }

  public bool Update(News news)
  {
    _context.Update(news);
    return Save();
  }
}
