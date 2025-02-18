namespace CleanCodeExercise.ExceptionHandling
{
    // Esercizio 3 - Correzione: Gestione delle eccezioni più dettagliata
    public class ImprovedExceptionHandlingExample
    {
        public void ReadFile(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("Errore: Il file non esiste.");
                    return;
                }
                string content = File.ReadAllText(filePath);
                Console.WriteLine($"Contenuto del file: {content}");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Errore: Accesso negato al file.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Errore di I/O: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore generico: {ex.Message}");
            }
        }
    }
}
