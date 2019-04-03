using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace MyStore.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if(!context.Products.Any())
            {
                context.Products.AddRange(
                   new Product { Artist = "The Doors", Name = "The Doors", Price = 849.99M },
                   new Product { Artist = "The Doors", Name = "L.A. Woman", Price = 899.99M },
                   new Product { Artist = "Queen", Name = "Bohemian Rhapsody", Price = 1199.99M },
                   new Product { Artist = "Nirvana", Name = "Live at the Paramount", Price = 749.99M },
                   new Product { Artist = "Pink Floyd", Name = "The Dark Side of the Moon", Price = 999.99M }
                   );
                context.SaveChanges();
            }
        }
    }
}
