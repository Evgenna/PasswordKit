using System.Security.Cryptography;

namespace PasswordKit.Generators;

public class PassphraseGenerator : IPassGenerator
{
    private static readonly string[] Keywords = [
        "apple", "river", "forest", "cloud", "stone",
        "tiger", "wolf", "eagle", "fox", "bear",
        "ocean", "mountain", "sun", "moon", "star",
        "rain", "wind", "snow", "fire", "storm",
        "blue", "green", "red", "white", "black",
        "gold", "silver", "happy", "silent", "bright",
        "swift", "wild", "calm", "windy", "strong",
        "dance", "music", "dream", "light", "shadow",
        "magic", "space", "night", "summer", "winter",
        "coffee", "bread", "lemon", "peach", "cherry",
        "panda", "rabbit", "cat", "horse", "whale",
        "island", "garden", "castle", "bridge", "road"
    ];

    public string Generate(int size)
    {
        var words = new string[size];

        for (int i = 0; i < size; i++)
        {
            words[i] = Keywords[RandomNumberGenerator.GetInt32(Keywords.Length)];
        }

        var number = RandomNumberGenerator.GetInt32(100, 1000);

        return $"{string.Join("-", words)}-{number}";
    }
}