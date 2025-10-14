namespace FiloGH.Core.Interfaces
{
    /// <summary>
    /// Tüm varlıkların (Entity) uygulaması gereken temel arayüz.
    /// TId: Varlığın Primary Key tipini belirtir.
    /// </summary>
    /// <typeparam name="TId">Primary Key'in veri tipi (Örn: int, Guid, byte)</typeparam>
    public interface IEntity<TId>
        where TId : struct, IComparable, IConvertible, IComparable<TId>, IEquatable<TId>
    {
        TId Id { get; set; }
    }
}
