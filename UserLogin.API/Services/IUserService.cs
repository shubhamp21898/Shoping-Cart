
using UserLogin.API.Model;

namespace UserLogin.API.Services
{
    public interface IUserService
    {
        Task<Registration> GetUserById(int id);
        Task<Registration> RegisterUser(Registration userRegistration);
        Task<string> Login(string userName, string password);
    }
}
