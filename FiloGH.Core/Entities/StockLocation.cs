using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Stokların fiziksel olarak tutulduğu yerler: kasa, depo, iş merkezi, vitrin vb.
    /// </summary>
    public class StockLocation
    {
        public int Id { get; set; }

        /// <summary>
        /// Lokasyonun kısa kodu (Örn: ANKASA, DKM_AMBAR, VTR_KAT2).
        /// </summary>
        [MaxLength(10)]
        public required string Code { get; set; }

        /// <summary>
        /// Lokasyonun okunabilir adı (Örn: Ana Metal Kasası, Dökümhane Deposu, 2. Kat Vitrin).
        /// </summary>
        [MaxLength(100)]
        public required string Name { get; set; }

        /// <summary>
        /// Bu lokasyonun bağlı olduğu şube.
        /// </summary>
        public byte BranchId { get; set; }
        public required Branch Branch { get; set; } = null!;

        /// <summary>
        /// Bu lokasyonun türü (Örn: VAULT-Kasa, SHELF-Raf, WORKCENTER-İş Merkezi, DISPLAY-Vitrin).
        /// </summary>
        [MaxLength(20)]
        public required string LocationType { get; set; }

        /// <summary>
        /// Bu lokasyonda sadece belirli bir metal türünün (Altın, Gümüş) veya saflık türünün (14K, 22K) tutulup tutulmayacağı.
        /// </summary>
        public bool IsRestricted { get; set; } = false;

        /// <summary>
        /// Bu lokasyonda tutulan stoğun fiziksel sayım (envanter) işlemine dahil edilip edilmeyeceği.
        /// </summary>
        public bool IsPhysicalInventoryEnabled { get; set; } = true;

        // --- İLİŞKİLER (Gerektiğinde bu lokasyonda çalışan/sorumlu kişi) ---

        /// <summary>
        /// Bu lokasyondan sorumlu olan personel.
        /// </summary>
        public byte? ResponsibleUserId { get; set; }
        public User? ResponsibleUser { get; set; }

        // Not: StockTransaction veya StockItem entiteleri, bu lokasyonda ne olduğunu belirtecektir.
    }
}