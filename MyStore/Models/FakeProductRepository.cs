using System.Collections.Generic;
using System.Linq;

namespace MyStore.Models
{
    public class FakeProductRepository : IProductRepository//Фиктивный объект который замещает хранилище данных пока мы им не займемся.
    {
        public IQueryable<Product> Products => new List<Product>
        {
            new Product { Artist = "The Doors", Name = "The Doors", Price = 849.99M },
            new Product { Artist = "The Doors", Name = "L.A. Woman", Price = 899.99M },
            new Product { Artist = "Queen", Name = "Bohemian Rhapsody", Price = 1199.99M },
            new Product { Artist = "Nirvana", Name = "Live at the Paramount", Price = 749.99M },
            new Product { Artist = "Pink Floyd", Name = "The Dark Side of the Moon", Price = 999.99M }
        }.AsQueryable<Product>(); //преобразует фиксированную коллекцию объектов в IQuaryable<Product>, чтобы реализовать IProductRepository и создать хранилище, не имеет дело с запросами.

    }
}
