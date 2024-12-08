using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TaskManagementProject.Infrastructure.Interfaces;

namespace TaskManagementProject.Infrastructure.Concrete
{
    public class PasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower(); // Hashlenmiş şifreyi döndürür
            }
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            var hashOfInput = HashPassword(password);
            if(hashOfInput.Trim() == hashedPassword.Trim())
            {
                return true;
            }
            return false;
            // Şifreyi doğrulamak için hash karşılaştırması
        }
    }
}
