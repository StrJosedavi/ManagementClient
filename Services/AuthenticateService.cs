using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;
using WassamaraManagement.Data;
using WassamaraManagement.Domain;
using WassamaraManagement.DTOs;
using WassamaraManagement.Services.Interfaces;

namespace WassamaraManagement.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;

        public AuthenticateService(IConfiguration configuration, ApplicationDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public object Authenticate(AuthenticateDto clienteDto)
        {
            UserAdmin user = _context.UsersAdmin.FirstOrDefault(x => x.Username == clienteDto.Username);

            if (user == null) 
                throw new ArgumentException("Credenciais Incorretas!!");

            StringBuilder builder = new StringBuilder();
            using var sha512 = SHA512.Create();

            // Convertendo a senha de string para bytes
            byte[] bytes = Encoding.UTF8.GetBytes(clienteDto.Password);

            // Calculando o hash SHA-512 dos bytes da senha
            byte[] hash = sha512.ComputeHash(bytes);

            // Convertendo o hash de bytes para uma string hexadecimal

            for (int i = 0; i < hash.Length; i++)
            {
                builder.Append(hash[i].ToString("x2")); // "x2" formata cada byte como hexadecimal
            }
            
            if (user.Password == builder.ToString()) {
                var jwtSettings = _configuration.GetSection("JwtSettings");
                var secretKey = jwtSettings["SecretKey"];
                var timeExpirationToken = jwtSettings["TokenExpiration"];

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!));
                var keyEncrypted = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var expires = DateTime.Now.AddHours(Convert.ToDouble(timeExpirationToken));

                var token = new JwtSecurityToken(
                    expires: expires,
                    signingCredentials: keyEncrypted
                );

                var jwt = new JwtSecurityTokenHandler().WriteToken(token);

                return new { code = jwt, expirationDate = expires.ToString() };
            }
            else
            {
                throw new ArgumentException("Credenciais Incorretas!!");
            }

        }
    }
}
