namespace FiloGH.Core.Enums
{
    // FiloGH.Core/Enums/StockTransactionType.cs

    public enum StockTransactionType : byte
    {
        /// <summary>
        /// Satın alma sonucu stoğa giriş. (WeightInGrams: +)
        /// </summary>
        PurchaseEntry = 1,

        /// <summary>
        /// Satış sonucu stoktan çıkış. (WeightInGrams: -)
        /// </summary>
        SalesExit = 2,

        /// <summary>
        /// Yeni bir ürün imalatı sonucu stoğa nihai ürün girişi. (WeightInGrams: +)
        /// </summary>
        ProductionEntry = 3,

        /// <summary>
        /// İmalatta hammadde tüketimi veya ergitme sonucu stoktan düşüş. (WeightInGrams: -)
        /// </summary>
        ProductionConsumption = 4,

        /// <summary>
        /// Fire, kayıp veya bozulma nedeniyle stoktan düşüş. (WeightInGrams: -)
        /// </summary>
        ScrapLoss = 5,

        /// <summary>
        /// Sayım veya düzeltme işlemleri. (WeightInGrams: +/-)
        /// </summary>
        InventoryAdjustment = 6
    }
}
