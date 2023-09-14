using ProductCart.Models;

namespace ProductCart.Services
{
    public interface IProduct_Service
    {
        Task<List<ProductModel>> GetAllProduct();
        Task<bool> AddNewProduct(ProductModel product);
        Task<ProductModel> GetProductById(int id);
    }
}
