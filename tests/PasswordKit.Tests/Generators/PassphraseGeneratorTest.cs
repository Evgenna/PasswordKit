namespace PasswordKit.Generators.Tests;

public class PassphraseGeneratorTest
{
    [Fact]
    public void Generate_ShouldReturnRequestedNumberOfWords()
    {
        var generator = new PassphraseGenerator();

        var password = generator.Generate(3);

        var parts = password.Split('-');

        Assert.Equal(4, parts.Length);
    }

    [Fact]
    public void Generate_ShouldEndWith3DigitNumber()
    {
        var generator = new PassphraseGenerator();

        var password = generator.Generate(3);

        var parts = password.Split('-');
        var number = parts[^1];

        Assert.Matches(@"^\d{3}$", number);
    }
}
