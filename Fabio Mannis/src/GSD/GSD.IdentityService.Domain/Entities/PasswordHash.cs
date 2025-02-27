public class PasswordHash
{
    public string Hash { get; private set; }

    private PasswordHash() { }

    public PasswordHash(string password)
    {
        if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
            throw new ArgumentException("La password deve avere almeno 8 caratteri");

        Hash = BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool Verify(string password) => BCrypt.Net.BCrypt.Verify(password, Hash);
}
