using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CarLife.Core.Entities;
using CarLife.Infrastructure.Data;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace CarLife.Application.Tests;
public class MainLogic
{
  public static News GenerateNews()
  {
    return new News
    {
      Id = 1,
      Title = "New car",
      Description = "One more car",
      Author = "Dealer",
      Text = "some text",
      Photo = "url",
      ThemeId = 1,
      DateOfPost = DateOnly.FromDateTime(DateTime.Now)
    };
  }
  public static List<News> GenerateNewsList()
  {
    List<News> newsList = new List<News>()
    {
        new News { Id = 1, Title = "New car", Description = "One more car", Author="Dealer",
          Text="some text", Photo="url", ThemeId= 1,
          DateOfPost = DateOnly.FromDateTime(DateTime.Now)},
        new News { Id = 2, Title = "New car2", Description = "One more car2", Author="Dealer2",
          Text="some text2", Photo="url2", ThemeId= 3,
          DateOfPost = DateOnly.FromDateTime(DateTime.Now)},
        new News { Id = 3, Title = "New car3", Description = "One more car3", Author="Dealer3",
          Text="some text3", Photo="url3", ThemeId= 1,
          DateOfPost = DateOnly.FromDateTime(DateTime.Now)},
    };
    return newsList;
  }
  public static NewsThemes GenerateTheme()
  {
    return new NewsThemes
    {
      Id = 1,
      Name = "Theme 1"
    };
  }
  public static List<NewsThemes> GenerateThemeList()
  {
    List<NewsThemes> themeList = new ()
    {
      new NewsThemes {Id = 1, Name = "Theme 1" },
      new NewsThemes {Id = 2, Name = "Theme 2" },
      new NewsThemes {Id = 3, Name = "Theme 3" },
    };
    return themeList;
  }
  public static void MainNewsCheck(News? news, News addedNews)
  {
    news.Should().NotBeNull();
    news.Should().BeOfType<News>();

    news?.Id.Should().BeGreaterThan(0);
    news?.Title.Should().NotBeNullOrEmpty();
    news?.Description.Should().NotBeNullOrEmpty();
    news?.Author.Should().NotBeNullOrEmpty();
    news?.Text.Should().NotBeNullOrEmpty();
    news?.Photo.Should().NotBeNullOrEmpty();
    news?.ThemeId.Should().NotBeNull();

    news?.Title.Should().Be(addedNews.Title);
    news?.Description.Should().Be(addedNews.Description);
    news?.Author.Should().Be(addedNews.Author);
    news?.Text.Should().Be(addedNews.Text);
    news?.Photo.Should().Be(addedNews.Photo);
    news?.ThemeId.Should().Be(addedNews.ThemeId);
    news?.DateOfPost.Should().Be(addedNews.DateOfPost);
  }
  public static void MainNewsThemeCheck(NewsThemes? newsTheme, NewsThemes addedNewsThemes)
  {
    newsTheme.Should().NotBeNull();
    newsTheme.Should().BeOfType<NewsThemes>();

    newsTheme?.Id.Should().BeGreaterThan(0);
    newsTheme?.Name.Should().NotBeNullOrEmpty();

    newsTheme?.Id.Should().Be(addedNewsThemes.Id);
    newsTheme?.Name.Should().Be(addedNewsThemes.Name);
  }

}
