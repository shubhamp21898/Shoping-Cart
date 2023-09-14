using Product.API.DTO;

namespace Product.API.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllProduct();

        Task<ProductDTO> GetProductById(int id);
        Task<ProductDTO> CreateProductAsync(ProductDTO productDto);

        Task<bool> DeleteProductAsync(int id);
    }
}
