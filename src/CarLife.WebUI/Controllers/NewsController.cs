using AutoMapper;
using CarLife.Application.Dto.News;
using CarLife.Application.IServices;
using CarLife.Core.Entities;
using CarLife.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarLife.WebUI.Controllers;
public class NewsController : Controller
{
  private readonly INewsService _newsService;
  private readonly IMapper _mapper;
  public NewsController(INewsService newsService, IMapper mapper)
  {
    _newsService = newsService;
    _mapper = mapper;
  }
  [HttpGet]
  public IActionResult Index(int filter)
  {
    var news = _newsService.GetFilteredNews(filter);
    var themes = _newsService.GetAllThemes();
    var newsIndexDto = _mapper.Map<List<NewsIndexDto>>(news);

    var newsFilterIndexDto = new NewsFilterIndexDto
    {
      News = newsIndexDto,
      Themes = themes
    };

    return View(newsFilterIndexDto);
  }

  [HttpGet]
  public IActionResult Details(int id)
  {
    var news = _newsService.GetByIdWithTheme(id);
    if (news == null) return NotFound();
    var newsDetailDto = _mapper.Map<NewsDetailsDto>(news);
    return View(newsDetailDto);
  }

  [HttpGet]
  public IActionResult Add()
  {
    var model = new NewsCreateDto
    {
      NewsThemes = _newsService.GetAllThemes()
    };
    return View(model);
  }
  [HttpPost]
  public IActionResult Add(NewsCreateDto newsCreateDto)
  {
    if (!ModelState.IsValid) return View(newsCreateDto);


    var newNews = _mapper.Map<News>(newsCreateDto);
    newNews.DateOfPost = DateOnly.FromDateTime(DateTime.Now);

    _newsService.Add(newNews);

    return RedirectToAction("Index");
  }

  [HttpGet]
  public IActionResult Delete(int id)
  {
    var news = _newsService.GetById(id);

    if (news == null)
      return NotFound();

    return View(new NewsIndexDto { Id = news.Id, Title = news.Title });
  }

  [HttpPost, ActionName("Delete")]
  public IActionResult DeleteNews(int id)
  {
    var news = _newsService.GetById(id);

    if (news == null)
      return NotFound();

    _newsService.Delete(news);

    return RedirectToAction("Index");
  }
}
