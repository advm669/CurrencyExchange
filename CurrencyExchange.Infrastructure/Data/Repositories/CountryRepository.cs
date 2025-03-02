using CurrencyExchange.Core.Enities;
using CurrencyExchange.Core.Interfaces;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text; 
using System.Threading.Tasks;

namespace CurrencyExchange.Infrastructure.Data.Repositories
{   
   public class CountryRepository :Repository<Country>,ICountryRepository
    {
        private readonly AppDbContext _context;
        private readonly IRepository<Country> _repository;

        public CountryRepository(AppDbContext context,IRepository<Country> repository) 
        : base(context)
        {
            _context = context;
            _repository = repository;
        }

    }
}
