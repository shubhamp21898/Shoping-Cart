using Microsoft.EntityFrameworkCore;
using Product.API.Data;
using Product.API.DTO;
using Product.API.Mapper;

namespace Product.API.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly ProductDbContext _context;
        public ProductService(ProductDbContext context)
        {
            _context = context;
        }
        async Task<ProductDTO> IProductService.CreateProductAsync(ProductDTO productDto)
        {
            var product = ModelConverter.DtoToModel(productDto);
            if(product.Id>0)
            {
                _context.Products.Update(product);
            }
            else
            {
                _context.Products.Add(product);

            }
            await _context.SaveChangesAsync();
            var dtoproduct = ModelConverter.ModelToDto(product);
            return dtoproduct;
        }

        async Task<bool> IProductService.DeleteProductAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
          if(product==null)
            {
                return false;
            }
          _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        async Task<IEnumerable<ProductDTO>> IProductService.GetAllProduct()
        {
            var products =await _context.Products.Select(product=>ModelConverter.ModelToDto(product)).ToListAsync();
            return products;
        }

        async Task<ProductDTO> IProductService.GetProductById(int id)
        {
            var products = await _context.Products.Select(product =>
            ModelConverter.ModelToDto(product)).FirstOrDefaultAsync();
            return products;
        }
    }
}
