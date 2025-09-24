using Lamazon.Domain.Entities;
using Microsoft.AspNetCore.Identity;


namespace Lamazon.Services.Helpers
{
    public static class PasswordHasherHelper
    {
        private static PasswordHasher<User> _passwordHasher = new();

        public static void HashPassword(User user, string password)
        {
            user.PasswordHash = _passwordHasher.HashPassword(user, password);
        }

        public static PasswordVerificationResult VerifyHashedPassword(User user, string password)
        {
            return _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
        }
    }
}
