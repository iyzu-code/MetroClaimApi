namespace MetroClaim.Api.Utilities;

public interface IHashHandler
{
    string GenerateHash(string password);
    bool ValidateHash(string password, string hash);
}

public class HashHandler : IHashHandler
{
    private static string GenerateSalt()
    {
        return BCrypt.Net.BCrypt.GenerateSalt(13);
    }
    public string GenerateHash(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password, GenerateSalt());
    }

    public bool ValidateHash(string password, string hash)
    {
        return BCrypt.Net.BCrypt.Verify(password, hash);
    }
}