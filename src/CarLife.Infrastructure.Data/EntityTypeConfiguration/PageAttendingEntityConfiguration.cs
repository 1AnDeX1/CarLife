using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarLife.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarLife.Infrastructure.Data.EntityTypeConfiguration;
internal class PageAttendingEntityConfiguration : IEntityTypeConfiguration<PageAttending>
{
  public void Configure(EntityTypeBuilder<PageAttending> builder)
  {
    builder.HasKey(x => x.Id);

    builder.Property(x => x.DateOfAttending)
      .IsRequired();
  }
}
