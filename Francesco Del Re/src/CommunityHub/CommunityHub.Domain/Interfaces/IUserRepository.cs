using CommunityHub.Domain.Entities;

namespace CommunityHub.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByIdAsync(Guid id);
        Task<IEnumerable<User>> GetAllAsync();
        Task AddAsync(User entity);
        Task UpdateAsync(User entity);
        Task DeleteAsync(Guid id);
    }
}
