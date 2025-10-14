using FiloGH.Core.Entities;
using FiloGH.Core.Interfaces;
using Microsoft.EntityFrameworkCore.Query; // IIncludableQueryable için
using System.Linq.Expressions;

namespace FiloGH.Application.Services.Abstract // Düzeltildi: Infrastructure yerine Application.Services.Abstract
{
    // PriceList'in ID'si int olduğu için IBaseService<PriceList, int>'ten kalıtım alır.
    public interface IPriceListService : IBaseService<PriceList, int>
    {
        /// <summary>
        /// Gelişmiş filtreleme ve sıralama seçenekleriyle tüm PriceList'leri çeker.
        /// </summary>
        /// <param name="filter">Filtreleme koşulu (Lambda Expression).</param>
        /// <param name="orderBy">Sıralama fonksiyonu.</param>
        /// <param name="include">Yüklenecek ilişkisel property'ler için IIncludableQueryable fonksiyonu.</param>
        /// <param name="asNoTracking">True ise veritabanı izlemesi devre dışı bırakılır (performans için önerilir).</param>
        /// <returns>PriceList entity'lerinden oluşan filtrelenmiş ve sıralanmış bir liste.</returns>
        new Task<List<PriceList>> GetAllAsync( // İmza IIncludableQueryable kullanacak şekilde güncellendi
            Expression<Func<PriceList, bool>>? filter = null,
            Func<IQueryable<PriceList>, IOrderedQueryable<PriceList>>? orderBy = null,
            Func<IQueryable<PriceList>, IIncludableQueryable<PriceList, object>>? include = null,
            bool asNoTracking = true);
    }
}
