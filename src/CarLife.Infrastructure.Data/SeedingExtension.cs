using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;


namespace CarLife.Infrastructure.Data;
public static class SeedingExtension
{
  public static async Task SeedRolesAsync(IApplicationBuilder applicationBuilder)
  {
    using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
    {
      var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

      if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
        await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
      if (!await roleManager.RoleExistsAsync(UserRoles.User))
        await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
    }
  }
}
