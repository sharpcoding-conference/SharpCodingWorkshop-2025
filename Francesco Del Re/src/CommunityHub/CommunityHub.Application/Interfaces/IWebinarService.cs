using CommunityHub.Application.DTOs;

namespace CommunityHub.Application.Interfaces
{
    /// <summary>
    /// Interfaccia che definisce il contratto per la gestione dei webinar.
    /// Ogni implementazione di questa interfaccia dovrà fornire la logica per creare, recuperare,
    /// aggiornare ed eliminare i webinar nel sistema.
    /// </summary>
    public interface IWebinarService
    {
        /// <summary>
        /// Recupera l'elenco di tutti i webinar disponibili.
        /// </summary>
        /// <returns>Restituisce una collezione di oggetti WebinarDto contenente i dettagli di ciascun webinar.</returns>
        Task<IEnumerable<WebinarDto>> GetAllWebinarsAsync();

        /// <summary>
        /// Recupera i dettagli di un webinar specifico in base al suo ID.
        /// </summary>
        /// <param name="webinarId">ID univoco del webinar da recuperare.</param>
        /// <returns>Restituisce un oggetto WebinarDetailDto con le informazioni dettagliate del webinar.</returns>
        Task<WebinarDetailDto> GetWebinarByIdAsync(Guid webinarId);

        /// <summary>
        /// Crea un nuovo webinar nel sistema utilizzando i dati forniti tramite WebinarDto.
        /// </summary>
        /// <param name="webinarDto">Oggetto contenente i dati del webinar da creare.</param>
        /// <returns>Restituisce l'ID univoco del webinar appena creato.</returns>
        Task<Guid> CreateWebinarAsync(WebinarDto webinarDto);

        /// <summary>
        /// Aggiorna le informazioni di un webinar esistente.
        /// </summary>
        /// <param name="webinarDto">Oggetto contenente i nuovi dati del webinar.</param>
        Task UpdateWebinarAsync(WebinarDto webinarDto);

        /// <summary>
        /// Elimina un webinar dal sistema in base al suo ID.
        /// </summary>
        /// <param name="webinarId">ID del webinar da eliminare.</param>
        Task DeleteWebinarAsync(Guid webinarId);
    }
}