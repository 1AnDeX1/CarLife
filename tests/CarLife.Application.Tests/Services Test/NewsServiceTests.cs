using CarLife.Application.IServices;
using CarLife.Application.Services;
using CarLife.Infrastructure.Data;
using Moq;
using Xunit;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using CarLife.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using CarLife.Infrastructure.Data.Migrations;


namespace CarLife.Application.Tests.Services_Test;
public class NewsServiceTests
{
  DbContextOptionsBuilder<CarLifeDbContext> optionBuilder = new();

  [Fact]
  public void GetAll_ReceiveListOfNews_ExistingData()
  {
    // Arrange
    optionBuilder.UseInMemoryDatabase(MethodBase.GetCurrentMethod()?.Name ?? "DefaultDb");
    List<News> newsList = MainLogic.GenerateNewsList();

    // Act
    using (CarLifeDbContext context = new(optionBuilder.Options))
    {
      context.AddRange(newsList);
      context.SaveChanges();
    }
    IList<News> result;
    using (CarLifeDbContext context = new(optionBuilder.Options))
    {
      result = new NewsService(context).GetAll();
    }

    // Assert
    result.Should().NotBeNullOrEmpty();
    result.Should().HaveCount(3);
    result.Should().BeOfType<List<News>>();
    foreach (var news in result)
    {
      int id = news.Id-1;
      MainLogic.MainNewsCheck(news, newsList[id]);
    }
  }

  [Fact]
  public void GetAll_ReceiveNull_NoData()
  {
    // Arrange
    optionBuilder.UseInMemoryDatabase(MethodBase.GetCurrentMethod()?.Name ?? "DefaultDb");
    // Act

    IList<News> result;
    using (CarLifeDbContext context = new(optionBuilder.Options))
    {
      result = new NewsService(context).GetAll();
    }

    // Assert
    result.Should().BeNullOrEmpty();
  }

  [Fact]
  public void GetById_ReceiveNewsById_ExistingData()
  {
    // Arrange
    optionBuilder.UseInMemoryDatabase(MethodBase.GetCurrentMethod()?.Name ?? "DefaultDb");
    News news = MainLogic.GenerateNews();

    // Act
    using (CarLifeDbContext context = new(optionBuilder.Options))
    {
      context.Add(news);
      context.SaveChanges();
    }
    News? result;
    using (CarLifeDbContext context = new(optionBuilder.Options))
    {
      result = new NewsService(context).GetById(1);
    }

    // Assert
    MainLogic.MainNewsCheck(result, news);

  }

  [Fact]
  public void GetById_ReceiveNull_UnExistingId()
  {
    // Arrange
    optionBuilder.UseInMemoryDatabase(MethodBase.GetCurrentMethod()?.Name ?? "DefaultDb");
    News news = MainLogic.GenerateNews();

    // Act
    using (CarLifeDbContext context = new(optionBuilder.Options))
    {
      context.Add(news);
      context.SaveChanges();
    }
    News? result;
    using (CarLifeDbContext context = new(optionBuilder.Options))
    {
      result = new NewsService(context).GetById(2);
    }

    // Assert
    result.Should().BeNull();

  }

  [Fact]
  public void GetByIdWithTheme_ReceiveNewsById_ExistingData()
  {
    // Arrange
    optionBuilder.UseInMemoryDatabase(MethodBase.GetCurrentMethod()?.Name ?? "DefaultDb");
    News news = MainLogic.GenerateNews();
    NewsThemes newsTheme = MainLogic.GenerateTheme();

    // Act
    using (CarLifeDbContext context = new(optionBuilder.Options))
    {
      context.Add(news);
      context.Add(newsTheme);
      context.SaveChanges();
    }
    News? result;
    using (CarLifeDbContext context = new(optionBuilder.Options))
    {
      result = new NewsService(context).GetByIdWithTheme(1);
    }

    // Assert
    MainLogic.MainNewsCheck(result, news);
    MainLogic.MainNewsThemeCheck(result?.NewsTheme, newsTheme);
  }

