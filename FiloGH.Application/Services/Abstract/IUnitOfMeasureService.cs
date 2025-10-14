using FiloGH.Core.Entities;
using FiloGH.Core.Interfaces;

namespace FiloGH.Application.Services.Abstract
{
    /// <summary>
    /// Ölçü Birimi (UnitOfMeasure) entity'si için servis sözleşmesini tanımlar.
    /// byte ID'li entity'ler için temel CRUD ve sorgulama operasyonlarını IBaseService'ten devralır.
    /// </summary>
    public interface IUnitOfMeasureService : IBaseService<UnitOfMeasure, byte>
    {
        // IBaseService<UnitOfMeasure, byte>'dan gelen metotlar:
        // Task AddAsync(UnitOfMeasure entity);
        // Task UpdateAsync(UnitOfMeasure entity);
        // Task DeleteAsync(byte id);
        // Task<UnitOfMeasure?> GetByIdAsync(byte id);
        // Task<IEnumerable<UnitOfMeasure>> GetAllAsync(...)

        // Bu arayüz, UnitOfMeasure için özel bir metot gerektirmez.
    }
}
