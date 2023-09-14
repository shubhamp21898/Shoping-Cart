using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserLogin.API.Data;
using UserLogin.API.Model;

namespace UserLogin.API.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly ProductDbContext _dbContext;

        public UserService(IConfiguration configuration, ProductDbContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }

        public async Task<Registration> GetUserById(int id)
        {
            return await _dbContext.Registration.FindAsync(id);
        }

        public async Task<Registration> RegisterUser(Registration userRegistration)
        {
            // Perform necessary validation and business logic for user registration
            // For example, check if the username or email already exists in the database.
            // Then create and save the new user entity to the database.
            var newUser = new Registration
            {
                UserName = userRegistration.UserName,
                Password = userRegistration.Password, // You should not store passwords in plain text. Implement proper password hashing.
                Email = userRegistration.Email,
                IsActive = userRegistration.IsActive,
                // Set other properties as needed
            };

            _dbContext.Registration.Add(newUser);
            await _dbContext.SaveChangesAsync();

            return newUser;
        }

        public async Task<string> Login(string userName, string password)
        {
            var user = await _dbContext.Registration.FirstOrDefaultAsync(u => u.UserName == userName && u.Password == password);

            if (user == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    // You can add additional claims as needed for authorization purposes.
                }),
                Expires = DateTime.UtcNow.AddHours(1), // Token expiration time.
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
