﻿using AutoMapper;
using CommunityHub.Application.DTOs;
using CommunityHub.Application.Exceptions;
using CommunityHub.Application.Interfaces;
using CommunityHub.Domain.Entities;
using CommunityHub.Domain.Exceptions;
using CommunityHub.Domain.Interfaces;

namespace CommunityHub.Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IWebinarRepository _webinarRepository;
        private readonly IMapper _mapper;

        public BookingService(IBookingRepository bookingRepository, IWebinarRepository webinarRepository, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _webinarRepository = webinarRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateBookingAsync(BookingDto bookingDto)
        {
            var webinarEntity = await _webinarRepository.GetByIdAsync(bookingDto.WebinarId)
                ?? throw new WebinarNotFoundException($"Webinar with ID {bookingDto.WebinarId} not found.");

            if (await _bookingRepository.UserAlreadyBookedAsync(bookingDto.UserId, bookingDto.WebinarId))
                throw new BookingLimitExceededException(
                    $"User with ID {bookingDto.UserId} is already booked in Webinar with ID {bookingDto.WebinarId}"
                );

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
            return _mapper.Map<IEnumerable<BookingDto>>(bookings);
        }

        public async Task<BookingDto> GetBookingByIdAsync(Guid bookingId)
        {
            var booking = await _bookingRepository.GetByIdAsync(bookingId)
                ?? throw new BookingNotFoundException($"Booking with ID {bookingId} not found.");

            return _mapper.Map<BookingDto>(booking);
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
