using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarLife.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarLife.Infrastructure.Data.EntityTypeConfiguration;
internal class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
  public void Configure(EntityTypeBuilder<User> builder)
  {

    builder.Property(x => x.Name)
      .IsRequired()
      .HasMaxLength(100);
  }
}
