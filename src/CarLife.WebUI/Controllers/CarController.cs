using AutoMapper;
using CarLife.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using CarLife.Application.Interfaces;
using CarLife.Application.Classes;
using CarLife.Application.Dto.Car;
using CarLife.Application.IServices;

namespace CarLife.WebUI.Controllers;
public class CarController : Controller
{
  private readonly UserManager<User> _userManager;
  private readonly IMapper _mapper;
  private readonly ICarService _carService;
  private readonly IFavoriteCarsService _favoriteCarsService;

  public CarController(UserManager<User> userManager,
            ICarService carService,
            IFavoriteCarsService favoriteCarsService,
            IMapper mapper)
  {
    _userManager = userManager;
    _mapper = mapper;
    _carService = carService;
    _favoriteCarsService = favoriteCarsService;
  }

  [HttpGet]
  public IActionResult Main(string sort)
  {
    var cars = _carService.GetSortedCars(sort);
    var carsMainDto = _mapper.Map<List<CarMainDto>>(cars);

    ViewData["Sort"] = sort ?? "default";

    return View(carsMainDto);
  }
  [HttpPost]
  public IActionResult Main(CarSortItems carSortItems)
  {
    if (!ModelState.IsValid) 
      return View(carSortItems);

    ViewData["Mark"] = carSortItems.Mark;
    ViewData["Model"] = carSortItems.Model;
    ViewData["PriceFrom"] = carSortItems.PriceFrom;
    ViewData["PriceTo"] = carSortItems.PriceTo;
    ViewData["MileageFrom"] = carSortItems.MileageFrom;
    ViewData["MileageTo"] = carSortItems.MileageTo;
    ViewData["YearOfManufectureFrom"] = carSortItems.YearOfManufectureFrom;
    ViewData["YearOfManufectureTo"] = carSortItems.YearOfManufectureTo;
    ViewData["City"] = carSortItems.City;

    var cars = _carService.GetFilteredCars(carSortItems);
    var carsMainDto = _mapper.Map<List<CarMainDto>>(cars);

    return View(carsMainDto);
  }
  [HttpGet]
  public IActionResult Details(int id)
  {
    var car = _carService.GetById(id);
    var carDetailDto = _mapper.Map<CarDetailDto>(car);

    var favorite = _favoriteCarsService.GetFavoriteCar(id);
    if (favorite != null)
    {
      carDetailDto.IsFavorite = true;
    }
    else
    {
      carDetailDto.IsFavorite = false;
    }

    return View(carDetailDto);
  }
  [HttpGet]
  public IActionResult Edit(int id)
  {
    var car = _carService.GetById(id);
    var carDetailDto = _mapper.Map<CarEditDto>(car);

    return View(carDetailDto);
  }

  [HttpPost]
  public IActionResult Edit(CarEditDto carEditDto)
  {
    if (!ModelState.IsValid) return View(carEditDto);
    var newCar = _mapper.Map<Car>(carEditDto);

    _carService.Update(newCar);


    var cars = _carService.GetAll();
    var carsMainDto = _mapper.Map<List<CarMainDto>>(cars);
    return View("Main", carsMainDto);
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

      TempData["Error"] = "You Must be authorised";
      return View(carCreateDto);
    }
    else
    {
      var user = await _userManager.FindByIdAsync(carCreateDto.UserId);
      if (user == null)
      {
        TempData["Error"] = "The user was not found.";
        return View(carCreateDto);
      }
      var newCar = _mapper.Map<Car>(carCreateDto);
      newCar.User = user;

      _carService.Add(newCar);
      
      var cars = _carService.GetAll();
      var carsMainDto = _mapper.Map<List<CarMainDto>>(cars);
      return View("Main", carsMainDto);
    }
  }

  [HttpPost]
  public IActionResult AddToFavorite(int id)
  {

    var curUserId = _userManager.GetUserId(User);

    if (User.Identity != null && !User.Identity.IsAuthenticated)
    {
      TempData["Status"] = "You Must be authorised";
      return RedirectToAction("Details", "Car", new { id });
    }

    var favorite = _favoriteCarsService.GetFavoriteCar(id);

    if (favorite == null)
    {
      favorite = new FavoriteCars
      {
        UserId = curUserId,
        CarId = id
      };
      var added = _favoriteCarsService.AddToFavorite(favorite);

      if (!added)
      {
        TempData["Status"] = "Failed";
        return RedirectToAction("Details", "Car", new { id });
      }
    }
    else
    {
      _favoriteCarsService.Delete(favorite);
    }
    return RedirectToAction("Details", "Car", new { id });
  }

  [HttpPost]
  public IActionResult Delete(int id)
  {
    var car = _carService.GetById(id);

    if (car != null)
    {
        _carService.Delete(car);
    }

    return RedirectToAction("Main", "Car");
  }

  
}
