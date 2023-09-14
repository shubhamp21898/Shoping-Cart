using ProductCart.Models;

namespace ProductCart.Services
{
    public interface IUser_Service
    {
        Task<List<ProductModel>> GetAllProduct();
        Task<string> UserLogin(Login login);
        
    }
}
