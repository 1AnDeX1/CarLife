using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarLife.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarLife.Infrastructure.Data.EntityTypeConfiguration;
internal class NewsEntityConfiguration : IEntityTypeConfiguration<News>
{
  public void Configure(EntityTypeBuilder<News> builder)
  {
    builder.HasKey(x => x.Id);

    builder.Property(x => x.Title)
      .IsRequired()
      .HasMaxLength(70);

    builder.Property(x => x.Description)
      .IsRequired();

    builder.Property(x => x.Text)
      .IsRequired();

    builder.Property(x => x.Theme)
      .IsRequired ();
  }
}
