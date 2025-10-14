namespace FiloGH.Core.Interfaces
{
    /// <summary>
    /// Müşterinin (Client) tarayıcı saat dilimi ayarlarını alır ve ayarlar.
    /// Bu, tüm tarih/saat gösterimlerinin ve hesaplamalarının doğru bir şekilde
    /// UTC'den yerel zamana dönüştürülmesini sağlar.
    /// </summary>
    public interface IClientTimeZoneService
    {
        /// <summary>
        /// Müşterinin belirlenen TimeZone bilgisini tutar.
        /// </summary>
        TimeZoneInfo TimeZone { get; }

        /// <summary>
        /// Tarayıcıdan alınan TimeZoneId'yi (Örn: "Europe/Istanbul") kullanarak TimeZone bilgisini ayarlar.
        /// </summary>
        /// <param name="timeZoneId">IANA/Windows TimeZone ID'si.</param>
        void SetTimeZone(string timeZoneId);

        /// <summary>
        /// Saat dilimi bilgisinin tarayıcıdan başarıyla yüklenmesini bekler.
        /// Uygulamanın başlatılması sırasında kritik bir adımdır.
        /// </summary>
        Task WaitForTimeZoneAsync();
    }
}
