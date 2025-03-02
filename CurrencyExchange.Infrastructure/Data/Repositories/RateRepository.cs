using CurrencyExchange.Core.Enities;
using CurrencyExchange.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CurrencyExchange.Infrastructure.Data.Repositories
{
    class RateRepository: Repository<ExchangeRate>, IRateRepository
    {
        private readonly AppDbContext _context;
        private readonly IRepository<ExchangeRate> _repository;

        public RateRepository(AppDbContext context, IRepository<ExchangeRate> repository)
        : base(context)
        {
            _context = context;
            _repository = repository;
        }

    }

}
