using AutoMapper;
using CarLife.Application.Dto;
using CarLife.Core.Entities;
using CarLife.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarLife.WebUI.Controllers;
public class CarController : Controller
{
  private readonly UserManager<User> _userManager;
  private readonly CarLifeDbContext _context;
  private readonly IMapper _mapper;

  public CarController(UserManager<User> userManager,
            CarLifeDbContext context,
            IMapper mapper)
  {
    _context = context;
    _userManager = userManager;
    _mapper = mapper;
  }

  [HttpGet]
  public IActionResult Main()
  {

    var cars = _context.Cars.Include(c => c.User).ToList();
    var carsMainDto = _mapper.Map<List<CarMainDto>>(cars);
    return View(carsMainDto);
  }
  [HttpGet]
  public IActionResult Details(int id)
  {
    var car = _context.Cars.FirstOrDefault(c => c.Id == id);

    var carDetailDto = _mapper.Map<CarDetailDto>(car);

    return View(carDetailDto);
  }

  [HttpGet]
  public IActionResult Create()
  {
    var curUserId = _userManager.GetUserId(User);
    var createCarDto = new CarCreateDto { UserId = curUserId };
    return View(createCarDto);
  }
  [HttpPost]
  public async Task<IActionResult> Create(CarCreateDto carCreateDto)
  {
    if (!ModelState.IsValid) return View(carCreateDto);
    if (carCreateDto.UserId == null)
    {

      ModelState.AddModelError("User", "You Must be autorised");
      return View(carCreateDto);
    }
    else
    {
      var user = await _userManager.FindByIdAsync(carCreateDto.UserId);
      if (user == null)
      {
        ModelState.AddModelError("UserId", "The user was not found.");
        return View(carCreateDto);
      }
      var newCar = _mapper.Map<Car>(carCreateDto);
      newCar.User = user;

      _context.Cars.Add(newCar);
      await _context.SaveChangesAsync();

      var cars = _context.Cars.Include(c => c.User).ToList();
      var carsMainDto = _mapper.Map<List<CarMainDto>>(cars);
      return View("Main", carsMainDto);
    }
  }

  
}
