// FiloGH.Core/Entities/OrderLine.cs (Nihai ve Güncel Yapı)

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    public class OrderLine
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public required Order Order { get; set; } = null!;

        // --- SATIRIN TÜRÜ VE DURUMU ---

        /// <summary>
        /// Satırın türü (Ürün, Hizmet, İndirim, Kargo vb.).
        /// </summary>
        public byte LineTypeId { get; set; }
        public required OrderLineType LineType { get; set; } = null!; // ✅ Yeni Eklendi

        public byte RootTypeId { get; set; }
        public required RootType RootType { get; set; } = null!;

        public byte LineStatusId { get; set; }
        public required OrderStatusDefinition LineStatus { get; set; } = null!; // Order'ın Status Entity'sini kullanır

        // --- TEMEL ÜRÜN VE LOKASYON ---
        public int? ProductVariantId { get; set; } // Sadece LineType=Ürün ise dolu olur
        public ProductVariant? ProductVariant { get; set; }

        public byte? LocationId { get; set; }
        public Location? Location { get; set; }

        // --- STOK VE MİKTAR ---

        /// <summary>
        /// Satılan stok miktarı (Gram veya Adet). 
        /// StockTransaction'a gönderilen ana miktar/ağırlık değeridir.
        /// </summary>
        [Column(TypeName = "decimal(19,4)")]
        public decimal StockQuantity { get; set; }

        // --- PARA BİRİMİ VE KUR SABİTLEME ---

        /// <summary>
        /// Ürünün fiyatının belirlendiği ve müşterinin hesabına yansıtılacak para/metal birimi.
        /// </summary>
        public byte CustomerCurrencyId { get; set; }
        public required Currency CustomerCurrency { get; set; } = null!; // Yinelenen tanım temizlendi

        /// <summary>
        /// Satılan ürünün stoktaki metal birimi (Genellikle Altın, Gümüş veya Adet).
        /// </summary>
        public byte StockCurrencyId { get; set; }
        public required Currency StockCurrency { get; set; } = null!;

        /// <summary>
        /// Kalem para biriminin (CustomerCurrency), satış anındaki sistemin ana para birimi (EUR) karşılığı kuru.
        /// </summary>
        [Column(TypeName = "decimal(19,8)")]
        public decimal FixedExchangeRate { get; set; }

        // --- FİYATLANDIRMA VE TUTARLAR ---
        [Column(TypeName = "decimal(19,4)")]
        public decimal UnitPrice { get; set; } // Birim fiyat (CustomerCurrency cinsinden)

        [Column(TypeName = "decimal(19,4)")]
        public decimal Amount { get; set; } // İndirimler hariç toplam tutar

        [Column(TypeName = "decimal(19,4)")]
        public decimal? CustomerAmount { get; set; } // Müşteriye yansıtılan nihai tutar

        [MaxLength(255)]
        public string? LineNote { get; set; }

        // --- İLİŞKİLER ---
        public ICollection<OrderLineCost> OrderLineCosts { get; set; } = new List<OrderLineCost>();
        public InventoryCost? InventoryCost { get; set; }
    }
}