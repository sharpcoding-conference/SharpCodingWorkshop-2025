using CommunityHub.Domain.Entities;
using CommunityHub.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CommunityHub.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Costruttore che riceve il contesto del database tramite dependency injection.
        /// </summary>
        /// <param name="context">Istanza di ApplicationDbContext per l'accesso ai dati.</param>
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Recupera un utente in base al suo ID, includendo le sue prenotazioni e i relativi webinar con intervalli di date.
        /// </summary>
        /// <param name="id">ID dell'utente da recuperare.</param>
        /// <returns>Restituisce l'oggetto User oppure null se non trovato.</returns>
        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _context
                .Users
                .AsNoTracking()
                .Include(b => b.Bookings).ThenInclude(w => w.Webinar).ThenInclude(dr => dr!.DateRange)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        /// <summary>
        /// Recupera tutti gli utenti presenti nel sistema.
        /// </summary>
        /// <returns>Restituisce una collezione di oggetti User.</returns>
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context
                .Users
                .AsNoTracking()
                .ToListAsync();
        }

        /// <summary>
        /// Aggiunge un nuovo utente al database.
        /// </summary>
        /// <param name="entity">Oggetto User da aggiungere.</param>
        public async Task AddAsync(User entity)
        {
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Aggiorna i dati di un utente esistente nel database.
        /// </summary>
        /// <param name="entity">Oggetto User con i dati aggiornati.</param>
        public async Task UpdateAsync(User entity)
        {
            _context.Users.Update(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Elimina un utente dal database in base al suo ID.
        /// </summary>
        /// <param name="id">ID dell'utente da eliminare.</param>
        public async Task DeleteAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
