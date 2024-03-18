using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CarLife.Application;
public static class ClaimsPrincipalExtensions
{
  public static string GetUserId(this ClaimsPrincipal user)
  {
    var claim = user.FindFirst(ClaimTypes.NameIdentifier);
    if (claim == null)
    {
      throw new ArgumentException("NameIdentifier claim not found");
    }

    return claim.Value;
  }
}
