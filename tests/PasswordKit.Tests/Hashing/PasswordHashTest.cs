namespace PasswordKit.Hashing.Tests;

public class PasswordHashTest
{
    [Fact]
    public void Hash_ShouldReturnHash()
    {
        var hasher = new PasswordHash();

        var hash = hasher.Hash("my-password-123");

        Assert.NotEmpty(hash);
        Assert.NotEqual("my-password-123", hash);
    }

    [Fact]
    public void Verify_ShouldReturnTrue_WhenPasswordIsCorrect()
    {
        var hasher = new PasswordHash();

        var password = "my-password-123";
        var hash = hasher.Hash(password);

        var result = hasher.Verify(password, hash);

        Assert.True(result);
    }

    [Fact]
    public void Verify_ShouldReturnFalse_WhenPasswordIsIncorrect()
    {
        var hasher = new PasswordHash();

        var hash = hasher.Hash("my-password-123");

        var result = hasher.Verify("my-wrong-password-321", hash);

        Assert.False(result);
    }

    [Fact]
    public void Hash_ShouldThrowExceptionOnEmptyString()
    {
        var hasher = new PasswordHash();

        Assert.Throws<ArgumentException>(() => hasher.Hash(""));
    }
}
