using CurrencyExchange.Core.Enities;
using CurrencyExchange.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Infrastructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context,
            IRepository<Currency> currencyRepository,
            IRepository<Country> countryRepository,
            IRepository<ExchangeRate> rateRepository
        )
        {
            _context = context;
            CurrencyRepository = currencyRepository;
            CountryRepository = countryRepository;
            RateRepository = rateRepository;

        }
        public IRepository<Currency> CurrencyRepository { get; private set; }
        public IRepository<ExchangeRate> RateRepository { get; private set; }

        public IRepository<Country> CountryRepository { get; private set; }

        public async Task<int> SaveChangeAsync() => await
            _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
       

      
       
    }
}
