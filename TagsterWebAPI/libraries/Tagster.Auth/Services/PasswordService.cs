using Microsoft.AspNetCore.Identity;

namespace Tagster.Auth.Services
{
    internal sealed class PasswordService : IPasswordService
    {
        private readonly IPasswordHasher<IPasswordService> _passwordHasher;

        public PasswordService(IPasswordHasher<IPasswordService> passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }

        public bool IsValid(string hash, string password)
        {
            return _passwordHasher.VerifyHashedPassword(this, hash, password) != PasswordVerificationResult.Failed;
        }

        public string Hash(string password)
        {
            return _passwordHasher.HashPassword(this, password);
        }
    }
}
