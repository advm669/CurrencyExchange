using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Core.Enities
{
   public class Country:BaseEntities
    {
        public string CountryName { get; set; } = null!;
        public string CountryCode { get; set; } = null!;
        public int? CourrencyId { get; set; }
        public Currency Currency { get; set; } = null!;
    }
}
