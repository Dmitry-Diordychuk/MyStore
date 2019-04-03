using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace MyStore.Models
{
    //Класс контекста базы данных - шлюз между приложением и EF Core, который обеспечивает доступ к данным приложения с использованием объектов моделей.
    public class ApplicationDbContext : DbContext//-базовый класс предоставляет доступ к лежащей в основе функциональности EFC. 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {
        }
        public DbSet<Product> Products { get; set; }//Свойсвтво обеспечивает доступ к объектам Product в базе данных.
    }
}
