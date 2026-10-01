namespace PasswordKit.Generators.Tests;

public class PasswordGeneratorTest
{
    [Fact]
    public void Generate_ShouldReturnPasswordWithValidLength()
    {
        var generator = new PasswordGenerator();

        var password = generator.Generate(20);

        Assert.Equal(20, password.Length);
    }

    [Fact]
    public void Generate_ShouldThrow_WhenSizeLessThan8()
    {
        var generator = new PasswordGenerator();

        Assert.Throws<ArgumentOutOfRangeException>(
            () => generator.Generate(7)
        );
    }
}
