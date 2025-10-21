using FiloGH.Application.Interfaces;
using FiloGH.Core.Entities;
using FiloGH.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace FiloGH.Application.Services
{
    /// <summary>
    /// Fiyat Listesi (PriceList) varlığını yöneten servis.
    /// Hem IPriceListService hem de IBaseService'in GetAllAsync imzalarını destekler.
    /// </summary>
    public class PriceListService : IPriceListService // IPriceListService, IBaseService'den kalıtım alır.
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<PriceList, int> _priceListRepository;

        public PriceListService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _priceListRepository = _unitOfWork.GetRepository<PriceList, int>();
        }

        // -------------------------------------------------------------------
        // IPriceListService UYGULAMASI (Task<List<PriceList>> döner)
        // -------------------------------------------------------------------

        /// <summary>
        /// IPriceListService'in beklediği imzaya uygun olarak tüm fiyat listesi kayıtlarını çeker.
        /// </summary>
        public async Task<List<PriceList>> GetAllAsync(
            Expression<Func<PriceList, bool>>? filter = null,
            Func<IQueryable<PriceList>, IOrderedQueryable<PriceList>>? orderBy = null,
            Func<IQueryable<PriceList>, IIncludableQueryable<PriceList, object>>? include = null,
            bool disableTracking = true)
        {
            // Varsayılan olarak Currency (Para Birimi) ilişkisini yüklüyoruz.
            Func<IQueryable<PriceList>, IIncludableQueryable<PriceList, object>> defaultInclude = source =>
                 source.Include(pl => pl.Currency!);

            var entities = await _priceListRepository.GetAllAsync(
                filter: filter,
                orderBy: orderBy,
                include: include ?? defaultInclude,
                disableTracking: disableTracking
            );

            // IPriceListService'in istediği List<PriceList> tipine çevirilir.
            if (orderBy == null)
            {
                return entities.OrderBy(pl => pl.Name).ToList();
            }

            return entities.ToList();
        }

        // -------------------------------------------------------------------
        // IBaseService UYGULAMASI (Task<IEnumerable<PriceList>> döner)
        // Hatanın çözümü için zorunlu olan Explicit (Açık) Arayüz Uygulaması
        // -------------------------------------------------------------------

        /// <summary>
        /// IBaseService'in beklediği Task<IEnumerable<PriceList>> imzasını karşılamak için 
        /// açık (explicit) olarak uygulanmıştır.
        /// </summary>
        async Task<IEnumerable<PriceList>> IBaseService<PriceList, int>.GetAllAsync(
            Expression<Func<PriceList, bool>>? filter,
            Func<IQueryable<PriceList>, IOrderedQueryable<PriceList>>? orderBy,
            Func<IQueryable<PriceList>, IIncludableQueryable<PriceList, object>>? include,
            bool disableTracking)
        {
            // IEnumerable<PriceList>, List<PriceList>'in temel tipi (base type) olduğu için, 
            // List dönen metodu çağırabiliriz.
            return await GetAllAsync(filter, orderBy, include, disableTracking);
        }

        // -------------------------------------------------------------------
        // DİĞER METOTLAR
        // -------------------------------------------------------------------

        public async Task<PriceList?> GetByIdAsync(int id, string? includeProperties = null)
        {
            return await _priceListRepository.GetByIdAsync(
                id,
                disableTracking: false,
                includeProperties: includeProperties ?? "Currency"
            );
        }

        public async Task AddAsync(PriceList priceList)
        {
            if (priceList.Currency != null && priceList.CurrencyId != 0)
            {
                priceList.Currency = null!;
            }

            await _priceListRepository.AddAsync(priceList);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(PriceList priceList)
        {
            var existingPriceList = await _priceListRepository.GetByIdAsync(priceList.Id, disableTracking: false);

            if (existingPriceList == null)
            {
                throw new KeyNotFoundException($"PriceList with ID {priceList.Id} not found.");
            }

            // Gerekli güncellemeler
            existingPriceList.Name = priceList.Name;
            existingPriceList.Code = priceList.Code;
            existingPriceList.IsActive = priceList.IsActive;
            existingPriceList.ValidFrom = priceList.ValidFrom;
            existingPriceList.ValidTo = priceList.ValidTo;
            existingPriceList.IsBasePriceList = priceList.IsBasePriceList;
            existingPriceList.CurrencyId = priceList.CurrencyId;

            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _priceListRepository.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }
    }
}
