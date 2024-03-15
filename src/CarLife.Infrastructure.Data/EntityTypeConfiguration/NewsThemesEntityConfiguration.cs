using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarLife.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarLife.Infrastructure.Data.EntityTypeConfiguration;
public class NewsThemesEntityConfiguration : IEntityTypeConfiguration<NewsThemes>
{
  public void Configure(EntityTypeBuilder<NewsThemes> builder)
  {
    builder.HasKey(x => x.Id);
  }
}
