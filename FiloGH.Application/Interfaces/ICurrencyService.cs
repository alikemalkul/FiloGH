using FiloGH.Core.Entities;
using FiloGH.Core.Interfaces;

namespace FiloGH.Application.Interfaces
{
    /// <summary>
    /// Currency (Para Birimi) varlığı için iş mantığı arayüzü.
    /// Tüm CRUD ve detaylı sorgulama metotlarını IBaseService<Currency, byte>'den kalıtım yoluyla alır.
    /// </summary>
    public interface ICurrencyService : IBaseService<Currency, byte>
    {
        // IBaseService'den gelen metotlar artık burada tekrar tanımlanmaz:
        // Task<IEnumerable<Currency>> GetAllAsync(...)
        // Task<Currency?> GetByIdAsync(byte id, string? includeProperties = null);
        // Task AddAsync(Currency entity);
        // Task UpdateAsync(Currency entity);
        // Task DeleteAsync(byte id);
    }
}
