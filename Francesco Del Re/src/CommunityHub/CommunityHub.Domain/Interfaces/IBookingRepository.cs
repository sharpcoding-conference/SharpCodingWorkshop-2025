using CommunityHub.Domain.Entities;

namespace CommunityHub.Domain.Interfaces
{
    public interface IBookingRepository : IRepository<Booking>
    {
        Task<IEnumerable<Booking>> GetBookingsByUserAsync(Guid userId);
        Task<bool> UserAlreadyBookedAsync(Guid userId, Guid webinarId);
    }
}
