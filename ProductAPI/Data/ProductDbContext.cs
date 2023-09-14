using Microsoft.EntityFrameworkCore;
using Product.API.Entities;
using Product.API.Model;

namespace Product.API.Data
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options):base(options)
        {
            
        }
        public DbSet<Products> Products { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(

                new Category
                {
                    Id = 1,
                    Title = "Mobile",
                    
                },
                new Category
                {
                    Id = 2,
                    Title = "Laptop",

                });
            modelBuilder.Entity<Products>().HasData(
                
                new Products
                {
                    Id = 1,
                    Title = "Nord 2T",
                    Description = "Oneplus Mobile",
                    Price = 35000.00m,
                    ImageUrl = "https://fdn2.gsmarena.com/vv/pics/oneplus/oneplus-nord-2t-5g-1.jpg",
                    CategoryId = 1
                },
                new Products { Id = 2, Title = "IPhone 13", Description = "Apple Mobile", Price = 50000.00m, ImageUrl = "https://technextgroup.com/wp-content/uploads/2022/03/Tech-Next-Store-iPhone-13-Pro-Starlight1-1.jpg", CategoryId = 1 },
                new Products { Id = 3, Title = "Nord 2T", Description = "Oneplus Mobile", Price = 35000.00m, ImageUrl = "https://fdn2.gsmarena.com/vv/pics/oneplus/oneplus-nord-2t-5g-1.jpg", CategoryId = 1 },
                new Products { Id = 4, Title = "Nord 2", Description = "Oneplus Mobile", Price = 35000.00m, ImageUrl = "https://fdn2.gsmarena.com/vv/pics/oneplus/oneplus-nord-2t-5g-1.jpg", CategoryId = 1 },
                new Products { Id = 5, Title = "11R", Description = "Oneplus Mobile", Price = 45000.00m, ImageUrl = "https://fdn2.gsmarena.com/vv/pics/oneplus/oneplus-nord-2t-5g-1.jpg", CategoryId = 1 },
                new Products { Id = 6, Title = "Nord 2T", Description = "Oneplus Mobile", Price = 35000.00m, ImageUrl = "https://fdn2.gsmarena.com/vv/pics/oneplus/oneplus-nord-2t-5g-1.jpg", CategoryId = 1 },
               new Products
               {
                   Id = 7,
                   Title = "XPS 15",
                   Description = "Dell Laptop",
                   Price = 70000.00m,
                   ImageUrl = "https://e0.pxfuel.com/wallpapers/939/934/desktop-wallpaper-dell-xps-15-xps9550-4444slv-15-6-inch-traditional-laptop-dell-xps-ultra.jpg",
                   CategoryId = 2
               } );
        }
    }
}
