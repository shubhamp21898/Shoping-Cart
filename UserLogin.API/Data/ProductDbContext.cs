using Microsoft.EntityFrameworkCore;
using UserLogin.API.Model;

namespace UserLogin.API.Data
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options):base(options)
        {
            
        }
        public DbSet<Registration> Registration { get; set; }
      

   
    }
}
