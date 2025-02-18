namespace CleanCodeExercise.ExceptionHandling
{
    // Esercizio 3: Gestione delle eccezioni poco chiara
    public class ExceptionHandlingExample
    {
        public void ReadFile(string filePath)
        {
            try
            {
                string content = File.ReadAllText(filePath);
                Console.WriteLine(content);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore: {ex.Message}");
            }
        }
    }
}
