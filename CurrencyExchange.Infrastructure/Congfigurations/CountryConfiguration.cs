using CurrencyExchange.Core.Enities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Infrastructure.Congfigurations
{
    class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Countries");
            builder.HasKey(c => c.id);
            builder.Property(c => c.CountryName).IsRequired();
            builder.Property(c => c.CountryCode).IsRequired();
           builder.HasOne(c => c.Currency)
                  .WithMany(c => c.Countries)
                  .HasForeignKey(c => c.CourrencyId);



        }
    }

    
}
