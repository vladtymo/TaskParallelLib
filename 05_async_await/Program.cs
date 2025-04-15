using System.Text;

class Program
{
    static async Task Main(string[] args)
    {
        Task<int> task1 = new Task<int>(() => Factorial(5));
        Task<int> task2 = new Task<int>(() => Summ(45274));

        task1.Start();
        task2.Start();

        //int res1 = Factorial(5);
        //int res2 = Summ(45274);

        int res1 = await FactorialAsync(5);

        //task1.Wait();
        Console.WriteLine($"Factorial = {await task1}");
        Console.WriteLine($"Summ = {await task2}");

        Console.WriteLine("Main continue working...");
        Task.WaitAll(task1, task2);
    }

    static int Factorial(int x)
    {
        int result = 1;

        for (int i = 1; i <= x; i++)
        {
            result *= i;
            Thread.Sleep(1000);
        }

        return result;
    }

    static Task<int> FactorialAsync(int x)
    {
        return Task.Run(() =>
        {
            int result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
                Thread.Sleep(1000);
            }

            return result;
        });
    }
    static int Summ(int value)
    {
        return Math.Abs(value.ToString().ToCharArray().Select(c => (int)c).Sum());
    }
}
