using System.Security.Claims;
using CarLife.Application.Dto;
using CarLife.Core.Entities;
using CarLife.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CarLife.WebUI.Controllers;
public class AccountController : Controller
{
  private readonly UserManager<User> _userManager;
  private readonly SignInManager<User> _signInManager;
  private readonly CarLifeDbContext _context;

  public AccountController(UserManager<User> userManager,
            SignInManager<User> signInManager,
            CarLifeDbContext context)
  {
    _context = context;
    _signInManager = signInManager;
    _userManager = userManager;
  }
  [HttpGet]
  public IActionResult Login()
  {
    var response = new LoginDto();
    return View(response);
  }

  [HttpPost]
  public async Task<IActionResult> Login(LoginDto loginDto)
  {
    if (!ModelState.IsValid) return View(loginDto);
    if (loginDto.Email == null || loginDto.Password == null)
    {
      ModelState.AddModelError("EmailAddress", "Email address is required");
      ModelState.AddModelError("Password", "Password is required");
      return View(loginDto);
    }
    var user = await _userManager.FindByEmailAsync(loginDto.Email);

    if (user != null && user.UserName != null)
    {
      var passwordCheck = await _userManager.CheckPasswordAsync(user, loginDto.Password);
      if (passwordCheck)
      {
        var result = await _signInManager.PasswordSignInAsync(user.UserName, loginDto.Password, false, false);
        if (result.Succeeded)
        {
          return RedirectToAction("Index", "Home");
        }
      }
      TempData["Error"] = "Wrong credentials. Please try again";
      return View(loginDto);
    }
    TempData["Error"] = "Wrong credentials. Please try again";
    return View(loginDto);
  }

  [HttpGet]
  public IActionResult Register()
  {
    var response = new RegisterDto();
    return View(response);
  }

  [HttpPost]
  public async Task<IActionResult> Register(RegisterDto registerDto)
  {
    
    if (!ModelState.IsValid) return View(registerDto);
    if (registerDto.Email == null || registerDto.Password == null)
    {
      ModelState.AddModelError("EmailAddress", "Email address is required");
      ModelState.AddModelError("Password", "Password is required");
      return View(registerDto);
    }
    var user = await _userManager.FindByEmailAsync(registerDto.Email);
    if (user != null)
    {
      TempData["Error"] = "This email address is already in use";
      return View(registerDto);
    }

    var newUser = new User()
    {
      Email = registerDto.Email,
      UserName = registerDto.Name,
      Rating = null
    };

    var newUserResponse = await _userManager.CreateAsync(newUser, registerDto.Password);

    if (newUserResponse.Succeeded)
    {
      await _userManager.AddPasswordAsync(newUser, registerDto.Password);
      await _userManager.AddToRoleAsync(newUser, UserRoles.User);
    }
    else
    {
      ModelState.AddModelError("Password", "Password need aA!1 and be at least 8 in length");
      return View(registerDto);
    }

    return RedirectToAction("Index", "Home");
  }

  [HttpGet]
  public async Task<IActionResult> Logout()
  {
    await _signInManager.SignOutAsync();
    return RedirectToAction("Index", "Home");
  }


}
