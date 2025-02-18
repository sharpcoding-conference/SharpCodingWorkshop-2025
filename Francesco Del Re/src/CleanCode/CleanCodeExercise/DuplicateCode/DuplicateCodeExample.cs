namespace CleanCodeExercise.DuplicateCode
{
    // Esercizio 2: Codice duplicato
    public class DuplicateCodeExample
    {
        public void ProcessData()
        {
            Console.WriteLine($"Somma 1: {CalculateSum(0, 10)}");
            Console.WriteLine($"Somma 2: {CalculateSum(10, 20)}");
        }

        private int CalculateSum(int start, int end)
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
