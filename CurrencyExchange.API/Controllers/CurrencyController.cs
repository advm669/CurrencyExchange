using CurrencyExchange.Application.Services;
using CurrencyExchange.Core.Enities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyExchange.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly CurrencyService _currencyService;
        public CurrencyController(CurrencyService currencyService) {
            _currencyService = currencyService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Currency>>> GetAllCurrencies()
        {
            var currencies = await _currencyService.GetAllCurrenciesAsync();
            return Ok(currencies);
        }
        [HttpPost]
        public async Task<ActionResult<Currency>> AddCurrency([FromBody]Currency currency)
        {
           if(currency == null)
            {
                return BadRequest("Currency cannot be null.");
            }
            await _currencyService.AddCurrencyAsync(currency);
            return Ok(currency);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Currency>> UpdateCurrency(int id,[FromBody] Currency currency)
        {
            if (currency == null ||id !=currency.id)
            {
                return BadRequest("Currency ID mismatch.");
            }
            await _currencyService.UpdateCurrencyAsync(currency);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCurrency(int id)
        {
            await _currencyService.DeleteCurrencyAsync(id);
            return Ok();
        }

    }
}
