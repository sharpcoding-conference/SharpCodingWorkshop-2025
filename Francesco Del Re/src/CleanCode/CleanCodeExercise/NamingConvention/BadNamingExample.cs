namespace CleanCodeExercise.NamingConvention
{
    // Esercizio 1: Codice con nomi poco chiari
    public class BadNamingExample
    {
        public void ProcessOrder(string x, int y)
        {
            Console.WriteLine($"Elaborazione ordine {x} con quantità {y}");
        }
    }
}