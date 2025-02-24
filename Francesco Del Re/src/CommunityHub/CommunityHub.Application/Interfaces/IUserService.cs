using CommunityHub.Application.DTOs;

namespace CommunityHub.Application.Interfaces
{
    /// <summary>
    /// Interfaccia che definisce il contratto per la gestione degli utenti.
    /// Ogni implementazione di questa interfaccia dovrà fornire la logica per creare, recuperare,
    /// aggiornare ed eliminare gli utenti nel sistema.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Recupera i dettagli di un utente specifico in base al suo ID.
        /// </summary>
        /// <param name="userId">ID univoco dell'utente da recuperare.</param>
        /// <returns>Restituisce un oggetto UserDetailDto contenente le informazioni dettagliate dell'utente.</returns>
        Task<UserDetailDto> GetUserByIdAsync(Guid userId);

        /// <summary>
        /// Crea un nuovo utente nel sistema utilizzando i dati forniti tramite UserDto.
        /// </summary>
        /// <param name="userDto">Oggetto contenente i dati dell'utente da creare.</param>
        /// <returns>Restituisce l'ID univoco dell'utente appena creato.</returns>
        Task<Guid> CreateUserAsync(UserDto userDto);

        /// <summary>
        /// Recupera un elenco di tutti gli utenti registrati nel sistema.
        /// </summary>
        /// <returns>Restituisce una collezione di oggetti UserDto.</returns>
        Task<IEnumerable<UserDto>> GetAllUsersAsync();

        /// <summary>
        /// Aggiorna le informazioni di un utente esistente.
        /// </summary>
        /// <param name="userDto">Oggetto contenente i nuovi dati dell'utente.</param>
        Task UpdateUserAsync(UserDto userDto);

        /// <summary>
        /// Elimina un utente dal sistema in base al suo ID.
        /// </summary>
        /// <param name="userId">ID dell'utente da eliminare.</param>
        Task DeleteUserAsync(Guid userId);
    }
}
