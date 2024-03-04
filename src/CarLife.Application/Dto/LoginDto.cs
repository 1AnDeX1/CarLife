using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLife.Application.Dto;

public class LoginDto
{
  [Display(Name = "Email Address")]
  [Required(ErrorMessage ="Email address is required")]
  public string? Email { get; set; }
  [Required]
  [DataType(DataType.Password)]
  public string? Password { get; set; }
}
