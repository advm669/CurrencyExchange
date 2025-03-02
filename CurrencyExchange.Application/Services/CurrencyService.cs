
using CurrencyExchange.Core.Enities;
using CurrencyExchange.Core.Interfaces;

namespace CurrencyExchange.Application.Services
{
    public class CurrencyService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CurrencyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Currency>>GetAllCurrenciesAsync()
        {
            return await _unitOfWork.CurrencyRepository.GetAllAsync();

        }
        
        public async Task AddCurrencyAsync(Currency currency)
        {
            await _unitOfWork.CurrencyRepository.CreateAsync(currency);
            await _unitOfWork.SaveChangeAsync();
        }
        public async Task UpdateCurrencyAsync(Currency currency)
        {
             await _unitOfWork.CurrencyRepository.UpdateAsync(currency);
            await _unitOfWork.SaveChangeAsync();
        }
        public async Task DeleteCurrencyAsync(int id)
        {
            var currency = await _unitOfWork.CurrencyRepository.GetAsync(c => c.id == id);
            if (currency is not null)
            {
                await _unitOfWork.CurrencyRepository.RemoveAsync(currency);
                await _unitOfWork.SaveChangeAsync();
            }
        }
    }
}
