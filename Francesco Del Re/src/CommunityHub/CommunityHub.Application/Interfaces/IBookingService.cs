using CommunityHub.Application.DTOs;

namespace CommunityHub.Application.Interfaces
{
    public interface IBookingService
    {
        Task<Guid> CreateBookingAsync(BookingDto bookingDto);
        Task<IEnumerable<BookingDto>> GetAllBookingsAsync();
        Task<BookingDto> GetBookingByIdAsync(Guid bookingId);
        Task<bool> UpdateBookingAsync(Guid bookingId, BookingDto bookingDto);
        Task<bool> DeleteBookingAsync(Guid bookingId);
        Task CancelBookingAsync(Guid bookingId);
    }
}
