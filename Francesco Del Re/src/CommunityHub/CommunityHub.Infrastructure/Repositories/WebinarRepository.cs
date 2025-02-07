using CommunityHub.Domain.Entities;
using CommunityHub.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CommunityHub.Infrastructure.Repositories
{
    public class WebinarRepository : IWebinarRepository
    {
        private readonly ApplicationDbContext _context;

        public WebinarRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Webinar> GetByIdAsync(Guid id)
        {
            return await _context.Webinars.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Webinar>> GetAllAsync()
        {
            return await _context.Webinars.ToListAsync();
        }

        public async Task AddAsync(Webinar entity)
        {
            await _context.Webinars.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Webinar entity)
        {
            _context.Webinars.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var webinarEntity = await _context.Webinars.FindAsync(id);
            if (webinarEntity != null)
            {
                _context.Webinars.Remove(webinarEntity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Webinar>> GetUpcomingWebinarssAsync()
        {
            return await _context.Webinars.Where(w => w.DateRange.StartDate >= DateTime.UtcNow).ToListAsync();
        }
    }
}