  [Fact]
  public void GetAllThemes_ReceiveListOfNewsThemes_ExistingData()
  {
    // Arrange
    optionBuilder.UseInMemoryDatabase(MethodBase.GetCurrentMethod()?.Name ?? "DefaultDb");
    List<NewsThemes> newsThemes = MainLogic.GenerateThemeList();
    // Act
    using (CarLifeDbContext context = new(optionBuilder.Options))
    {
      context.AddRange(newsThemes);
      context.SaveChanges();
    }
    IList<NewsThemes> result;
    using (CarLifeDbContext context = new(optionBuilder.Options))
    {
      result = new NewsService(context).GetAllThemes();
    }

    // Assert
    result.Should().NotBeNullOrEmpty();
    result.Should().HaveCount(3);
    result.Should().BeOfType<List<NewsThemes>>();
    foreach (var theme in result)
    {
      int id = theme.Id - 1;
      MainLogic.MainNewsThemeCheck(theme, newsThemes[id]);
    }
  }

  [Fact]
  public void GetAllThemes_ReceiveNull_NoData()
  {
    // Arrange
    optionBuilder.UseInMemoryDatabase(MethodBase.GetCurrentMethod()?.Name ?? "DefaultDb");
    // Act

    IList<NewsThemes> result;
    using (CarLifeDbContext context = new(optionBuilder.Options))
    {
      result = new NewsService(context).GetAllThemes();
    }

    // Assert
    result.Should().BeNullOrEmpty();
  }

  [Fact]
  public void GetAllWithThemes_ReceiveNewsWithThemes_ExistingData()
  {
    // Arrange
    optionBuilder.UseInMemoryDatabase(MethodBase.GetCurrentMethod()?.Name ?? "DefaultDb");
    List<News> newsList = MainLogic.GenerateNewsList();
    List<NewsThemes> newsThemes = MainLogic.GenerateThemeList();

    // Act
    using (CarLifeDbContext context = new(optionBuilder.Options))
    {
      context.AddRange(newsList);
      context.AddRange(newsThemes);
      context.SaveChanges();
    }
    IList<News>? result;
    using (CarLifeDbContext context = new(optionBuilder.Options))
    {
      result = new NewsService(context).GetAllWithThemes();
    }
    // Assert
    foreach (var news in result)
    {
      int id = news.Id - 1;
      MainLogic.MainNewsCheck(news, newsList[id]);

      news.NewsTheme.Should().NotBeNull();
      news.NewsTheme.Should().BeOfType<NewsThemes>();

      news.NewsTheme?.Id.Should().BeGreaterThan(0);
      news.NewsTheme?.Name.Should().NotBeNullOrEmpty();
    }
  }

  [Fact]
  public void GetAllWithThemes_ReceiveNull_NoData()
  {
    // Arrange
    optionBuilder.UseInMemoryDatabase(MethodBase.GetCurrentMethod()?.Name ?? "DefaultDb");

    // Act

    IList<News>? result;
    using (CarLifeDbContext context = new(optionBuilder.Options))
    {
      result = new NewsService(context).GetAllWithThemes();
    }
    // Assert
    result.Should().BeNullOrEmpty();
  }

  [Fact]
  public void GetFilteredNews_ReceiveNewsWithThemes_ExistingData()
  {
    // Arrange
    optionBuilder.UseInMemoryDatabase(MethodBase.GetCurrentMethod()?.Name ?? "DefaultDb");
    List<News> newsList = MainLogic.GenerateNewsList();
    List<NewsThemes> newsThemes = MainLogic.GenerateThemeList();
    int filter = 1;
    // Act
    using (CarLifeDbContext context = new(optionBuilder.Options))
    {
      context.AddRange(newsList);
      context.AddRange(newsThemes);
      context.SaveChanges();
    }
    IList<News>? result;
    using (CarLifeDbContext context = new(optionBuilder.Options))
    {
      result = new NewsService(context).GetFilteredNews(filter);
    }
    // Assert
    foreach (var news in result)
    {
      int id = news.Id - 1;
      MainLogic.MainNewsCheck(news, newsList[id]);

      news.NewsTheme.Should().NotBeNull();
      news.NewsTheme.Should().BeOfType<NewsThemes>();

      news.NewsTheme?.Id.Should().BeGreaterThan(0);
      news.NewsTheme?.Name.Should().NotBeNullOrEmpty();

      news.NewsTheme?.Id.Should().Be(filter);
    }
  }

