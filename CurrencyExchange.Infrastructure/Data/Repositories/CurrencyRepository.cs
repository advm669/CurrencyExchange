using CurrencyExchange.Core.Enities;
using CurrencyExchange.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Infrastructure.Data.Repositories
{
    class CurrencyRepository:Repository<Currency>,ICurrencyRepository
    {
        private readonly AppDbContext _context;
    private readonly IRepository<Currency> _repository;

    public CurrencyRepository(AppDbContext context, IRepository<Currency> repository)
    : base(context)
    {
        _context = context;
        _repository = repository;
    }

}
  
}
