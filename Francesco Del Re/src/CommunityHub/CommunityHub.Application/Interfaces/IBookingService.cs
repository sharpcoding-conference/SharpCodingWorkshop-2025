using CommunityHub.Application.DTOs;

namespace CommunityHub.Application.Interfaces
{
    /// <summary>
    /// Interfaccia che definisce il contratto per il servizio di gestione delle prenotazioni (Booking).
    /// Ogni implementazione di questa interfaccia dovrà fornire la logica per creare, recuperare,
    /// aggiornare e cancellare le prenotazioni.
    /// </summary>
    public interface IBookingService
    {
        /// <summary>
        /// Crea una nuova prenotazione utilizzando i dati forniti tramite BookingDto.
        /// </summary>
        /// <param name="bookingDto">Oggetto contenente le informazioni della prenotazione.</param>
        /// <returns>Restituisce l'ID univoco della prenotazione appena creata.</returns>
        Task<Guid> CreateBookingAsync(BookingDto bookingDto);

        /// <summary>
        /// Recupera tutte le prenotazioni disponibili nel sistema.
        /// </summary>
        /// <returns>Restituisce un elenco di oggetti BookingDto.</returns>
        Task<IEnumerable<BookingDto>> GetAllBookingsAsync();

        /// <summary>
        /// Recupera i dettagli di una specifica prenotazione in base al suo ID.
        /// </summary>
        /// <param name="bookingId">ID della prenotazione da recuperare.</param>
        /// <returns>Restituisce un oggetto BookingDto contenente i dettagli della prenotazione.</returns>
        Task<BookingDto> GetBookingByIdAsync(Guid bookingId);

        /// <summary>
        /// Aggiorna le informazioni di una prenotazione esistente.
        /// </summary>
        /// <param name="bookingId">ID della prenotazione da aggiornare.</param>
        /// <param name="bookingDto">Oggetto contenente i nuovi dati della prenotazione.</param>
        /// <returns>Restituisce true se l'aggiornamento è andato a buon fine, altrimenti false.</returns>
        Task<bool> UpdateBookingAsync(Guid bookingId, BookingDto bookingDto);

        /// <summary>
        /// Elimina una prenotazione dal sistema in base al suo ID.
        /// </summary>
        /// <param name="bookingId">ID della prenotazione da eliminare.</param>
        /// <returns>Restituisce true se la prenotazione è stata eliminata con successo, altrimenti false.</returns>
        Task<bool> DeleteBookingAsync(Guid bookingId);

        /// <summary>
        /// Annulla una prenotazione esistente senza eliminarla dal sistema.
        /// </summary>
        /// <param name="bookingId">ID della prenotazione da annullare.</param>
        Task CancelBookingAsync(Guid bookingId);
    }
}
