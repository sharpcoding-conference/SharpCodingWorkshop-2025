using CommunityHub.Domain.Entities;

namespace CommunityHub.Domain.Interfaces
{
    public interface IWebinarRepository : IRepository<Webinar>
    {
        Task<Webinar> GetByIdAsync(Guid id);
        Task<IEnumerable<Webinar>> GetAllAsync();
        Task AddAsync(Webinar entity);
        Task UpdateAsync(Webinar entity);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<Webinar>> GetUpcomingWebinarssAsync();
    }
}
