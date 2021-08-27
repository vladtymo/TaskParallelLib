using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _10_Parallel_Cancel
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;

            Task.Run(() =>
            {
                Thread.Sleep(2000);
                cancelTokenSource.Cancel();
                Console.WriteLine("Canceled");
            });

            try
            {
                //Parallel.ForEach<int>(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 },
                //                        Factorial);

                //Parallel.ForEach<int>(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 },
                //                        new ParallelOptions { CancellationToken = token }, Factorial);
                // или так
                Parallel.For(1, 20, new ParallelOptions { CancellationToken = token }, Factorial);
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine("Операция прервана");
            }
            finally
            {
                cancelTokenSource.Dispose();
            }

            Console.ReadLine();
        }
        static void Factorial(int x)
        {
            int result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
            Console.WriteLine($"Факториал числа {x} равен {result}");
            Thread.Sleep(3000);
            Console.WriteLine("Bye!");
        }
    }
}
