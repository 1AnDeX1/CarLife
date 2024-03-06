using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarLife.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarLife.Infrastructure.Data.EntityTypeConfiguration;
internal class CarEntityConfiguration : IEntityTypeConfiguration<Car>
{
  public void Configure(EntityTypeBuilder<Car> builder)
  {
    builder.HasKey(x => x.Id);

    builder.Property(x => x.Mark)
      .IsRequired()
      .HasMaxLength(100);

    builder.Property(x => x.Price)
      .IsRequired();

    builder.Property(x => x.Mileage)
      .IsRequired();

    //builder.Property(x => x.Photo)
    //  .IsRequired();

    builder.Property(x => x.YearOfManufecture)
      .IsRequired();

    builder.Property(x => x.Model)
      .IsRequired()
      .HasMaxLength(100);

    builder.Property(x => x.City)
      .IsRequired()
      .HasMaxLength(100);

    builder.Property(x => x.Colour)
      .IsRequired()
      .HasMaxLength(100);

  }
}
