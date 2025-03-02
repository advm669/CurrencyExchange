using CurrencyExchange.Core.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Core.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<Currency> CurrencyRepository { get; }
        IRepository<ExchangeRate> RateRepository { get; }
        IRepository<Country> CountryRepository { get; }
        Task<int> SaveChangeAsync();
    }
}
