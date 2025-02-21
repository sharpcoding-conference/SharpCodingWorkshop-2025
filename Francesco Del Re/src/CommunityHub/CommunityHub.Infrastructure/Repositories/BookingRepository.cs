﻿using CommunityHub.Domain.Entities;
using CommunityHub.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CommunityHub.Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _context;

        public BookingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Booking?> GetByIdAsync(Guid id)
        {
            return await _context
                .Bookings
                .Include(u => u.User)
                .Include(w => w.Webinar).ThenInclude(dr => dr.DateRange)
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<Booking>> GetAllAsync()
        {
            return await _context
                .Bookings
                .Include(u => u.User)
                .Include(w => w.Webinar).ThenInclude(dr => dr.DateRange)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task AddAsync(Booking entity)
        {
            await _context.Bookings.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Booking entity)
        {
            _context.Bookings.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Booking>> GetBookingsByUserAsync(Guid userId)
        {
            return await _context.Bookings.Where(b => b.UserId == userId).ToListAsync();
        }

        public async Task<bool> UserAlreadyBookedAsync(Guid userId, Guid webinarId)
        {
            return await _context.Bookings.AnyAsync(b => b.UserId == userId && b.WebinarId == webinarId);
        }
    }
}