using AnagraficaPazienti.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnagraficaPazienti.Application.Interfaces
{
    public interface IPazienteService
    {
        Task<List<Paziente>> GetAllPazienti();
        Task<Paziente> GetPazienteById(int id);
        Task<Paziente> AddPaziente(Paziente paziente);
    }
}