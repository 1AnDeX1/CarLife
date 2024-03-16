using CarLife.Application.IServices;
using CarLife.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace CarLife.WebUI.Controllers;
public class ProfileController : Controller
{
  private readonly IUserService _userService;

  public ProfileController(IUserService userService)
  {
    _userService = userService;
  }

  public IActionResult Index()
  {
    var userCars = _userService.GetAllUserCars();

    return View(userCars);
  }
}
