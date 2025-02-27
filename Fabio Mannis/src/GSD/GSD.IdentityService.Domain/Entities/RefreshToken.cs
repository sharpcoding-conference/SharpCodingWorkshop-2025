public class RefreshToken
{
    public Guid Id { get; private set; }
    public string Token { get; private set; }
    public DateTime ExpiryDate { get; private set; }
    public bool IsRevoked { get; private set; }

    public bool IsExpired => DateTime.UtcNow >= ExpiryDate;

    private RefreshToken() { }

    public RefreshToken(string token, DateTime expiryDate)
    {
        Id = Guid.NewGuid();
        Token = token;
        ExpiryDate = expiryDate;
        IsRevoked = false;
    }

    public void Revoke() => IsRevoked = true;
}
