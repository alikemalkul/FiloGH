namespace FiloGH.Core.Enums
{
    /// <summary>
    /// Bir iznin ait olduğu ana ERP modülünü tanımlar.
    /// </summary>
    public enum UserModuleDefinition : byte
    {
        Sales = 1,          // Siparişler, Faturalar
        Inventory = 2,      // Stok, Stok Hareketleri
        Production = 3,     // Üretim Emirleri, Reçeteler
        Accounting = 4,     // Muhasebe, Kur Takibi
        Administration = 5, // Kullanıcılar, Ayarlar, Şubeler
        Reports = 6         // Tüm Raporlar
    }
}
