using FiloGH.Core.Interfaces;

namespace FiloGH.Infrastructure.Services.Client
{
    public class ClientTimeZoneService : IClientTimeZoneService
    {
        private readonly TaskCompletionSource<bool> _tcs = new TaskCompletionSource<bool>();

        public TimeZoneInfo TimeZone { get; private set; } = TimeZoneInfo.Local; // Default değer atayın

        public void SetTimeZone(string timeZoneId)
        {
            try
            {
                TimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            }
            catch (TimeZoneNotFoundException)
            {
                // Eğer saat dilimi bulunamazsa, varsayılanı kullanmaya devam edin.
            }
            // Servisin hazır olduğunu işaretle
            _tcs.TrySetResult(true);
        }

        public Task WaitForTimeZoneAsync()
        {
            return _tcs.Task;
        }
    }
}
