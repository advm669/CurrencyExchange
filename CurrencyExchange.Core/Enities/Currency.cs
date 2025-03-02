﻿using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CurrencyExchange.Core.Enities
{
    public class Currency : BaseEntities
    {
        public string CurrencyName { get; set; } = null!;
        public string CurrencyCode { get; set; } = null!;

        [JsonIgnore]
        public ICollection<Country> Countries { get; set; } = null!;
        [JsonIgnore]

        public ICollection<ExchangeRate> Rates { get; set; } = null!;
     
    }
}
