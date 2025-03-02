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
    class ExchangeRateConfiguration : IEntityTypeConfiguration<ExchangeRate>
    {
        public void Configure(EntityTypeBuilder<ExchangeRate> builder)
        {
            builder.ToTable("ExchangeRates");
            builder.HasKey(c => c.id);
            builder.Property(c => c.Rate).HasPrecision(18, 6)
                .IsRequired();
            builder.Property(c => c.RateDate).IsRequired();
            builder.HasOne(c => c.Currency)
                .WithMany(c => c.Rates);
              


        }
    }
}