  [Fact]
  public void GetFilteredNews_ReceiveNewsWithThemes_ZeroIndex()
  {
    // Arrange
    optionBuilder.UseInMemoryDatabase(MethodBase.GetCurrentMethod()?.Name ?? "DefaultDb");
    List<News> newsList = MainLogic.GenerateNewsList();
    List<NewsThemes> newsThemes = MainLogic.GenerateThemeList();
    int filter = 0;
    // Act
    using (CarLifeDbContext context = new(optionBuilder.Options))
    {
      context.AddRange(newsList);
      context.AddRange(newsThemes);
      context.SaveChanges();
    }
    IList<News>? result;
    using (CarLifeDbContext context = new(optionBuilder.Options))
    {
      result = new NewsService(context).GetFilteredNews(filter);
    }
    // Assert
    foreach (var news in result)
    {
      int id = news.Id - 1;
      MainLogic.MainNewsCheck(news, newsList[id]);

      news.NewsTheme.Should().NotBeNull();
      news.NewsTheme.Should().BeOfType<NewsThemes>();

      news.NewsTheme?.Id.Should().BeGreaterThan(0);
      news.NewsTheme?.Name.Should().NotBeNullOrEmpty();
    }
  }

  [Fact]
  public void GetFilteredNews_ReceiveNull_WrongIndex()
  {
    // Arrange
    optionBuilder.UseInMemoryDatabase(MethodBase.GetCurrentMethod()?.Name ?? "DefaultDb");
    
    List<News> newsList = MainLogic.GenerateNewsList();
    List<NewsThemes> newsThemes = MainLogic.GenerateThemeList();
    int filter = -1;

    // Act
    using (CarLifeDbContext context = new(optionBuilder.Options))
    {
      context.AddRange(newsList);
      context.AddRange(newsThemes);
      context.SaveChanges();
    }
    IList<News>? result;
    using (CarLifeDbContext context = new(optionBuilder.Options))
    {
      result = new NewsService(context).GetFilteredNews(filter);
    }
    // Assert
    result.Should().BeNullOrEmpty();
  }

  [Fact]
  public void GetFilteredNews_ReceiveNull_NoData()
  {
    // Arrange
    optionBuilder.UseInMemoryDatabase(MethodBase.GetCurrentMethod()?.Name ?? "DefaultDb");
    int filter = 1;

    // Act
    IList<News>? result;
    using (CarLifeDbContext context = new(optionBuilder.Options))
    {
      result = new NewsService(context).GetFilteredNews(filter);
    }

    // Assert
    result.Should().BeNullOrEmpty();
  }

  [Fact]
  public void Add_ReceiveTrue_ExistingData()
  {
    // Arrange
    optionBuilder.UseInMemoryDatabase(MethodBase.GetCurrentMethod()?.Name ?? "DefaultDb");
    News news = MainLogic.GenerateNews();
    // Act

    bool result;
    using (CarLifeDbContext context = new(optionBuilder.Options))
    {
      result = new NewsService(context).Add(news);
    }

    // Assert
    result.Should().BeTrue();

  }

  [Fact]
  public void Delete_ReceiveTrue_ExistingData()
  {
    // Arrange
    optionBuilder.UseInMemoryDatabase(MethodBase.GetCurrentMethod()?.Name ?? "DefaultDb");
    News news = MainLogic.GenerateNews();

    // Act

    bool result;
    using (CarLifeDbContext context = new(optionBuilder.Options))
    {
      var newscontext = new NewsService(context);
      newscontext.Add(news);
      result = newscontext.Delete(news);
    }

    // Assert
    result.Should().BeTrue();
  }

  [Fact]
  public void Update_ReceiveTrue_ExistingData()
  {
    // Arrange
    optionBuilder.UseInMemoryDatabase(MethodBase.GetCurrentMethod()?.Name ?? "DefaultDb");
    News news = MainLogic.GenerateNews();
    var updated = new News
    {
      Id = 1,
      Title = "Updated car",
      Description = "One more car",
      Author = "Updated Dealer",
      Text = "some text",
      Photo = "Updated url",
      ThemeId = 1,
      DateOfPost = DateOnly.FromDateTime(DateTime.Now)
    };
    using (CarLifeDbContext context = new(optionBuilder.Options))
    {
      var adding = new NewsService(context).Add(news);
    }

    // Act
    bool result;
    using (CarLifeDbContext context = new(optionBuilder.Options))
    {
      result = new NewsService(context).Update(updated);
    }

    // Assert
    result.Should().BeTrue();
  }
  
}
