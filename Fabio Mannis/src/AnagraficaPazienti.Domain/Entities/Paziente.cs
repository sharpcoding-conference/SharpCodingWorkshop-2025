namespace AnagraficaPazienti.Domain.Entities
{
    public class Paziente
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cognome { get; set; } = string.Empty;
        public DateTime DataNascita { get; set; }
        public string CodiceFiscale { get; set; } = string.Empty;
    }
}
