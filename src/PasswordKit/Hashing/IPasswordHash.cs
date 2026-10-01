namespace PasswordKit.Hashing;

public interface IPasswordHash
{
    string Hash(string password);
    bool Verify(string password, string hash); 
}