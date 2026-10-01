using System.Security.Cryptography;

namespace PasswordKit.Generators;

public class PasswordGenerator : IPassGenerator
{
    private const string Characters =
        "ABCDEFGHKLMNOPQRSTUVWXYZ" +
        "abcdefghkmnopqrstuvwxyz" +
        "234567890@#$%^&*()";

    public string Generate(int size)
    {
        if(size < 8)
        {
            throw new ArgumentOutOfRangeException(
                nameof(size),
                "Password length must be at least 8 symbols."
            );
        }

        var password = new char[size];

        for (var i = 0; i < size; i++)
        {
            password[i] = Characters[RandomNumberGenerator.GetInt32(Characters.Length)];
        }

        return new string(password);
    }
}
