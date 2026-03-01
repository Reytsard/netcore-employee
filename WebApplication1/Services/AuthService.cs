using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class AuthService
    {
        private readonly PasswordHasher<User> _passwordHasher = new PasswordHasher<User>();
        public static List<User> users = new List<User>();
        public User Login(AuthLoginDTO dto)
        {
            Console.WriteLine(dto.Email + " " + dto.Password);
            User user = users.Where(u => u.Email == dto.Email).First();
            Console.WriteLine(user.Email);
            if (user == null)
            {
                throw new ArgumentException("No User Found");
            }
            PasswordVerificationResult result = _passwordHasher.VerifyHashedPassword(user, user.HashedPassword, dto.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                throw new ArgumentException("Invalid Credential");
            }
            return user;
        }
        public User Register(AuthRegisterDTO dto)
        {
            bool HasDuplicateUsername = users.Where(u => u.Username.ToLower() == dto.Username.ToLower() && u.Email.ToLower() == dto.Email.ToLower()).Any();
            if (HasDuplicateUsername)
            {
                throw new ArgumentException("Username Already Exists");
            }
            User user = new User(dto.Username, dto.Email);

            user.HashedPassword = _passwordHasher.HashPassword(user, dto.Password);
            if (dto.Name != null)
            {
                user.Name = dto.Name;
            }
            user.Email = dto.Email;
            user.Username = dto.Username;
            user.HashedPassword = _passwordHasher.HashPassword(user, dto.Password);

            users.Add(user);
            return user;
        }
        public List<User> GetAll()
        {
            return users;
        }

        public string GenerateToken(User user, IConfiguration config)
        {
            Claim[] claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(config["Jwt:Key"])
                );

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwt = new JwtSecurityToken(
                issuer: config["Jwt:Issuer"],
                audience: config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(int.Parse(config["Jwt:ExpiresInMinutes"])),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
