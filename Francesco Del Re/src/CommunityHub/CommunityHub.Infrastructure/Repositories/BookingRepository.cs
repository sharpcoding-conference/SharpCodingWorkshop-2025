using CommunityHub.Domain.Entities;
using CommunityHub.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CommunityHub.Infrastructure.Repositories
{
    /// <summary>
    /// Repository per la gestione delle operazioni CRUD sulle prenotazioni (Booking).
    /// Implementa l'interfaccia IBookingRepository.
    /// </summary>
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Costruttore che riceve il contesto del database tramite dependency injection.
        /// </summary>
        /// <param name="context">Istanza di ApplicationDbContext per l'accesso ai dati.</param>
        public BookingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Recupera una prenotazione in base al suo ID, includendo l'utente associato e il webinar con il relativo intervallo di date.
        /// </summary>
        /// <param name="id">ID della prenotazione da recuperare.</param>
        /// <returns>Restituisce l'oggetto Booking oppure null se non trovato.</returns>
        public async Task<Booking?> GetByIdAsync(Guid id)
        {
            return await _context
                .Bookings
                .Include(u => u.User)
                .Include(w => w.Webinar).ThenInclude(dr => dr.DateRange)
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        /// <summary>
        /// Recupera tutte le prenotazioni presenti nel sistema, includendo le informazioni dell'utente e del webinar.
        /// </summary>
        /// <returns>Restituisce una collezione di oggetti Booking.</returns>
        public async Task<IEnumerable<Booking>> GetAllAsync()
        {
            return await _context
                .Bookings
                .Include(u => u.User)
                .Include(w => w.Webinar).ThenInclude(dr => dr.DateRange)
                .AsNoTracking()
                .ToListAsync();
        }

        /// <summary>
        /// Aggiunge una nuova prenotazione al database.
        /// </summary>
        /// <param name="entity">Oggetto Booking da aggiungere.</param>
        public async Task AddAsync(Booking entity)
        {
            await _context.Bookings.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Aggiorna un'entità di prenotazione esistente nel database.
        /// </summary>
        /// <param name="entity">Oggetto Booking con i dati aggiornati.</param>
        public async Task UpdateAsync(Booking entity)
        {
            _context.Bookings.Update(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Elimina una prenotazione in base al suo ID.
        /// </summary>
        /// <param name="id">ID della prenotazione da eliminare.</param>
        public async Task DeleteAsync(Guid id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Recupera tutte le prenotazioni effettuate da un utente specifico.
        /// </summary>
        /// <param name="userId">ID dell'utente.</param>
        /// <returns>Restituisce una collezione di oggetti Booking associati all'utente.</returns>
        public async Task<IEnumerable<Booking>> GetBookingsByUserAsync(Guid userId)
        {
            return await _context.Bookings
                .Where(b => b.UserId == userId)
                .ToListAsync();
        }

        /// <summary>
        /// Verifica se un utente ha già prenotato un determinato webinar.
        /// </summary>
        /// <param name="userId">ID dell'utente.</param>
        /// <param name="webinarId">ID del webinar.</param>
        /// <returns>Restituisce true se l'utente ha già una prenotazione per il webinar, altrimenti false.</returns>
        public async Task<bool> UserAlreadyBookedAsync(Guid userId, Guid webinarId)
        {
            return await _context.Bookings
                .AnyAsync(b => b.UserId == userId && b.WebinarId == webinarId);
        }
    }
}