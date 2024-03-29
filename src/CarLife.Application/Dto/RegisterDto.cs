﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLife.Application.Dto;
public class RegisterDto
{
  [Required(ErrorMessage = "Name is required")]
  public string? Name { get; set; }
  [Display(Name = "Email address")]
  [Required(ErrorMessage = "Email address is required")]
  public string? Email { get; set; }
  [Required]
  [DataType(DataType.Password)]
  public string? Password { get; set; }
  [Display(Name = "Confirm password")]
  [Required(ErrorMessage = "Confirm password is required")]
  [DataType(DataType.Password)]
  [Compare("Password", ErrorMessage = "Password do not match")]
  public string? ConfirmPassword { get; set; }

}
