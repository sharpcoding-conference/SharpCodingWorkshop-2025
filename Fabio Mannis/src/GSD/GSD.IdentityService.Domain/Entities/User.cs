using GSD.IdentityService.Domain.Enum;

namespace GSD.IdentityService.Domain.Entities;
public class User
{
    public Guid Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public Role Role { get; private set; }
    public bool IsEmailVerified { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private User() { }

    public User(string firstName, string lastName, string email, string passwordHash, Role role)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PasswordHash = passwordHash;
        Role = role;
        IsEmailVerified = false;
        CreatedAt = DateTime.UtcNow;
    }

    public void VerifyEmail() => IsEmailVerified = true;
}