using Microsoft.EntityFrameworkCore;
using SuperJero_Api.Data;
using Entities;
using DTOs;
using BCrypt.Net;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace Services
{
    public class AuthService : IAuthService
    {
        private readonly Database _context;

        private readonly IConfiguration _configuration;

        public AuthService(Database context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

       public async Task<UserResponseDTO?> RegisterAsync(RegisterDTO request)
        {
            var exists = await _context.Users
            .AnyAsync(u => u.username == request.Username);

            if(exists)
            {
                return null;
            }
             
             var user =  new User
             {
                 username = request.Username,
                 PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password)
             };
             _context.Users.Add(user);
             await _context.SaveChangesAsync();

             return new UserResponseDTO
             {
                 Id = user.id,
                 Username = user.username
             };
        }

        public async Task<string?> LoginAsync(LoginDTO request)
        {
            var user = await _context.Users
            .FirstOrDefaultAsync(u => u.username == request.Username);

            if(user == null)
            {
                return null;
            }

            var validPassword = BCrypt.Net.BCrypt.Verify(
                request.Password,
                user.PasswordHash
            );

            if (!validPassword)
            {
                return null;
            }

            return CreateToken(user);
        }

        private string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.id.ToString()),
                new Claim(ClaimTypes.Name, user.username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration["AppSettings:Token"]!));

                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                issuer: _configuration["AppSettings:Issuer"],
                audience: _configuration["AppSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials);

                return new JwtSecurityTokenHandler().WriteToken(token);
            
        }
    }
}