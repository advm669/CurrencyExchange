using CountryData.Standard;
using CurrencyExchange.Application.Services;
using CurrencyExchange.Core.Interfaces;
using CurrencyExchange.Infrastructure.Data;
using CurrencyExchange.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Infrastructure.Extensions
{
   public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string connectionString)
        {
            //Register DbContext 
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(ICountryRepository), typeof(CountryRepository));
            services.AddScoped(typeof(ICurrencyRepository), typeof(CurrencyRepository));
            services.AddScoped(typeof(IRateRepository), typeof(RateRepository));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<CurrencyService>();

            return services;
        }

        public static void SeedData(this IServiceProvider services)
        {
            //Seed data
            using (var scope =services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                //Apply migrations
                context.Database.Migrate();

                //Seed data

                if (!context.Countries.Any())
                {
                    var countriesList = new List<CurrencyExchange.Core.Enities.Country>();
                    var currenciesList = new List<CurrencyExchange.Core.Enities.Currency>();
                    var helper = new CountryHelper();

                    var countriesData = helper.GetCountryData().ToList();

                    foreach (var countryData in countriesData)
                    {
                        var countryCurrency = countryData.Currency?.FirstOrDefault();
                        if (countryCurrency != null && !string.IsNullOrEmpty(countryCurrency.Name))
                        {
                            var currency = new CurrencyExchange.Core.Enities.Currency
                            {
                                CurrencyName = countryCurrency.Name,
                                CurrencyCode = countryCurrency.Code,
                                //CountryId = context.Countries.FirstOrDefault(c => c.CountryName == countryData.CountryName)?.Id
                            };
                            currenciesList.Add(currency);
                        }
                    }
                    context.Currencies.AddRangeAsync(currenciesList.Distinct());
                    context.SaveChanges();

                    foreach (var countryData in countriesData)
                    {
                        if (countryData.Currency != null)
                        {
                            var curencyCode = helper.GetCurrencyCodesByCountryCode(countryData.CountryShortCode).FirstOrDefault()?.Code;

                            var country = new CurrencyExchange.Core.Enities.Country
                            {
                                CountryName = countryData.CountryName,
                                CountryCode = countryData.CountryShortCode,
                                CourrencyId = context.Currencies.Where(c => c.CurrencyCode == curencyCode).FirstOrDefault()?.id
                            };
                            countriesList.Add(country);
                        }
                    }
                    context.Countries.AddRangeAsync(countriesList);
                    context.SaveChanges();
                }
            }



        }

    }
}
