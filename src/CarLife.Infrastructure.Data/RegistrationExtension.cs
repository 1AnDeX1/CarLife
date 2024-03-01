﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarLife.Infrastructure.Data;
public static class RegistrationExtension
{
  public static void AddStorage(this IServiceCollection serviceCollection, IConfiguration configuration)
  {
    serviceCollection.AddDbContext<CarLifeDbContext>(options =>
    {
      options.UseSqlServer(configuration["ConnectionStrings:MyConnection"]);
    } );
  }
}
