namespace CleanCodeExercise.DuplicateCode
{
    // Esercizio 2 - Correzione: Rimozione della duplicazione tramite metodo
    public class RefactoredCodeExample
    {
        public void ProcessData()
        {
            Console.WriteLine($"Somma 1: {CalculateSum(0, 10)}");
            Console.WriteLine($"Somma 2: {CalculateSum(10, 20)}");
        }

        private static int CalculateSum(int start, int end)
        {
            int sum = 0;
            for (int i = start; i < end; i++)
            {
                sum += i;
            }
            return sum;
        }
    }
}
