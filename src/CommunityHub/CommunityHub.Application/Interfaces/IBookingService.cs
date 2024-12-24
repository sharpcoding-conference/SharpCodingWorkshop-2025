using CommunityHub.Application.DTOs;

namespace CommunityHub.Application.Interfaces
{
    public interface IBookingService
    {
        Task<Guid> CreateBookingAsync(BookingDto bookingDto);
        Task<IEnumerable<BookingDto>> GetBookingsByUserIdAsync(Guid userId);
        Task CancelBookingAsync(Guid bookingId);
    }
}
