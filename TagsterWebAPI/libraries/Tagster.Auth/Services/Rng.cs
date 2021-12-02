using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Tagster.Auth.Services;

internal sealed class Rng : IRng
{
    private readonly Random _random;
    private readonly string[] SpecialChars = new[] { "/", "\\", "=", "+", "?", ":", "&" };
    private readonly string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

    public Rng()
        => _random = new();

    public string Generate(int length = 50, bool removeSpecialChars = true)
    {
        using var rng = new RSACryptoServiceProvider();
        var bytes = Encoding.ASCII.GetBytes(RandomString(length));
        bytes = rng.Encrypt(bytes, false);
        var result = Convert.ToBase64String(bytes);

        return removeSpecialChars
            ? SpecialChars.Aggregate(result, (current, chars) => current.Replace(chars, string.Empty))
            : result;
    }

    private string RandomString(int length)
    {
        return new string(Enumerable.Repeat(Chars, length)
          .Select(s => s[_random.Next(s.Length)]).ToArray());
    }
}
