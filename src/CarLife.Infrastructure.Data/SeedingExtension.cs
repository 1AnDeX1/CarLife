using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;


namespace CarLife.Infrastructure.Data;
public static class SeedingExtension
{
  public static async Task DatabaseEnsureCreated(this IApplicationBuilder applicationBuilder)
  {
    using (var scope = applicationBuilder.ApplicationServices.CreateScope())
    {
      var dbContext = scope.ServiceProvider.GetRequiredService<CarLifeDbContext>();
      var database = dbContext.Database;

      await database.EnsureDeletedAsync();
      await database.EnsureCreatedAsync();
    }
  }
}
