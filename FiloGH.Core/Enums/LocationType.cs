namespace FiloGH.Core.Enums
{
    /// <summary>
    /// Envanterin fiziksel veya mantıksal olarak bulunduğu yerin tipini tanımlar.
    /// </summary>
    public enum LocationType : byte
    {
        /// <summary>
        /// Tanımsız/varsayılan durum.
        /// </summary>
        UNDEFINED = 0,

        /// <summary>
        /// Ana depo/stok alanı. Bitmiş ürünlerin büyük bir kısmı burada tutulur.
        /// </summary>
        MAIN_WAREHOUSE = 1,

        /// <summary>
        /// Perakende satış alanındaki vitrin, stoktan direk düşüş yapılabilir.
        /// </summary>
        SHOWCASE = 2,

        /// <summary>
        /// Nakit veya metal/taş hammadde tutulan güvenli kasa.
        /// </summary>
        VAULT_SAFE = 3,

        /// <summary>
        /// Üretim/imalat atölyesi. Hammaddenin işlenmek üzere aktarıldığı yer.
        /// </summary>
        PRODUCTION_FLOOR = 4,

        /// <summary>
        /// İmalat sonrası oluşan fire, hurda veya ikincil kalitede materyallerin toplandığı mantıksal lokasyon.
        /// </summary>
        SCRAP_AREA = 5,

        /// <summary>
        /// Onarım, tadilat veya özel siparişlerin geçici olarak tutulduğu yer.
        /// </summary>
        SERVICE_REPAIR = 6,

        /// <summary>
        /// Başka bir şubeye gönderilmek üzere ayrılmış, transit durumdaki stok.
        /// </summary>
        TRANSIT = 7
    }
}