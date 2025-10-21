using FiloGH.Core.Entities;
using FiloGH.Core.Interfaces;

namespace FiloGH.Application.Interfaces // Doğru Namespace
{
    // UomType'ın ID'si byte olduğu için IBaseService<UomType, byte>'tan kalıtım alır.
    public interface IUomTypeService : IBaseService<UomType, byte>
    {
        // UomType'a özel, IBaseService'de olmayan metotlar buraya eklenecektir.
        // Örneğin: Task<List<UomType>> GetActiveUomTypes();

        // IBaseService'den miras alınan GetAllAsync metodu tekrar tanımlanmadığı için 
        // CS0535 hatası çözülmüştür.
    }
}
