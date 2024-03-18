using CarLife.Application;
using CarLife.Application.Dto.Profile;
using CarLife.Application.IServices;
using CarLife.Application.Services;
using CarLife.Core.Entities;
using CarLife.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarLife.WebUI.Controllers;
public class ProfileController : Controller
{
  private readonly IUserService _userService;
  private readonly IHttpContextAccessor _httpContextAccessor;
  private readonly IFavoriteCarsService _favoriteCarsService;

  public ProfileController(IUserService userService,
    IHttpContextAccessor httpContextAccessor,
    IFavoriteCarsService favoriteCarsService)
  {
    _userService = userService;
    _httpContextAccessor = httpContextAccessor;
    _favoriteCarsService = favoriteCarsService;
  }

  public IActionResult Index()
  {
    var userCars = _userService.GetAllUserCars();
    var userFavoriteCars = _userService.GetAllUserFavoriteCars();

    var profileDto = new ProfileDto()
    {
      Cars = userCars,
      FavoriteCars = userFavoriteCars
    };
    return View(profileDto);
  }

  [HttpPost]
  public IActionResult DeleteFromFavorite(int id)
  {
    var favorite = _favoriteCarsService.GetFavoriteCar(id);
    if (favorite != null)
    {
      _favoriteCarsService.Delete(favorite);
    }

    return RedirectToAction("Index", "Profile");
  }
}
