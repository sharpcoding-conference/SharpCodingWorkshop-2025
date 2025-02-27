using GSD.IdentityService.Domain.Enum;

public class User
{
    public Guid Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public Email Email { get; private set; }
    public PasswordHash Password { get; private set; }
    public Role Role { get; private set; }
    public bool IsEmailVerified { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private List<RefreshToken> _refreshTokens = new();
    public IReadOnlyCollection<RefreshToken> RefreshTokens => _refreshTokens.AsReadOnly();

    // Costruttore privato per Entity Framework Core
    private User() { }

    public User(string firstName, string lastName, Email email, PasswordHash password, Role role)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        Role = role;
        IsEmailVerified = false;
        CreatedAt = DateTime.UtcNow;
    }

    public void VerifyEmail() => IsEmailVerified = true;

    public void AddRefreshToken(RefreshToken token) => _refreshTokens.Add(token);

    public void RemoveExpiredTokens() => _refreshTokens.RemoveAll(t => t.IsExpired);
}
