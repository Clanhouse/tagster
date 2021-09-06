using Microsoft.AspNetCore.Identity;

namespace Tagster.Auth.Services
{
    internal sealed class PasswordService : IPasswordService
    {
        private readonly IPasswordHasher<IPasswordService> _passwordHasher;

<<<<<<< HEAD
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
=======
        public PasswordService(IPasswordHasher<IPasswordService> passwordHasher) 
            => _passwordHasher = passwordHasher;

        public bool IsValid(string hash, string password) 
            => _passwordHasher.VerifyHashedPassword(this, hash, password) != PasswordVerificationResult.Failed;

        public string Hash(string password) 
            => _passwordHasher.HashPassword(this, password);
>>>>>>> e56f5e008b44f871bf3346eb31d0999174b491f7
    }
}
