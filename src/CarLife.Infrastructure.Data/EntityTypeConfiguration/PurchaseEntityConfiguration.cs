using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarLife.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarLife.Infrastructure.Data.EntityTypeConfiguration;
internal class PurchaseEntityConfiguration : IEntityTypeConfiguration<Purchase>
{
  public void Configure(EntityTypeBuilder<Purchase> builder)
  {
    builder.HasKey(x => x.Id);

    builder.Property(x => x.TimeOfPurchase)
      .IsRequired();
  }
}
