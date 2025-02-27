using GSD.IdentityService.Domain.Entities;
using GSD.IdentityService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GSD.IdentityService.Infrastructure.Repositories;
public class UserRepository
{
    private readonly IdentityDbContext _context;
    public UserRepository(IdentityDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByEmailAsync(string email) =>
        await _context.Users.FirstOrDefaultAsync(u => u.Email.Value == email);

    public async Task AddAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }
}
