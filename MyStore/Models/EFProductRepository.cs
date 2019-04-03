using System.Collections.Generic;
using System.Linq;

namespace MyStore.Models
{
    public class EFProductRepository : IProductRepository
    {
        private ApplicationDbContext context;
        public EFProductRepository(ApplicationDbContext ctx) //Отображаем свойство Products из интерфейса на Products из класса ApplicationDbContext 
        {                                                    //свойство этого класса возращает DbSet<Products> который реализует интерфейс IQueryable<T>
            context = ctx;
        }
        public IQueryable<Product> Products => context.Products;
    }
}
