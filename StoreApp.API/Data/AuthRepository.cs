using System;
using System.Threading.Tasks;
using StoreApp.API.Model;
using Microsoft.EntityFrameworkCore;

namespace StoreApp.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext db;
        public AuthRepository(DataContext context)
        {
            db = context;

        }

        public Task<User> Login(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            user.PasswordHash=passwordHash;
            user.PasswordSalt=passwordSalt;

            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {   
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt=hmac.Key;
                passwordHash=hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
            
        }

        public Task<bool> UserExists(string username)
        {
            throw new System.NotImplementedException();
        }
    }
}