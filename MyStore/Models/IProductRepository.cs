using System.Linq;

namespace MyStore.Models
{
    interface IProductRepository
    {
        IQueryable<Product> Products { get; } //Используем этот интерфейс чтобы вызывающему коду получать последовательность объектов Product. Производный от IEnumerable<T>
                                              //Иметирует базу данных. Такие Product можно запрашивать. С ним работает LINQ, ToList(), ToArray.
    }
}
