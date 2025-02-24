using CommunityHub.Domain.Entities;
using CommunityHub.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CommunityHub.Infrastructure.Repositories
{
    public class WebinarRepository : IWebinarRepository
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Costruttore che riceve il contesto del database tramite dependency injection.
        /// </summary>
        /// <param name="context">Istanza di ApplicationDbContext per l'accesso ai dati.</param>
        public WebinarRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Recupera un webinar in base al suo ID, includendo l'intervallo di date e le prenotazioni con gli utenti associati.
        /// </summary>
        /// <param name="id">ID del webinar da recuperare.</param>
        /// <returns>Restituisce l'oggetto Webinar oppure null se non trovato.</returns>
        public async Task<Webinar?> GetByIdAsync(Guid id)
        {
            return await _context
                .Webinars
                .AsNoTracking()
                .Include(x => x.DateRange)
                .Include(b => b.Bookings).ThenInclude(u => u.User)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        /// <summary>
        /// Recupera tutti i webinar presenti nel sistema, includendo l'intervallo di date.
        /// </summary>
        /// <returns>Restituisce una collezione di oggetti Webinar.</returns>
        public async Task<IEnumerable<Webinar>> GetAllAsync()
        {
            return await _context
                .Webinars
                .AsNoTracking()
                .Include(x => x.DateRange)
                .ToListAsync();
        }

        /// <summary>
        /// Aggiunge un nuovo webinar al database.
        /// </summary>
        /// <param name="entity">Oggetto Webinar da aggiungere.</param>
        public async Task AddAsync(Webinar entity)
        {
            await _context.Webinars.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Aggiorna i dati di un webinar esistente nel database.
        /// </summary>
        /// <param name="entity">Oggetto Webinar con i dati aggiornati.</param>
        public async Task UpdateAsync(Webinar entity)
        {
            _context.Webinars.Update(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Elimina un webinar dal database in base al suo ID.
        /// </summary>
        /// <param name="id">ID del webinar da eliminare.</param>
        public async Task DeleteAsync(Guid id)
        {
            var webinarEntity = await _context.Webinars.FindAsync(id);
            if (webinarEntity != null)
            {
                _context.Webinars.Remove(webinarEntity);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Recupera tutti i webinar futuri, ovvero quelli con data di inizio successiva alla data attuale.
        /// </summary>
        /// <returns>Restituisce una collezione di webinar in programma.</returns>
        public async Task<IEnumerable<Webinar>> GetUpcomingWebinarssAsync()
        {
            return await _context.Webinars
                .Where(w => w.DateRange.StartDate >= DateTime.UtcNow)
                .ToListAsync();
        }
    }
}
