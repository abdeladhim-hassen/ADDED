using System.Threading.Tasks;
using ADDED.API.Dtos;
using ADDED.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ADDED.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)

        {
            _context = context;
        }
        public async Task<Chef> Login(string MailTel, string password)
        {   var isTel = int.TryParse(MailTel, out int Tel);
           var chef = isTel? await _context.ChefBureau.FirstOrDefaultAsync(x => x.TelChef == Tel) : await _context.ChefBureau.FirstOrDefaultAsync(x => x.MailChef == MailTel);
            
            if (chef == null)
                return null;
            if (!VerifyPasswordHash(password, chef.PasswordHash, chef.PasswordSalt))
                return null;
            return chef;
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
            
            var computedHash= hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            for (int i = 0 ; i < computedHash.Length ; i ++)
            {if (computedHash[i] != passwordHash[i]) return false;

            }
            }
            return true;
        }
        public async Task<Chef> Register(Chef chef, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            chef.PasswordHash = passwordHash;
            chef.PasswordSalt = passwordSalt;
            await _context.ChefBureau.AddAsync(chef);
            await _context.SaveChangesAsync();
            return chef;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> ChefExists(MailTel  mailTel)
        {
            if ((await _context.ChefBureau.AnyAsync(x => x.MailChef == mailTel.MailChef)) 
            ||(await _context.ChefBureau.AnyAsync(x => x.TelChef == mailTel.TelChef)))
            { return true; }
            return false;
        }
    }
}