using CommunityHub.Application.DTOs;
using CommunityHub.Application.Exceptions;
using CommunityHub.Application.Interfaces;
using CommunityHub.Domain.Entities;
using CommunityHub.Domain.Interfaces;

namespace CommunityHub.Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly IRepository<Booking> _bookingRepository;
        private readonly IRepository<Webinar> _webinarRepository;

        public BookingService(IRepository<Booking> bookingRepository, IRepository<Webinar> webinarRepository)
        {
            _bookingRepository = bookingRepository;
            _webinarRepository = webinarRepository;
        }

        public async Task<Guid> CreateBookingAsync(BookingDto bookingDto)
        {
            var webinarEntity = await _webinarRepository.GetByIdAsync(bookingDto.WebinarId)
                ?? throw new WebinarNotFoundException($"Webinar with ID {bookingDto.WebinarId} not found.");

            webinarEntity.ReserveSeat();

            var newBooking = new Booking(
                Guid.NewGuid(),
                bookingDto.WebinarId,
                bookingDto.UserId
            );

            await _bookingRepository.AddAsync(newBooking);
            return newBooking.Id;
        }

        public async Task<IEnumerable<BookingDto>> GetAllBookingsAsync()
        {
            var bookings = await _bookingRepository.GetAllAsync();
            return bookings.Select(b => new BookingDto
            {
                Id = b.Id,
                WebinarId = b.WebinarId,
                UserId = b.UserId,
                BookingDate = b.BookingDate
            });
        }

        public async Task<BookingDto> GetBookingByIdAsync(Guid bookingId)
        {
            var booking = await _bookingRepository.GetByIdAsync(bookingId)
                ?? throw new BookingNotFoundException($"Booking with ID {bookingId} not found.");

            return new BookingDto
            {
                Id = booking.Id,
                WebinarId = booking.WebinarId,
                UserId = booking.UserId,
                BookingDate = booking.BookingDate
            };
        }

        public async Task<IEnumerable<BookingDto>> GetBookingsByUserIdAsync(Guid userId)
        {
            var bookings = await _bookingRepository.GetAllAsync();
            return bookings.Where(b => b.UserId == userId)
                           .Select(b => new BookingDto
                           {
                               Id = b.Id,
                               WebinarId = b.WebinarId,
                               UserId = b.UserId,
                               BookingDate = b.BookingDate
                           });
        }

        public async Task<bool> UpdateBookingAsync(Guid bookingId, BookingDto bookingDto)
        {
            var booking = await _bookingRepository.GetByIdAsync(bookingId);
            if (booking == null)
            {
                return false;
            }

            booking.UpdateDetails(bookingDto.WebinarId, bookingDto.UserId, bookingDto.BookingDate);
            await _bookingRepository.UpdateAsync(booking);
            return true;
        }

        public async Task<bool> DeleteBookingAsync(Guid bookingId)
        {
            var booking = await _bookingRepository.GetByIdAsync(bookingId);
            if (booking == null)
            {
                return false;
            }

            await _bookingRepository.DeleteAsync(bookingId);
            return true;
        }

        public async Task CancelBookingAsync(Guid bookingId)
        {
            var booking = await _bookingRepository.GetByIdAsync(bookingId)
                ?? throw new BookingNotFoundException($"Booking with ID {bookingId} not found.");

            var webinarEntity = await _webinarRepository.GetByIdAsync(booking.WebinarId)
                ?? throw new WebinarNotFoundException($"Webinar with ID {booking.WebinarId} not found.");

            webinarEntity.CancelSeatReservation();

            await _bookingRepository.DeleteAsync(bookingId);
        }
    }
}
